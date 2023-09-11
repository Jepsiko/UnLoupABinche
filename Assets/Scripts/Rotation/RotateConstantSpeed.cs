using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantSpeed : MonoBehaviour {

    public float rotationSpeed;

    void Update() {
        Vector3 rotationAngle = new Vector3(0, 0, rotationSpeed);
        transform.Rotate(rotationAngle);
    }
}
