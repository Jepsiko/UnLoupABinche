using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWhenTooFar : MonoBehaviour {
    
    public Transform target;
    public float maxDistance;

    void Update() {
        if (Mathf.Abs(transform.position.x - target.position.x) > maxDistance) Destroy(transform.gameObject);
    }
}
