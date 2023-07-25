using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonSpawner : MonoBehaviour
{
    //������ƮǮ��
    public static MonSpawner instance;
    public GameObject MonPrefab = default;
    //���� ������
    public Queue<GameObject> Queue = new Queue<GameObject>();
    //�̸� ���͸� ��Ƶ� Queue
    public Queue<GameObject> Rest = new Queue<GameObject>();
    // ������ ���͸� ��Ƶ� Rest
    private Vector3 moveVector;
    //���͵��� ����
    public int monCount=0;
    //���� ī��Ʈ
    private int monMaxCount=20;
    //�ִ� ��ȯ����
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //�ν��Ͻ� �Ҵ�
        for (int i = 0; i < 20; i++)
        {
            GameObject t_object = Instantiate(MonPrefab, Vector3.zero, Quaternion.identity);
            Queue.Enqueue(t_object);
            t_object.SetActive(false);
            //���͵��� ������ ť�� �ְ� ��Ȱ��ȭ
            
        }
        monCount = 0;
        monMaxCount = 20;
        StartCoroutine(MonsterSpawn());
        //�ڷ�ƾ ����
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void InsertQueue(GameObject v_object)
    {   //�ٽ� ť�� ����ִ��Լ�
        Debug.Log("�μ�Ʈ�� �ȴ�");
        Queue.Enqueue(v_object);
        v_object.SetActive(false);
        //��Ȱ��ȭ
    }

    public GameObject GetQueue()
    {   //ť���� ���������Լ�
        GameObject t_object = Queue.Dequeue();
        t_object.SetActive(true);
        //Ȱ��ȭ
        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while(true)
        {
            if(Queue.Count !=0 && monCount < monMaxCount)
            { //ť�����Ͱ� �ϳ��� ���� ���°� �ƴϸ鼭 �ִ��ȯ���������� �ʾ����� 
                GameObject t_object = GetQueue();
                //ť���� ���͸� �޾ƿ�
                Rest.Enqueue(t_object);
                //Rest�� �ϳ��� �������
                t_object.transform.position = gameObject.transform.position;
                //���� ���͵��� ��ġ�� ��Ż�� ��ġ�� �ű�
                Statics.monsterCount++;
                //�Ѹ����� ���ڸ� �ø�
                monCount++;
                //��ȯ�ȸ����� ���ڸ� �ø�.
            }
            yield return new WaitForSeconds(1.5f);
            //1.5���Ŀ� �ٽ� �ݺ�
        }
        
    }

   

}
