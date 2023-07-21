using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player = default;
    private float speed = 10f;
    private Animator animator;
    private bool isRun = false;
    public 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        if (zinput < 0)
        {
            
            Quaternion a  =  Quaternion.Euler(new Vector3(0,180f,0));
            transform.rotation = a;
        }
        else if (xinput > 0)
        {
            Quaternion a = Quaternion.Euler(new Vector3(0, 90f, 0));
            transform.rotation = a;
        }
        else if (xinput < 0)
        {
            Quaternion a = Quaternion.Euler(new Vector3(0, 270f, 0));
            transform.rotation = a;
        }
        else if(zinput > 0)
        {
            Quaternion a = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.rotation = a;
        }


        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        player.velocity = newVelocity;
        if(player.velocity==Vector3.zero)
        {
            isRun = false;
            animator.SetBool("isRun", isRun);
        }
        else
        {
            isRun = true;
            animator.SetBool("isRun", isRun);
        }
    }

    public float GetRotation()
    {
        return player.transform.rotation.y;
    }
}
