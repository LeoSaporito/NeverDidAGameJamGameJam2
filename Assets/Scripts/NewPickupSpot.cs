using UnityEngine;

public class NewPickupSpot : MonoBehaviour
{
    DropoffDetection dropoffDetectionScript;

    int randomNumber;
    void Start()
    {
        dropoffDetectionScript = GetComponent<DropoffDetection>();    
    }

    private void Update()
    {
        RandomNumberGenerator();
    }

    void RandomNumberGenerator()
    {
        if (dropoffDetectionScript.successfullyDropped == true)
        {
            randomNumber = Random.Range(0, 3);

            dropoffDetectionScript.successfullyDropped = false;

            Debug.Log(randomNumber);
        }
    }
}
