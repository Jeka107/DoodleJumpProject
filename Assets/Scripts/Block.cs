using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Range(5, 20)]
    public float jumpForce;
    public bool touched=false;
    public int rotSpeed;

    MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()                    //similar to moving block.
    {
        if (touched)
        {
            mr.material.SetFloat("Vector1_cb890da1852b405ab365016cd970ee90", mr.material.GetFloat("Vector1_cb890da1852b405ab365016cd970ee90") + 0.03f);
            if (mr.material.GetFloat("Vector1_cb890da1852b405ab365016cd970ee90") >= 1)
            {
                if (FindObjectOfType<PlayerMovement>())
                {
                    FindObjectOfType<PlayerMovement>().ActiveAnimation();
                    touched = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)         //similar to moving block.
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb.velocity.y < 0)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = jumpForce;
                rb.velocity = newVelocity;
                touched = true;
                GetComponent<AudioSource>().Play();
            }
        }
        if (other.tag == "Coin")
            Destroy(other.gameObject);
    }
}
