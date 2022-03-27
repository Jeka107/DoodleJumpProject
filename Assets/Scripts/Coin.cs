using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 50;
    public bool coinOnBlock = false;
    private void OnTriggerEnter(Collider other) //when collide destroy.
    {
        if(other.tag=="Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 5f);
        }
        else
            Destroy(gameObject);

    }
}
