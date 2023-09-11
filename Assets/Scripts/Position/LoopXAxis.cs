using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopXAxis : MonoBehaviour
{
    public Transform center;
    public float maxDistance;
    public bool beginOutside = false;

    bool hasBeenInside = false;

    // Update is called once per frame
    void Update()
    {
        if (beginOutside && !hasBeenInside) {
            if (transform.position.x >= center.position.x - maxDistance && transform.position.x <= center.position.x + maxDistance)
                hasBeenInside = true;
        }

        else {
            if (transform.position.x < center.position.x - maxDistance)
                transform.position = new Vector3(transform.position.x + maxDistance*2, transform.position.y, transform.position.z);
            else if (transform.position.x > center.position.x + maxDistance)
                transform.position = new Vector3(transform.position.x - maxDistance*2, transform.position.y, transform.position.z);
        }
    }
}
