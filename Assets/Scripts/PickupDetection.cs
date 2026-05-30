using UnityEngine;

public class PickupDetection : MonoBehaviour
{
    [SerializeField] GameObject pickupPerson;
    [SerializeField] GameObject pickupSpot;

    [SerializeField] public float pickupTimerProgress;
    [SerializeField] public float pickupTimerDuration;

    bool isInPickupBox;

    private void Update()
    {
        PickupTimer();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            isInPickupBox = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        pickupTimerProgress = 0f;
        isInPickupBox = false;
    }
    void PickupTimer()
    {
        if (isInPickupBox)
        {
            pickupTimerProgress += Time.deltaTime;

            if (pickupTimerProgress > pickupTimerDuration)
            {
                PickedUpPerson();
            }
        }
    }
    void PickedUpPerson()
    { 
        pickupPerson.SetActive(false);
        pickupSpot.SetActive(false);
        isInPickupBox = false;
        pickupTimerProgress = pickupTimerDuration;        
    }
}

