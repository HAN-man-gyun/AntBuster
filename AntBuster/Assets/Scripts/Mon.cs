using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Mon : MonoBehaviour
{
    static public Mon instance;
    [Header("Ant Status")]
    public int antLevel = 1;
    public int antHealth = 4;
    public float antSpeed = 20f;

    private Rigidbody Monrigidbody = default;

    private void OnEnable()
    {
        Debug.Log("��ġ�� �ʱ�ȭ�Ѵ�");

        //transform.rotation = Quaternion.identity;
    }
    private void Start()
    {
        instance = this;
        Monrigidbody = GetComponent<Rigidbody>();
        Monrigidbody.velocity = Vector3.forward * antSpeed;
    }


    private void Update()
    {
        
    }
    public void Die()
    {
        // ���Ͱ� �׾��� ���� ���¸� �ʱ�ȭ�Ѵ�.

        Debug.Log("�׾���");
        //transform.Rotate(Vector3.up,-180 ,Space.World);
        //transform.Rotate(0, 90, 0);
        Debug.LogFormat("���� �� ������ Rotation Before : {0}", gameObject.transform.rotation.eulerAngles);
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        Monrigidbody.velocity = Vector3.forward * antSpeed;
        Debug.LogFormat("���� �� ������ Rotation After : {0}", gameObject.transform.rotation.eulerAngles);
        MonSpawner.instance.InsertQueue(gameObject);
        gameObject.SetActive(false);
        
        Statics.monsterCount--;

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Turn")
        {
            Debug.Log("��������");
            Vector3 centerPosition = other.transform.position;
            transform.position = centerPosition;
            //������ ��ü�� ���߾ӿ� ������� �����ϰ� �;�
            Debug.Log("�߾��� Ȯ���߳�?");
            //Quaternion a = Quaternion.Euler(new Vector3(0, 270f, 0));
            //transform.rotation = a;
            transform.Rotate(Vector3.up, 270, Space.World);
            Vector3 leftDirection = transform.TransformDirection(Vector3.forward);
            Monrigidbody.velocity = leftDirection * antSpeed;
        }
    }
}
