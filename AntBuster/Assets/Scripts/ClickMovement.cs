using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    public GameObject camera1;
    public GameObject camera2;
    //SetActive하기위해 GameObject로 선언했음
    private Animator animator;
    private NavMeshAgent agent;

    private bool isMove;
    //애니메이션 파라미터값
    private void Awake()
    {
        camera= Camera.main;
        //마우스 위치를 월드스페이스의 위치로 바꾸기위해서 
        animator = GetComponent<Animator>();
        //애니메이터 파라미터를 바꾸기위해
        agent = GetComponent<NavMeshAgent>();
        //네비게이션을 쓰기위해
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetMouseButton(1))
        {//마우스 오른쪽버튼을 클릭했을때 마우스커서의 위치를 찾아내는함수
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {//마우스의 위치를 스크린의점을 레이로 반환하는함수에 넣고 레이캐스트를쏜다.
                //out은 hit가 반드시 입력을 받아야한다는 뜻이다.
                SetDestination(hit.point);
                //마우스 위치를 SetDestination함수에 넣음
            }
        }

        LookMoveDirection();
    }

    private void SetDestination(Vector3 dest)
    { //  목적지를 세팅하고 애니메이터의 상태를 바꿔주기위해 파라미터값을 바꿈
        agent.SetDestination(dest);
        //NavMesh에 목적지를 설정해줌
        //이문장이없으면 agent가 목적지가 없기때문에 마우스클릭을해도 움직이지 않음.
        isMove = true;
        animator.SetBool("isRun", true);
        Debug.Log("뛰고있는게 맞니?");
    }

    private void LookMoveDirection()
    {//캐릭터를 목적지까지 움직이고 바라보게하는함수.
      
        if (isMove)
        {//달리고있을때만
            if (agent.velocity.magnitude == 0f)
            {//magnitude는 속도를말한다. 즉 0일때는 도착한때임을 뜻한다.목적지에도착했는지 확인하는함수
                Debug.Log("도착해있는게 맞니?");
                isMove = false;
                animator.SetBool("isRun", false);
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x,transform.position.y,agent.steeringTarget.z)-transform.position;
            //steeringTarget은 현재자신의 조종하는대상 즉 agent로 알고있다. y값은 포지션을 바라봐야한다.
            //캐릭터가 높이가 다른곳을 보면서 기울어지는것을 막기위함이다.
            animator.transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * 5f;
            //normalized는 벡터의정규화로 벡터길이를 1로 만들어서 이동속도를 같게만드는것이다.
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
