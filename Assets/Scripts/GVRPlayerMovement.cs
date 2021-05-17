using UnityEngine;
using System.Collections;

public class GVRPlayerMovement : MonoBehaviour
{
    
    /// <summary>
    /// The current speed of the CharacterController
    /// </summary>
    private float currentVelocity = 0.0F;

    /// <summary>
    /// The maximum speed of the CharacterController
    /// </summary>
    public float maxVelocity = 10.0F;

    /// <summary>
    /// The rate at which the CharacterController accelerates
    /// </summary>
    public float acceleration = 0.15F;



    void Start()
    {
    }

    void Update()
    {
        // The touchpad is button 0. If the touchpad is being held down...
        if (Input.GetMouseButton(0))
        {
            // Add the acceleration to the current velocity and clamp it to the maxVelocity
            currentVelocity += acceleration;
            currentVelocity = Mathf.Clamp(currentVelocity, 0.0F, maxVelocity);

            // Then move the CharacterController forward

            if(Camera.main.transform.forward.y==0f)
            {
                transform.position += Camera.main.transform.forward * currentVelocity * Time.deltaTime;
            }
            else
            {
                Vector3 co = new Vector3((Camera.main.transform.forward.x * currentVelocity * Time.deltaTime), 0, (Camera.main.transform.forward.z * currentVelocity * Time.deltaTime));
                transform.position += co;
            }
        }

        // If the touchpad was released on this frame, stop movement and reset current speed.
        if (Input.GetMouseButtonUp(0))
        {
            currentVelocity = 0.0F;
        }
    }
}