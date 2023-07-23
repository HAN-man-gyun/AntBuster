using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Mon : MonoBehaviour
{
    [Header("Ant Status")]
    public int antLevel = 1;
    public int antHealth = 4;
    public float antSpeed = 5f;

    private Rigidbody Monrigidbody = default;

    private void Start()
    {
        Monrigidbody = GetComponent<Rigidbody>();
        Monrigidbody.velocity = Vector3.forward * antSpeed;
    }


    private void Update()
    {
        
    }
    public void Die()
    {
        Debug.Log("죽었다");
        Destroy(gameObject);
        Statics.monsterCount--;
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
            transform.Rotate(Vector3.up, 270, Space.World);
            Vector3 leftDirection = transform.TransformDirection(Vector3.forward);
            Monrigidbody.velocity = leftDirection * antSpeed;
        }
    }
}
