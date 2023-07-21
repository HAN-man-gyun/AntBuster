using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTower : MonoBehaviour
{
    [Header("Tower Status")]
    private string TowerName = "RedTower";
    private int TowerPrice = 4;
    private Transform target = default;
    public GameObject ArrowPrefab = default;
   
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    void Start()
    {
        timeAfterSpawn = 0f;
        target = FindObjectOfType<Mon>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (spawnRate <= timeAfterSpawn)
        {
            timeAfterSpawn = 0;
            GameObject Arrow = Instantiate(ArrowPrefab, transform.position, transform.rotation);
            transform.LookAt(target);
        }
    }
}
