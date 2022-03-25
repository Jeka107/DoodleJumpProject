using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    int count = 0;

    private void OnTriggerEnter(Collider other) //destroying everything on the way.
    {
        if (other.tag=="Block"|| other.tag == "FallingBlock"|| other.tag == "MovingBlock"||other.tag=="Coin")
        {
            Destroy(other.gameObject);
            count++;
        }
        if(other.tag=="Player")
        {
            FindObjectOfType<LabelShow>().ShowPlayAgain();
            Destroy(other.gameObject);
        }
        if(other.tag=="Enemy")
        {
            Destroy(other.gameObject);
        }
    }
    public int GetCount() //return number of blocks that destroyed.used for moving stages.
    {
        return count;
    }
}
