using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float accelerateSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float speedLimitMax;
    [SerializeField] float speedLimitMin;

    [SerializeField] float steerSpeed;

    Vector2 directionalInput;
    Vector3 position;

    void Update()
    {
        Drive();
        Steer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    void Drive()
    {
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
}
