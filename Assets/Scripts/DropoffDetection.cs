using UnityEngine;
using TMPro;

public class DropoffDetection : MonoBehaviour
{
    [SerializeField] GameObject personDropoff;
    [SerializeField] ScoreUpdate scoreUpdateScript;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Player"))
        {
            DropoffPerson();
        }        
    }

    void DropoffPerson()
    {
        scoreUpdateScript.AddToScore();
        personDropoff.SetActive(true);
        gameObject.SetActive(false);
    }
}

