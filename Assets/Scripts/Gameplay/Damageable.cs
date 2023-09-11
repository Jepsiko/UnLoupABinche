using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {

    public int health = 3;
    public float secondsImmune = 2.0f;

    public Material defaultMaterial;
    public Material flashingMaterial;
    
    [System.Serializable] public class IntEvent : UnityEvent<int> {}
	public IntEvent OnHealthChangedEvent;
	public UnityEvent OnDeathEvent;

    void Start() {
		if (OnHealthChangedEvent == null)
			OnHealthChangedEvent = new IntEvent();
            OnHealthChangedEvent.Invoke(health);

		if (OnDeathEvent == null)
			OnDeathEvent = new UnityEvent();
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
        OnHealthChangedEvent.Invoke(health);
        StartCoroutine(ImmuneToDamage());
        if (health <= 0) {
            OnDeathEvent.Invoke();
        }
    }

    IEnumerator ImmuneToDamage() {
        gameObject.layer = LayerMask.NameToLayer("Immune");
        GetComponent<SpriteRenderer>().material = flashingMaterial;
        yield return new WaitForSeconds(secondsImmune);
        gameObject.layer = LayerMask.NameToLayer("Player");
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
}
