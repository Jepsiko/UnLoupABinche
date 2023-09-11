using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWhenTooFarLeft : MonoBehaviour {

    public Transform target;
    public float maxDistance;

    void Update() {
        if (target.position.x - transform.position.x > maxDistance) Destroy(transform.gameObject);
    }
}
