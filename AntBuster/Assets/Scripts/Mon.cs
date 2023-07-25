using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mon : MonoBehaviour
{
    static public Mon instance;

    public GameObject healthBar;
    [Header("Ant Status")]
    public float antHealth = 0;
    public float antSpeed = 20f;

    private Rigidbody Monrigidbody = default;

    private void OnEnable()
    {
        antHealth = Statics.MaxHp;
    }
    private void Start()
    {
        instance = this;
        Monrigidbody = GetComponent<Rigidbody>();
        Monrigidbody.velocity = Vector3.forward * antSpeed;
    }


    private void Update()
    {
        healthBar.GetComponent<Image>().fillAmount = antHealth / Statics.MaxHp;
    }
    public void Die()
    {
        // ���Ͱ� �׾��� ���� ���¸� �ʱ�ȭ�Ѵ�.

        Debug.Log("�׾���");

        Debug.LogFormat("���� �� ������ Rotation Before : {0}", gameObject.transform.rotation.eulerAngles);
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        Monrigidbody.velocity = Vector3.forward * antSpeed;
        Debug.LogFormat("���� �� ������ Rotation After : {0}", gameObject.transform.rotation.eulerAngles);
        MonSpawner.instance.InsertQueue(gameObject);
        gameObject.SetActive(false);
        Statics.gold += 10;
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
