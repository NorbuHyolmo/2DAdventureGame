using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testingFall : MonoBehaviour
{
    private Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();    
    }

    //private void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.name == "Player")
    //    {
    //        rd.bodyType = RigidbodyType2D.Dynamic;
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            rd.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
