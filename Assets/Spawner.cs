using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trashPrefab;

    public float spawnRate;

    private float lastSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - lastSpawn > spawnRate)
        {
            Instantiate(trashPrefab, new Vector2(0, 0), Quaternion.identity);
            lastSpawn = Time.time;
        }
    }
}
