using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float FlySpeed = 0.0f;
    public float RollAmount = 15f;
    public float PitchAmount = 10f;
    public float YawAmount = 20f;
    private float Roll = 0f;
    private float Pitch = 0f;
    private float Yaw = 0f;
    public float gravityThreshold = 10.0f;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool acceleration = Input.GetKey("=");
        bool braking = Input.GetKey("-");
        bool park = Input.GetKey(";");

        if (acceleration)
        {
            FlySpeed += 0.2f;
        }
        else if (braking)
        {
            FlySpeed -= 0.2f;
        }

        if (park)
        {
            FlySpeed = 0.0f;
            _rigidbody.velocity = Vector3.zero;
        }

        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float yawInput = Input.GetAxis("Yaw");

        Debug.Log(verticalInput);


        Roll += 10f * horizontalInput * RollAmount * Time.deltaTime;
        Pitch += 10f * verticalInput * PitchAmount * Time.deltaTime;
        Yaw += 1f * yawInput * YawAmount * Time.deltaTime;


        Quaternion rollQuaternion = Quaternion.Euler(0, 0, -Roll);
        Quaternion pitchQuaternion = Quaternion.Euler(Pitch, 0, 0);
        Quaternion yawQuaternion = Quaternion.Euler(0, Yaw, 0);

        Quaternion finalRotation = yawQuaternion * pitchQuaternion * rollQuaternion;

        transform.rotation = finalRotation;

        if (transform.position.y < gravityThreshold)
        {
            _rigidbody.useGravity = true;
        }
        else
        {
            _rigidbody.useGravity = false;
        }
    }
}

