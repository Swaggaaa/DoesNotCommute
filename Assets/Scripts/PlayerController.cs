using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxHealth;
    public float maxVelocity;
    public Vector3 centerOfMassModifier;

    //0f - 1f
    public float HealthNormalized
    {
        get
        {
            return Health / maxHealth;
        }
    }

    //0f - maxHealth
    public float Health { get; set; }

    public void UpdateVisualWheel(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
            return;

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void Start()
    {
        Health = maxHealth;
        GetComponent<Rigidbody>().centerOfMass += centerOfMassModifier;
    }

    void Update()
    {
        if (!((Mathf.Abs(transform.localEulerAngles.x) < 135 || Mathf.Abs(transform.localEulerAngles.x) > 225) &&
                (Mathf.Abs(transform.localEulerAngles.z) <= 90 || Mathf.Abs(transform.localEulerAngles.z) >= 270)))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude * 10f <= 1f)
            {
                EventManager.Trigger("RespawnCar");
            }
        }
    }

    void FixedUpdate()
    {
        if (!GlobalValues.Running || GlobalValues.CurrentCar != gameObject)
            return;

        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        if (GetComponent<Rigidbody>().velocity.magnitude * 10f > maxVelocity * HealthNormalized)
            motor = 0;

        foreach (AxleInfo axle in axleInfos)
        {
            if (axle.steering)
            {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
            if (axle.motor)
            {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor;
            }
            UpdateVisualWheel(axle.leftWheel);
            UpdateVisualWheel(axle.rightWheel);
        }

        float stuck = Input.GetAxis("Jump");
        if (stuck != 0f)
        {
            EventManager.Trigger("RespawnCar");
        }


    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}