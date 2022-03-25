using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [Range(5, 20)]
    public float jumpForce;
    public float speed;
    public bool touched = false;
    public int rotSpeed;
    public float waitTime = 1f;

    MeshRenderer mr;
    Rigidbody rb;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (MovingRight()) //calling function to check which direction the block moving.
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);
        }
        if (touched)  //checking if block have been touched.
        {
            mr.material.SetFloat("Vector1_cb890da1852b405ab365016cd970ee90", mr.material.GetFloat("Vector1_cb890da1852b405ab365016cd970ee90") + 0.03f);
            if (mr.material.GetFloat("Vector1_cb890da1852b405ab365016cd970ee90") >= 1)
            {
                if (FindObjectOfType<PlayerMovement>()) //checking if there is a player.
                {
                    FindObjectOfType<PlayerMovement>().ActiveAnimation(); //activate jump animation when touched.
                    touched = false;
                }
            }
        }
    }
    bool MovingRight() //function return true if block moving right false if left.
    {
        return rb.velocity.x > 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wall") //if block hits wall change diraction.
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = newVelocity.x * (-1); //for changing diraction
            rb.velocity = newVelocity;
        }
        if (other.GetComponent<PlayerMovement>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb.velocity.y < 0)
            {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = jumpForce;
                rb.velocity = newVelocity;
                touched = true; //block have been touched.
            }
        }
        if (other.tag == "Coin") //if coin spawned in block the coin will be destroyed.
            Destroy(other.gameObject);
    }
}
