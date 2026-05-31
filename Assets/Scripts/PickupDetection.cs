using UnityEngine;

public class PickupDetection : MonoBehaviour
{
    [SerializeField] GameObject dropoffSpot;
    [SerializeField] GameObject personPickup;
    [SerializeField] GameObject personDropoff;

    [SerializeField] public float pickupTimerProgress;
    [SerializeField] public float pickupTimerDuration;

    bool isPlayerInside;
    bool hasBeenPickedup;

    void Start()
    {
        dropoffSpot.SetActive(false);
        personDropoff.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInside && !hasBeenPickedup)
        {
            pickupTimerProgress += Time.deltaTime;

            if (pickupTimerProgress >= pickupTimerDuration)
            {
                PickedUpPerson();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            isPlayerInside = false;
            pickupTimerProgress = 0f;        
        }
    }
    void PickedUpPerson()
    { 
        hasBeenPickedup = true;

        personPickup.SetActive(false);
        gameObject.SetActive(false);

        dropoffSpot.SetActive(true);
    }
}

