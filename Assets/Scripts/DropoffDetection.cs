using UnityEngine;

public class DropoffDetection : MonoBehaviour
{
    [SerializeField] GameObject dropoffSpot;
    [SerializeField] GameObject dropoffPerson;

    PickupDetection pickupDetectionScript;

    Vector2 dropoffPosition;

    public bool successfullyDropped;
    void Start()
    {
        pickupDetectionScript = GetComponent<PickupDetection>();
    }

    void Update()
    {
        TurnOnDropoffSpot();
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Dropoff"))
        {
            ReachedDropoffDestination();
        }
    }

    void TurnOnDropoffSpot()
    {
        if (pickupDetectionScript.pickupTimerProgress >= pickupDetectionScript.pickupTimerDuration)
        {
            dropoffSpot.SetActive(true);
        }
    }

    void ReachedDropoffDestination()
    {
        dropoffPosition = dropoffSpot.transform.position + new Vector3(0, 2, 0);

        dropoffSpot.SetActive(false);

        GameObject newPersonAtDrop = Instantiate(dropoffPerson, dropoffPosition, Quaternion.identity);

        newPersonAtDrop.SetActive(true);

        successfullyDropped = true;
    }
}

