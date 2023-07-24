using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonSpawner : MonoBehaviour
{
    public static MonSpawner instance;
    public GameObject MonPrefab = default;
    public Queue<GameObject> Queue = new Queue<GameObject>();
    public Queue<GameObject> Rest = new Queue<GameObject>();
    private Vector3 moveVector;
    public int monCount=0;
    private int monMaxCount=20;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < 20; i++)
        {
            GameObject t_object = Instantiate(MonPrefab, Vector3.zero, Quaternion.identity);
            Queue.Enqueue(t_object);
            t_object.SetActive(false);
            monCount = 0;
            monMaxCount = 20;
        }
        StartCoroutine(MonsterSpawn());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void InsertQueue(GameObject v_object)
    {
        Debug.Log("인서트가 된다");
        Queue.Enqueue(v_object);
        v_object.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject t_object = Queue.Dequeue();
        t_object.SetActive(true);

        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while(true)
        {
            if(Queue.Count !=0 && monCount < monMaxCount)
            {
                moveVector = Vector3.forward;
                GameObject t_object = GetQueue();
                Rest.Enqueue(t_object);
                //t_object.transform.Rotate(Vector3.zero);
                //Debug.LogFormat("생성된 몬스터의 Rotation : {0}", t_object.transform.rotation.eulerAngles);
                t_object.transform.position = gameObject.transform.position + moveVector;
                Statics.monsterCount++;
                monCount++;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }

   

}
