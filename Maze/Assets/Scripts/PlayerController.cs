
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Calculate movement velocity as 3D vector
        float xMovement = Input.GetAxisRaw("Horizontal"); 
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMovement;
        Vector3 moveVertical = transform.forward * zMovement;

        // Final movement vecctor
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

    }
}
