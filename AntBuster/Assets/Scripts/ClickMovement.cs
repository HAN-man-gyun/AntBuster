using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    public GameObject camera1;
    public GameObject camera2;
    //SetActive�ϱ����� GameObject�� ��������
    private Animator animator;
    private NavMeshAgent agent;

    private bool isMove;
    //�ִϸ��̼� �Ķ���Ͱ�
    private void Awake()
    {
        camera= Camera.main;
        //���콺 ��ġ�� ���彺���̽��� ��ġ�� �ٲٱ����ؼ� 
        animator = GetComponent<Animator>();
        //�ִϸ����� �Ķ���͸� �ٲٱ�����
        agent = GetComponent<NavMeshAgent>();
        //�׺���̼��� ��������
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetMouseButton(1))
        {//���콺 �����ʹ�ư�� Ŭ�������� ���콺Ŀ���� ��ġ�� ã�Ƴ����Լ�
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {//���콺�� ��ġ�� ��ũ�������� ���̷� ��ȯ�ϴ��Լ��� �ְ� ����ĳ��Ʈ�����.
                //out�� hit�� �ݵ�� �Է��� �޾ƾ��Ѵٴ� ���̴�.
                SetDestination(hit.point);
                //���콺 ��ġ�� SetDestination�Լ��� ����
            }
        }

        LookMoveDirection();
    }

    private void SetDestination(Vector3 dest)
    { //  �������� �����ϰ� �ִϸ������� ���¸� �ٲ��ֱ����� �Ķ���Ͱ��� �ٲ�
        agent.SetDestination(dest);
        //NavMesh�� �������� ��������
        //�̹����̾����� agent�� �������� ���⶧���� ���콺Ŭ�����ص� �������� ����.
        isMove = true;
        animator.SetBool("isRun", true);
        Debug.Log("�ٰ��ִ°� �´�?");
    }

    private void LookMoveDirection()
    {//ĳ���͸� ���������� �����̰� �ٶ󺸰��ϴ��Լ�.
      
        if (isMove)
        {//�޸�����������
            if (agent.velocity.magnitude == 0f)
            {//magnitude�� �ӵ������Ѵ�. �� 0�϶��� �����Ѷ����� ���Ѵ�.�������������ߴ��� Ȯ���ϴ��Լ�
                Debug.Log("�������ִ°� �´�?");
                isMove = false;
                animator.SetBool("isRun", false);
                return;
            }
            var dir = new Vector3(agent.steeringTarget.x,transform.position.y,agent.steeringTarget.z)-transform.position;
            //steeringTarget�� �����ڽ��� �����ϴ´�� �� agent�� �˰��ִ�. y���� �������� �ٶ�����Ѵ�.
            //ĳ���Ͱ� ���̰� �ٸ����� ���鼭 �������°��� ���������̴�.
            animator.transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * 5f;
            //normalized�� ����������ȭ�� ���ͱ��̸� 1�� ���� �̵��ӵ��� ���Ը���°��̴�.
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
