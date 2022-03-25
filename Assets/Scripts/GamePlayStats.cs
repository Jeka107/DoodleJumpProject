using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public PlayerMovement playerMovement;

    void Update()
    {
        scoreText.text= playerMovement.score.ToString(); //show score on up left the screen. 
    }
}
