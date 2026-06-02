using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float accelerateSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float speedLimitMax;
    [SerializeField] float speedLimitMin;
    [SerializeField] float steerSpeed;

    [SerializeField] Animator myAnimator;

    Vector2 directionalInput;
    Vector3 position;

    bool isAlive;

    Rigidbody2D myRigidbody;

    private void Start()
    {
        isAlive = true;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isAlive) { return; }

        Drive();
        Steer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    void Drive()
    {
        if (directionalInput.y != 0)
        {
            myAnimator.SetBool("Idle", false);
            myAnimator.SetBool("Driving", true);
        }
        else 
        {
            myAnimator.SetBool("Idle", true);
            myAnimator.SetBool("Driving", false);        
        }
            position = transform.position;

        if (directionalInput.y > 0)
        {
            currentSpeed += accelerateSpeed;

            if (currentSpeed > speedLimitMax)
            {
                currentSpeed = speedLimitMax;
            }
        }
        else if (directionalInput.y < 0)
        {
            currentSpeed -= accelerateSpeed;

            if (currentSpeed < speedLimitMin)
            {
                currentSpeed = speedLimitMin;
            }
        }
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= accelerateSpeed;

                if (currentSpeed < 0.1)
                {
                    currentSpeed = 0;
                }
            }
            else if (currentSpeed < 0)
            {
                currentSpeed += accelerateSpeed;

                if (currentSpeed > 0.1)
                {
                    currentSpeed = 0;
                }
            }
        }

        position += currentSpeed * Time.deltaTime * transform.up;

        transform.position = position;
    }

    void Steer()
    {
        float steer = Time.deltaTime * directionalInput.x * steerSpeed;

        transform.Rotate(0, 0, -steer);
    }

    public void DisableControls()
    {
        isAlive = false;
    }
}
