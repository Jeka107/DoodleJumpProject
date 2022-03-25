using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabelShow : MonoBehaviour
{
    public float waitTime;
    public GameObject playAgainLabel;
    

    void Start()
    {
        playAgainLabel.SetActive(false); //dont show lable on start.
    }

    public void ShowPlayAgain() //function to show label and activate animation.
    {
        playAgainLabel.SetActive(true);
        playAgainLabel.GetComponent<Animator>().SetBool("ShowLabel", true);
    }

    public void Restart() //restart the scene and activate animation.
    {
        playAgainLabel.GetComponent<Animator>().SetBool("ShowLabel", false);
        StartCoroutine(WaitSeconds());
    }
    IEnumerator WaitSeconds() //for waiting and do action.
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0); //load first scene.
    }
}
