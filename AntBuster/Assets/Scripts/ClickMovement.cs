using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    public GameObject camera1;
    public GameObject camera2;
    private Animator animator;
    private NavMeshAgent agent;

    private bool isMove;
    private Vector3 destination;
    private void Awake()
    {
        camera= Camera.main;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        LookMoveDirection();
    }

    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
        animator.SetBool("isRun", true);
        Debug.Log("뛰고있는게 맞니?");
    }

    private void LookMoveDirection()
    {
      
        if (isMove)
        {
            if (agent.velocity.magnitude == 0f)
            {
                Debug.Log("도착해있는게 맞니?");
                isMove = false;
                animator.SetBool("isRun", false);
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x,transform.position.y,agent.steeringTarget.z)-transform.position;
            animator.transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * 5f;
            
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Shop")
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Shop")
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }


}
