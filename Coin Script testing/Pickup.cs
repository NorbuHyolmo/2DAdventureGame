using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory Inventory;
    public GameObject itemButton;

    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            for (int i = 0; i<Inventory.slots.Length; i++)
            {

                if (Inventory.isFull[i] == false)
                {
                    //items can be added to the inventory
                    Inventory.isFull[i] = true;
                    Instantiate(itemButton, Inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }

            }
        }
    }
}
