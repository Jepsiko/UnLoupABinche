using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOranges : MonoBehaviour
{

    public GameObject orangePrefab;

    [Header("Spawn Area")]
    public float width;

    [Header("Spawn parameters")]
    [Range(0f, 90f)]
    public float angle;
    public float strength;

    private int frame;

    void Start()
    {
    }

    void Update()
    {
        if (frame%40 == 0)
        {
            SpawnOrange();
        }
        frame++;
    }

    void SpawnOrange()
    {
        float x1 = transform.position.x - width / 2;
        float x2 = transform.position.x + width / 2;

        Vector3 position = new Vector3(Random.Range(x1, x2), 0);
        GameObject orange = Instantiate(orangePrefab, position, Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward), transform);
        Vector3 direction = Quaternion.AngleAxis(Random.Range(-angle, angle), Vector3.forward) * Vector3.up;
        orange.GetComponent<Rigidbody2D>().AddForce(direction * strength, ForceMode2D.Impulse);
    }

    void OnDrawGizmos()
    {
        float x1 = transform.position.x - width / 2;
        float x2 = transform.position.x + width / 2;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(x1, 0, 0), new Vector3(x2, 0, 0));

        Gizmos.DrawLine(new Vector3(x1, 0, 0), new Vector3(x1 - strength * Mathf.Sin(Mathf.Deg2Rad * angle), strength * Mathf.Cos(Mathf.Deg2Rad * angle), 0));
        Gizmos.DrawLine(new Vector3(x2, 0, 0), new Vector3(x2 + strength * Mathf.Sin(Mathf.Deg2Rad * angle), strength * Mathf.Cos(Mathf.Deg2Rad * angle), 0));
    }
}
