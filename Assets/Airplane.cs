using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float thrustPower = 500f;
    public float liftBooster = 5f;
    public float drag = 0.02f;
    public float angularDrag = 0.01f;

    [SerializeField] float yawPower = 50f;  // Turning speed
    [SerializeField] float pitchPower = 50f; // Nose up/down speed
    [SerializeField] float rollPower = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        ApplyThrust();
        ApplyLift();
        ApplyDrag();
        HandleRotation();
    }

    void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
        }
    }

    void ApplyLift()
    {
        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
    }

    void ApplyDrag()
    {
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;
    }

    void HandleRotation()
    {
        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rb.AddTorque(transform.up * yaw);    // Yaw (Turn left/right)
        rb.AddTorque(transform.right * pitch); // Pitch (Nose up/down)
        rb.AddTorque(transform.forward * roll); // Roll (Tilting)
    }
}