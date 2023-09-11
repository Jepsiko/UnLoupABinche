using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnCollision : MonoBehaviour {

    public int damageAmount;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Damageable>().TakeDamage(damageAmount);
        }
    }
}
