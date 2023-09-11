using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnMove : MonoBehaviour {

    void Start() {
        gameObject.SetActive(false);
    }

    public void OnMoving() {
        gameObject.SetActive(true);
    }
}
