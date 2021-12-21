using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_floor2 : MonoBehaviour
{
    public Walk_Play2 playerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "floor") {
            playerScript.grounded = true;
            print("On floor");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "floor") {
            playerScript.grounded = false;
            print("Out floor");
        }
    }
}
