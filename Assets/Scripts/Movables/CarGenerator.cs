using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour {
    
    public enum Difficulty {
        Easy,
        Normal,
        Hard
    };

    public Transform player;

    [Header("Spawn Parameters")]
    public Difficulty difficulty = Difficulty.Easy;
    public float minimalDistanceBetweenCars = 10;
    public float spawnDistanceFromPlayer = 30;
    public float destroyDistanceFromPlayer = 20;

    [Space(10)]
    public List<GameObject> carPrefabs;
    public List<Material> carMaterials;

    GameObject lastCar;
    Vector3 spawnPoint;
    float nextDistance = 0;

    void Update() {

        spawnPoint = new Vector3(player.position.x + spawnDistanceFromPlayer, 0.5f, 0);
        if (lastCar == null || lastCar.transform.position.x + nextDistance < spawnPoint.x) {
            SpawnCar();
            nextDistance = computeNextDistance();
        }
    }

    float computeNextDistance() {
        int randomMultiplier = 0;
        switch (difficulty) {
            case Difficulty.Easy:
                randomMultiplier = Random.Range(2, 8);
                break;
            case Difficulty.Normal:
                randomMultiplier = Random.Range(1, 6);
                break;
            case Difficulty.Hard:
                randomMultiplier = Random.Range(1, 3);
                break;
        }
        return minimalDistanceBetweenCars * randomMultiplier;
    }

    void SpawnCar() {
        lastCar = Instantiate(carPrefabs[0], spawnPoint, Quaternion.identity);
        lastCar.transform.SetParent(transform);
        
        int randomMaterial = Random.Range(0, carMaterials.Count);
        Material carMaterial = carMaterials[randomMaterial];
        lastCar.GetComponent<SpriteRenderer>().material = carMaterial;

        lastCar.GetComponent<KillWhenTooFarLeft>().target = player;
        lastCar.GetComponent<KillWhenTooFarLeft>().maxDistance = destroyDistanceFromPlayer;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(new Vector3(player.position.x + spawnDistanceFromPlayer, 1.5f, 0), new Vector3(3, 2, 1));
        Gizmos.DrawLine(new Vector3(player.position.x - destroyDistanceFromPlayer, 0, 0), new Vector3(player.position.x - destroyDistanceFromPlayer, 100, 0));
    }
}
