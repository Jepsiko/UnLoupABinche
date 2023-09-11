using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour {

    public void OnDeath() {
        Destroy(gameObject);
    }
}
