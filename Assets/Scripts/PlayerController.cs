using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation;

    private Rigidbody rb;
    private const float multiplier = 10;
    private const float maxSpeed = 12;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed *= rb.mass * multiplier;
        rotation *= rb.mass * multiplier;
        rb.maxAngularVelocity = 1f;
    }

    void FixedUpdate()
    {
        float turningMovement = Input.GetAxis("Horizontal");
        float linearMovement = Input.GetAxis("Vertical");

        if (rb.velocity.z < maxSpeed)
            rb.AddForce(transform.forward * linearMovement * speed);


        Vector3 torqueForce = transform.up * turningMovement * rotation;
        if (linearMovement < 0) torqueForce = -torqueForce;
        rb.AddTorque(torqueForce);

    }

}
