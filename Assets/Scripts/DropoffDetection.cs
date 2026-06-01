using UnityEngine;
using TMPro;

public class DropoffDetection : MonoBehaviour
{
    [SerializeField] GameObject personDropoff;
    [SerializeField] TextMeshProUGUI scoreText;

    float score;
    float moneyMade;

    private void Update()
    {
        scoreText.text = "Fare: " + score + "$";
    }
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Player"))
        {
            DropoffPerson();
            score += moneyMade;
        }
    }

    void DropoffPerson()
    {
        personDropoff.SetActive(true);
        gameObject.SetActive(false);
    }
}

