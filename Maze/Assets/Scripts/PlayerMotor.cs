
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    // Optional camera movement
    [SerializeField]
    private Camera cameraObject = null;

    private Vector3 velocity = Vector3.zero;
    private Vector3 playerHorizontalRotation = Vector3.zero;
    private Vector3 playerVerticalRotation = Vector3.zero;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 newrotation)
    {
        playerHorizontalRotation = newrotation;
    }

    public void RotateCamera(Vector3 cameraRotation)
    {
        playerVerticalRotation = cameraRotation; 
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        if(playerHorizontalRotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(playerHorizontalRotation));
        }

        if(cameraObject != null)
        {
            cameraObject.transform.Rotate(-playerVerticalRotation);
        }
    }
    

}
