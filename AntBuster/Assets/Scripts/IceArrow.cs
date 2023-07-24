using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class IceArrow : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody rigid = default;
    private int power = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;
        Debug.LogFormat("{0}",transform.position);
        Destroy(gameObject,10);
    }

    private void Update()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster") 
        {
            Mon monster = other.GetComponent<Mon>();
            monster.antHealth -= power;
            
            if(monster.antHealth<=0)
            {
                monster.Die();
            }
            Destroy(gameObject);
        }
    }
}
