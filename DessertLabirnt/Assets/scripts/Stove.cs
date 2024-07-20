using UnityEngine;

public class Stove : MonoBehaviour
{
    public int[] recipe;
    public Animator point;

    public Inventory inventory;
    public GameObject itemTransform;

    public bool isCakeReady;
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
        if (inventory.isFull == true && isCakeReady == false && itemTransform.GetComponentInChildren<Id>() != null)
        {
            CheckId();
            Destroy(itemTransform.transform.GetChild(0).gameObject);
        }
    }

    private void CheckId()
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            if (recipe[i] == itemTransform.GetComponentInChildren<Id>().id)
            {
                recipe[i] = 0;
                int lenghtNull = 0;
                for (int j = 0; j < recipe.Length; j++)
                {
                    if (recipe[j] == 0)
                    {
                        lenghtNull++;
                    }
                }
                if (lenghtNull == recipe.Length)
                {
                    Debug.Log("Cake is READY!");
                }
                break;
            }
        }
    }
}