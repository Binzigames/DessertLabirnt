using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Animator point;

    public GameObject slot;
    public Transform slotTransform;

    public Inventory inventory;
    private void OnMouseEnter()
    {
        point.SetBool("Active", true);
    }
    private void OnMouseExit()
    {
        point.SetBool("Active", false);
    }
    private void OnMouseDown()
    {
        if (inventory.isFull == false)
        {
            inventory.isFull = true;
            point.SetBool("Active", false);
            Instantiate(slot, slotTransform);
            Destroy(gameObject);
        }
    }
}
