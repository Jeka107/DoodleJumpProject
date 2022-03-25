using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementPower = 15f;
    public int score = 0;
    public int rotSpeed;
    public float waitTime = 1f;

    Rigidbody rb;
    int ScoreClimb;
    int scoreCoin;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementPower; //using Horizontal to move player left and right.
        Vector3 newMovement = rb.velocity; 
        int checkScore;

        newMovement.x = horizontalMovement;
        rb.velocity = newMovement;  //puting new movment.

        if(Input.GetAxis("Horizontal")>0) //cheking if player moving right.
        {
            rb.rotation = Quaternion.Euler(0f, 180f, 0f); //player will face right.
        }
        else if(Input.GetAxis("Horizontal") < 0) //cheking if player moving left.
        {
            rb.rotation = Quaternion.Euler(0f, 0f, 0f); //player will face left.
        }
        ScoreClimb = Mathf.RoundToInt(transform.position.y); //score increased in coordination with y.
        checkScore = ScoreClimb + scoreCoin; //adding score climb with score coin the player collected.

        if (checkScore > score) //if out score smaller then the check score then our score equals checkscore.
        {
            score = checkScore;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Coin") //if coin collected then adding coin value to score coin.
        {
            scoreCoin += other.gameObject.GetComponent<Coin>().coinValue;
        }
        if(other.tag=="Enemy")//if the player collide with enemy then the player destroyed.
        {
            Destroy(gameObject);
            FindObjectOfType<LabelShow>().ShowPlayAgain(); //calling function to show play again label.
        }
    }
    public void ActiveAnimation() //function to activate jump animation.
    {
        GetComponent<Animator>().SetBool("IsJumping", true);
        StartCoroutine(WaitSeconds());
    }
    IEnumerator WaitSeconds() //for wating and do action.
    {
        yield return new WaitForSeconds(waitTime); //waiting 
        GetComponent<Animator>().SetBool("IsJumping", false); //activare falling animation.
    }
}
