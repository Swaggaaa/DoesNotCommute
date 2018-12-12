using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCrashCar : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.isTrigger || (collision.gameObject.layer == LayerMask.NameToLayer("Street") &&
                ((Mathf.Abs(transform.localEulerAngles.x) < 90 || Mathf.Abs(transform.localEulerAngles.x) > 270) &&
                (Mathf.Abs(transform.localEulerAngles.z) < 75 || Mathf.Abs(transform.localEulerAngles.z) > 285))))
            return;

        float damage = (GetComponent<Rigidbody>().velocity.magnitude * 10f / GetComponent<PlayerController>().maxVelocity) * (100 / 2);
        Debug.Log(damage, null);
        GetComponent<PlayerController>().Health -= damage;
        
    }
}
