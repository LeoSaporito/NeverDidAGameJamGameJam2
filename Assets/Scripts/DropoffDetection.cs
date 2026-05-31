using UnityEngine;

public class DropoffDetection : MonoBehaviour
{
    [SerializeField] GameObject personDropoff;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Player"))
        {
            DropoffPerson();
        }
    }

    void DropoffPerson()
    {
        personDropoff.SetActive(true);
        gameObject.SetActive(false);
    }
}

