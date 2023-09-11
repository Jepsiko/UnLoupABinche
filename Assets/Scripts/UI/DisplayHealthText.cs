using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealthText : MonoBehaviour {

    public void OnHealthChanged(int health) {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Remaining Health : " + health;
    }
}
