using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent agent;

    // ������Ʈ�� ������
    [SerializeField]
    Transform target;

    private void Awake()
    {
        // ������ ���۵Ǹ� ���� ������Ʈ�� ������ NavMeshAgent ������Ʈ�� �����ͼ� ����
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // �����̽� Ű�� ������ Target�� ��ġ���� �̵��ϴ� ��θ� ����ؼ� �̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������Ʈ���� �������� �˷��ִ� �Լ�
            agent.SetDestination(target.position);
        }
    }
}