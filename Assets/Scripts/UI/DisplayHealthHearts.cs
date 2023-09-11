using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealthHearts : MonoBehaviour {

    int maxHealth = 0;

    public void OnHealthChanged(int health) {
        if (maxHealth == 0) maxHealth = health;

        GetComponent<Image>().fillAmount = (float) health / (float) maxHealth;
    }
}
