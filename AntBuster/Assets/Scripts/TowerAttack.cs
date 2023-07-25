using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerAttack : MonoBehaviour
{
    [SerializeField]Transform GunBody = null;
    //�߸���Ÿ�� Ʈ������
    [SerializeField] float range = 0f;
    [SerializeField] LayerMask t_layerMask = 0;
    //layerMask ������ ���̾��ũ
    [SerializeField] float spinSpeed = 0f;
    //Balista�� �߰������� ���ư��� �ӵ�
    [SerializeField] float fireRate = 0f;
    //fireRate �߻� �ֱ�
    [SerializeField] GameObject ArrowPrefab = null;
    float currentFireRate;
    //���� ���纯��


    Transform t_target = null;
    //����ª�� ������ Ʈ�������� ���� ����

    void SearchEnemy()
    { //���� �������ִ� ���� ã�� �Լ�
        Collider[] rangeInMons = Physics.OverlapSphere(transform.position, range, t_layerMask);
        //������� �������� �ִ� ��� ���͵��� �迭�� ����
        //OverLapSphere�� Physics �ȿ��ִ� �浹�� �����ϰ� �浹�� ��ü�� �迭�� ��ȯ�ϴ� �޼��� �� OnTrigger�� ��������
        Transform t_shortestTarget = null;
        // ���� ª�� �Ÿ����ִ�Ÿ���� Ʈ������
        if(rangeInMons.Length>0)
        {//�������� �����ִٸ�
            float t_shortestDistance = Mathf.Infinity;
            //���� ���� �Ÿ��� ã�����̱� ������ �⺻���� ���ǹ��Ѵ�� �Ѵ�.
            foreach(Collider t_colTarget in rangeInMons)
            {//���������ִ� ���Ÿ��
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);
                //���� ��ž�� ��ġ���� ������ ��ġ�� �A���� sqrMagnitude �Լ����Ἥ �Ÿ��� ���Ѵ�. 
                if(t_shortestDistance> t_distance)
                {//���� �װŸ��� ���� ����ª�� �Ÿ����� �� ª�ٸ� 
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                    //��ü
                }
            }
        }

        t_target = t_shortestTarget;
        //���� ª�� ��ġ���ִ� ���� Ʈ�������� ����
    }
    void Start()
    {
        currentFireRate = fireRate; //���� 
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
        //0.5���ֱ�� �ݺ�
    }

    
    void Update()
    {
        if(t_target ==null)
        { //��������� ���ٸ�
            GunBody.Rotate(new Vector3(0, 45, 0)*Time.deltaTime);
            //�߸���Ÿ�� y�� �������� ��� ������. 
        }
        else
        {
            Quaternion t_lookRotation = Quaternion.LookRotation(t_target.position);
            //Ÿ���� �ٶ󺸰� �����  ȸ�������� �����ϴ� �Լ� LookRotation
            Vector3 t_euler = Quaternion.RotateTowards(GunBody.rotation, t_lookRotation, spinSpeed * Time.deltaTime).eulerAngles;
            //RotateToward�� a�������� b�������� c���ǵ�� ȸ���ϰ� ����� ȸ������ �����ϴ��Լ�. eulerAngles�� �Ἥ Quaterion��
            //Vector�� ��ȯ
            GunBody.rotation =Quaternion.Euler(0,t_euler.y,0);
            //y������������ �������������� y�ุ�ݿ��� ���ʹϿ����� ��ȯ
            //y�ุ�� �����̰� ��������� 

            Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0);
            //�߸���Ÿ�� �����ؾߵ� �������� 
            if(Quaternion.Angle(GunBody.rotation, t_fireRotation)<0.3f)
            {//���� ������ ����� �����ؾ��� ������ ������ �������� 0.3�̸��϶�  
                currentFireRate -=Time.deltaTime;
                //���纯���� 1�ʿ� 1�������ϴٰ�
                if(currentFireRate <=0)
                { // 0���� �۰ų� �������� 
                    currentFireRate = fireRate;
                    //���纯���� �ʱ�ȭ�����ְ�
                    Debug.Log("�߻�!!");
                    GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
                    Arrow.transform.LookAt(t_target);
                }
            }
        }
    }
}
