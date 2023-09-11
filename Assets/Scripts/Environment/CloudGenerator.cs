using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    public Transform center;
    public GameObject cloudPrefab;

    [Header("Spawn Parameters")]
    [Range(0, 1)] public float density = 0.5f;
    public float speedFactor = 0.5f;

    [Header("Shape")]
    public float width = 30.0f;
    public float lowHeight = 16.0f;
    public float midHeight = 20.0f;
    public float highHeight = 26.0f;
    float[] heights;
    public float heightVariation = 2.0f;

    [Header("Speed")]
    public float initialSpeed = 4.0f;
    public float speedVariation = 0.2f;
    [Range(0, 1)] public float parallaxEffect = 0.5f;

    [Space(10)]
    public List<Sprite> cloudSprites;

    // Start is called before the first frame update
    void Start() {
        heights = new float[3] {lowHeight, midHeight, highHeight};
        PopulateClouds();
    }

    void PopulateClouds() {
        const int maxNumberClouds = 200;
        for (int i = 0; i < maxNumberClouds*density; i++) {
            SpawnCloud(i);
        }
    }

    void SpawnCloud(int id) {
        int randomHeight = Random.Range(0, 3);
        float height = heights[randomHeight] + Random.Range(-heightVariation/2, heightVariation/2);

        float x = center.position.x - width/2 + Random.Range(0.0f, width);

        GameObject cloud = Instantiate(cloudPrefab, new Vector3(x, height, 0), Quaternion.identity);
        cloud.name = "cloud" + id;
        cloud.transform.SetParent(transform);
        
        float speed = initialSpeed + Random.Range(-speedVariation/2, speedVariation/2);
        for (int i = 0; i < randomHeight; i++) {
            speed /= 1 + parallaxEffect;
        }
        cloud.GetComponent<MoveConstantSpeed>().speed = -speed;

        int randomCloud = Random.Range(0, cloudSprites.Count);
        Sprite cloudSprite = cloudSprites[randomCloud];
        cloud.GetComponent<SpriteRenderer>().sprite = cloudSprite;
        cloud.GetComponent<SpriteRenderer>().sortingOrder = (int) (speed*10000);

        cloud.GetComponent<LoopXAxis>().center = center;
        cloud.GetComponent<LoopXAxis>().maxDistance = width/2;
    }

    void OnDrawGizmos() {
        float x1 = center.position.x - width/2;
        float x2 = center.position.x + width/2;

        float y1 = lowHeight - heightVariation/2;
        float y2 = highHeight + heightVariation/2;

        // Draw lines for the 3 heights
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(x1, lowHeight, 0), new Vector3(x2, lowHeight, 0));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(x1, midHeight, 0), new Vector3(x2, midHeight, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(x1, highHeight, 0), new Vector3(x2, highHeight, 0));

        // Draw clouds boundaries
        Vector3[] points = new Vector3[4] {
            new Vector3(x1, y1, 0),
            new Vector3(x2, y1, 0),
            new Vector3(x2, y2, 0),
            new Vector3(x1, y2, 0)
        };
        
        Gizmos.color = Color.gray;
        for (int i = 0; i < 4; i++)
            Gizmos.DrawLine(points[i], points[(i+1)%4]);
    }
}
