using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour {

    public TMP_Text countUI;

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Orange")
        {
            count++;
            countUI.text = count.ToString();
            Destroy(other.gameObject);
        }
    }
}
