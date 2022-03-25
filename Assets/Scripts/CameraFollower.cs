using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerTramsform;

    void Update()
    {
        if (playerTramsform!=null)
        {
            if (playerTramsform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x,
                    playerTramsform.position.y,
                    transform.position.z);
            }
        }
    }
}
