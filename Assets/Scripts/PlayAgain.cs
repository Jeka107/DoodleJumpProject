using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayAgain : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float waitTime;
    public float waitTimeAgain;

    bool check = false;
    void Update()
    {
        if (check == false)// checking first time.
        {
            scoreText.text = FindObjectOfType<GamePlayStats>().scoreText.text; //putting score to text label.
            StartCoroutine(WaitSeconds());
        }
    }

    IEnumerator WaitSeconds() //for waiting and do action.
    {
        yield return new WaitForSeconds(waitTime); //wait
        scoreText.GetComponent<Animator>().enabled=true; //enable animator component.
        check = true; //been here
        StartCoroutine(WaitSecondsAgain());
    }
    IEnumerator WaitSecondsAgain()
    {
        yield return new WaitForSeconds(waitTimeAgain);
        scoreText.fontSize = 20; //change font size 
        scoreText.text = "Play"+"\n"+"Again"; //change text.
        scoreText.GetComponent<Animator>().SetBool("PlayAgain", true); //activate animation.
    }
}
