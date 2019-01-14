
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float mouseSensitivity = 3.0f;

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

        // Calculate player rotation as a 3d vector so player can turn/look left or right
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0.0f, yRotation, 0.0f) * mouseSensitivity;
        motor.Rotate(rotation);

        // Calculate player camera rotation as a 3d Vector so player can look up and down
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRotation, 0.0f, 0.0f);
        motor.RotateCamera(cameraRotation);


    }
}
