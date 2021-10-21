using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject turtlePrefab;

    public float trashSpawnRate;
    public float turtleSpawnRate;

    private float trashLastSpawn = -50;
    private float turtleLastSpawn = -50;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - trashLastSpawn > trashSpawnRate)
        {
            float[] coords = genCoords();
            Instantiate(trashPrefab, new Vector2(coords[0], coords[1]), Quaternion.identity);
            trashLastSpawn = Time.time;
        }

        if (Time.time - turtleLastSpawn > turtleSpawnRate)
        {
            float[] coords = genCoords();
            Instantiate(turtlePrefab, new Vector2(coords[0], coords[1]), Quaternion.identity);
            turtleLastSpawn = Time.time;
        }
    }

    private float[] genCoords()
    {
        float randX = Random.value * 2 - 1;
        float randY = Random.value * 2 - 1;

        return new float[]
        {
            randX * 18, randY * 10
        };
    }
}