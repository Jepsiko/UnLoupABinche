using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOnMove : MonoBehaviour
{
    [Range (0.1f, 1.0f)] public float fadeSpeed = 1f;

    bool faded = false;
    Image image;
    Color color;

    void Start() {
        image = GetComponent<Image>();
        color = image.color;
    }

    public void OnMoving() {
        if (!faded) StartCoroutine(Fade());
    }

    IEnumerator Fade() {
        faded = true;
        yield return new WaitForSeconds(0.5f);
        float alpha = color.a;
        while (alpha > 0.0f) {
            alpha -= fadeSpeed * Time.deltaTime;
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
