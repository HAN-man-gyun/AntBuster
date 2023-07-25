using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonSpawner : MonoBehaviour
{
    //오브젝트풀링
    public static MonSpawner instance;
    public GameObject MonPrefab = default;
    //몬스터 프리팹
    public Queue<GameObject> Queue = new Queue<GameObject>();
    //미리 몬스터를 담아둘 Queue
    public Queue<GameObject> Rest = new Queue<GameObject>();
    // 못잡은 몬스터를 담아둘 Rest
    private Vector3 moveVector;
    //몬스터들의 벡터
    public int monCount=0;
    //몬스터 카운트
    private int monMaxCount=20;
    //최대 소환갯수
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //인스턴스 할당
        for (int i = 0; i < 20; i++)
        {
            GameObject t_object = Instantiate(MonPrefab, Vector3.zero, Quaternion.identity);
            Queue.Enqueue(t_object);
            t_object.SetActive(false);
            //몬스터들을 생성후 큐에 넣고 비활성화
            
        }
        monCount = 0;
        monMaxCount = 20;
        StartCoroutine(MonsterSpawn());
        //코루틴 시작
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void InsertQueue(GameObject v_object)
    {   //다시 큐에 집어넣는함수
        Debug.Log("인서트가 된다");
        Queue.Enqueue(v_object);
        v_object.SetActive(false);
        //비활성화
    }

    public GameObject GetQueue()
    {   //큐에서 꺼내오는함수
        GameObject t_object = Queue.Dequeue();
        t_object.SetActive(true);
        //활성화
        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while(true)
        {
            if(Queue.Count !=0 && monCount < monMaxCount)
            { //큐에몬스터가 하나도 없는 상태가 아니면서 최대소환갯수를넘지 않았을때 
                GameObject t_object = GetQueue();
                //큐에서 몬스터를 받아옴
                Rest.Enqueue(t_object);
                //Rest에 하나씩 집어넣음
                t_object.transform.position = gameObject.transform.position;
                //꺼낸 몬스터들의 위치를 포탈의 위치로 옮김
                Statics.monsterCount++;
                //총몬스터의 숫자를 올림
                monCount++;
                //소환된몬스터의 숫자를 올림.
            }
            yield return new WaitForSeconds(1.5f);
            //1.5초후에 다시 반복
        }
        
    }

   

}
