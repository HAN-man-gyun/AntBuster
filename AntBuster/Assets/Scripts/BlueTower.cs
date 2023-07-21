using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTower : MonoBehaviour
{
    [Header("Tower Status")]
    private string TowerName = "iceTower";
    private int TowerPrice = 4;

    public GameObject ArrowPrefab = default;
    private Transform target = default;
    private float spawnRate = 1f;
    private float timeAfterSpawn = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("������");
        if (other.tag == "Monster")
        {
            target = other.GetComponent<Mon>().transform;
            timeAfterSpawn += Time.deltaTime;
            if (spawnRate <= timeAfterSpawn)
            {
                Debug.Log("�����Ϸ�");
                transform.LookAt(target);
                timeAfterSpawn = 0;
                GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
                Debug.LogFormat("{0}", target.transform.position);
                Arrow.transform.LookAt(target);
            }
        }
    }
}
