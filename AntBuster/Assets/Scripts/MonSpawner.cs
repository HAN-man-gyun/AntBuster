using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonSpawner : MonoBehaviour
{
    public GameObject MonPrefab = default;
    public float spawnRate = 1.5f;
    public int MonCount = 0;
    public int MonMaxCount = 6;
    private float timeAfterSpawn = default;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        MonCount = 0;
        MonMaxCount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (spawnRate <= timeAfterSpawn)
        {
            timeAfterSpawn = 0;
            GameObject Mon = Instantiate(MonPrefab, transform.position, transform.rotation);
            MonCount++;
        }
    }
}
