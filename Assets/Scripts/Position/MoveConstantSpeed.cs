using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstantSpeed : MonoBehaviour
{
    public float speed;

    void FixedUpdate() {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }
}
