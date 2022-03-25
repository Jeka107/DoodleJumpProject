using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    [Range(5, 20)]
    public float jumpForce;

    public float shakeSpeed=0.1f;
    public float shakeAmount =0.1f;
    public bool touched = false;
    public int rotSpeed;
    public float waitTime = 1f;

    MeshRenderer mr;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        transform.position =new Vector3( Mathf.Sin(Time.time * shakeSpeed) * shakeAmount,
            transform.position.y+ Mathf.Sin(Time.time * shakeSpeed) * shakeAmount,
            transform.position.z);                                                        //shaking the block on x,y,z.
        if (touched)  //simliar to moving block.
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

    private void OnTriggerEnter(Collider other)  //similar as moving block.
    {
        if (other.GetComponent<PlayerMovement>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb.velocity.y < 0)
            {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = jumpForce;
                rb.velocity = newVelocity;
                GetComponent<Rigidbody>().isKinematic = false;
                touched = true;
            }
        }
        if (other.tag == "Coin")
            Destroy(other.gameObject);
    }
}
