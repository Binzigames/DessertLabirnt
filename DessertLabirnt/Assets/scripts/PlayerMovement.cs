using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    private CharacterController characterController;
    private float verticalVelocity;
    public float gravity = 14.0f;

    private Animator camera;

    void Start()
    {
        // Отримуємо посилання на CharacterController
        characterController = GetComponent<CharacterController>();

        // Приховуємо курсор миші при старті
        Cursor.lockState = CursorLockMode.Locked;

        //camera
        camera = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Отримання даних з клавіатури
        float moveForward = Input.GetAxis("Vertical") * speed;
        float moveSide = Input.GetAxis("Horizontal") * speed;

        //cameraAnimator
        if (moveForward != 0 || moveSide != 0)
        {
            camera.SetBool("isRun", true);
        }
        else
        {
            camera.SetBool("isRun", false);
        }
        // Формування вектора руху
        Vector3 move = transform.forward * moveForward + transform.right * moveSide;

        // Гравітація
        move.y -= gravity * Time.deltaTime;

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
