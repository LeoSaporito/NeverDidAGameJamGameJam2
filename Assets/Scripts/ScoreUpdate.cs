using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float moneyMade;

    float score;

    void Update()
    {
        scoreText.text = "Fare: " + score + "$";

    }

    public void AddToScore()
    { 
        score += moneyMade;        
    }
}
