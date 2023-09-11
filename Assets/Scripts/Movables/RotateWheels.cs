using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour {

    float rotationSpeed;

    void Start() {
        rotationSpeed = -GetComponent<MoveConstantSpeed>().speed;
        foreach (Transform child in transform) {
            child.GetComponent<RotateConstantSpeed>().rotationSpeed = rotationSpeed;
        }
    }
}
