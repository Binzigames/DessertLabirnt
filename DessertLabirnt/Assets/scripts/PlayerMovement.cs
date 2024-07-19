using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    private CharacterController characterController;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;

    void Start()
    {
        // Отримуємо посилання на CharacterController
        characterController = GetComponent<CharacterController>();

        // Приховуємо курсор миші при старті
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Отримання даних з клавіатури
        float moveForward = Input.GetAxis("Vertical") * speed;
        float moveSide = Input.GetAxis("Horizontal") * speed;

        // Формування вектора руху
        Vector3 move = transform.forward * moveForward + transform.right * moveSide;

        // Гравітація і стрибки
        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        move.y = verticalVelocity;

        // Переміщення гравця
        characterController.Move(move * Time.deltaTime);

        // Обертання персонажа за допомогою миші
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Обертання тільки по горизонталі
        transform.Rotate(0, mouseX, 0);

        // Обертання камери по вертикалі (за допомогою обертання камери)
        Camera.main.transform.Rotate(-mouseY, 0, 0);
    }
}
