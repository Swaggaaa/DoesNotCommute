using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(transform.forward * moveVertical * speed);
        rb.AddTorque(transform.up * moveHorizontal * rotation);
    }

}
