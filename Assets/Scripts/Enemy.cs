using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    Rigidbody rb;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f); //front of the block.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (MovingRight()) //similar to moving block.
        {
            rb.velocity = new Vector3(speed, 0f, 0f);   //moving right
            rb.rotation = Quaternion.Euler(0f, 0f, 0f); //face to right.
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);    //moving left.
            rb.rotation = Quaternion.Euler(0f, 180f, 0f); //face to left.
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall") //change direction when hit wall.
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = newVelocity.x * (-1); //change direction.
            rb.velocity = newVelocity;
        }
    }
        bool MovingRight() //cheking moving left or right.
    {
        return rb.velocity.x > 0;
    }
}
