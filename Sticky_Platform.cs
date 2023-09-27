using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Platform : MonoBehaviour
{

    ////note [if the player sticks, change to on trigger and add two box collider]
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //checking if the gameObject colliding with the platform is player or not 
    //    if(collision.gameObject.name == "Player")
    //    {
    //        //if the colliding gameObject is player then, set the platform as parent
    //        collision.gameObject.transform.SetParent(transform);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(null);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}

