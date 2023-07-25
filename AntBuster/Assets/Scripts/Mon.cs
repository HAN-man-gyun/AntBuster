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
        //스테이지 올라갈때마다 풀피로 만들어야한다.
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
        //HP바처리
    }
    public void Die()
    {
        // 몬스터가 죽었을 때의 상태를 초기화한다.

        Debug.Log("죽었다");

        Debug.LogFormat("죽을 때 몬스터의 Rotation Before : {0}", gameObject.transform.rotation.eulerAngles);
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        Monrigidbody.velocity = Vector3.forward * antSpeed;
        Debug.LogFormat("죽을 때 몬스터의 Rotation After : {0}", gameObject.transform.rotation.eulerAngles);
        //여기서 죽을때 몬스터의 벡터와 로테이션값을 원래대로 돌려놓는다.
        MonSpawner.instance.InsertQueue(gameObject);
        //큐에 다시 넣는다.
        gameObject.SetActive(false);
        //비활성화한다.
        Statics.gold += 10;
        //몬스터를 잡았으니 10골드추가하고
        Statics.monsterCount--;
        //총몬스터를 1줄인다.

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Turn")
        {
            Debug.Log("턴을하자");
            Vector3 centerPosition = other.transform.position;
            transform.position = centerPosition;
            //접촉한 물체의 정중앙에 닿았을때 턴을하고 싶어
            Debug.Log("중앙을 확인했나?");
            //Quaternion a = Quaternion.Euler(new Vector3(0, 270f, 0));
            //transform.rotation = a;
            transform.Rotate(Vector3.up, 270);//, Space.World
            Vector3 leftDirection = transform.TransformDirection(Vector3.forward);
            Monrigidbody.velocity = leftDirection * antSpeed;
        }
    }
}
