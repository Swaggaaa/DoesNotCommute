using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCrashCar : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.isTrigger)
            return;

        float damage = (GetComponent<Rigidbody>().velocity.sqrMagnitude / GetComponent<PlayerController>().maxVelocity) * (GetComponent<PlayerController>().maxHealth / 2);
        Debug.Log(damage, null);
        GetComponent<PlayerController>().Health -= damage;
        
    }
}
