using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>()) //if player collide with spike then.
        {
            FindObjectOfType<LabelShow>().ShowPlayAgain();     //show label.
            Destroy(collision.gameObject);                    //destroy player.
        }
    }
}
