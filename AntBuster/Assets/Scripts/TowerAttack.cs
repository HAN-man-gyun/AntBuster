using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerAttack : MonoBehaviour
{
    [SerializeField]Transform GunBody = null;
    //발리스타의 트랜스폼
    [SerializeField] float range = 0f;
    [SerializeField] LayerMask t_layerMask = 0;
    //layerMask 감지할 레이어마스크
    [SerializeField] float spinSpeed = 0f;
    //Balista가 발견했을때 돌아가는 속도
    [SerializeField] float fireRate = 0f;
    //fireRate 발사 주기
    [SerializeField] GameObject ArrowPrefab = null;
    float currentFireRate;
    //현재 연사변수


    Transform t_target = null;
    //가장짧은 몬스터의 트랜스폼을 담을 변수

    void SearchEnemy()
    { //가장 가까이있는 적을 찾는 함수
        Collider[] rangeInMons = Physics.OverlapSphere(transform.position, range, t_layerMask);
        //구모양의 범위내에 있는 모든 몬스터들을 배열에 담음
        //OverLapSphere는 Physics 안에있는 충돌을 감지하고 충돌한 물체를 배열로 반환하는 메서드 즉 OnTrigger와 같은역할
        Transform t_shortestTarget = null;
        // 가장 짧은 거리에있는타겟의 트랜스폼
        if(rangeInMons.Length>0)
        {//범위내에 적이있다면
            float t_shortestDistance = Mathf.Infinity;
            //가장 작은 거리를 찾을것이기 때문에 기본값은 양의무한대로 한다.
            foreach(Collider t_colTarget in rangeInMons)
            {//범위내에있는 모든타겟
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);
                //현재 포탑의 위치에서 몬스터의 위치를 뺸값을 sqrMagnitude 함수를써서 거리를 구한다. 
                if(t_shortestDistance> t_distance)
                {//만약 그거리가 현재 가장짧은 거리보다 더 짧다면 
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                    //교체
                }
            }
        }

        t_target = t_shortestTarget;
        //가장 짧은 위치에있는 적의 트랜스폼을 저장
    }
    void Start()
    {
        currentFireRate = fireRate; //현재 
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
        //0.5초주기로 반복
    }

    
    void Update()
    {
        if(t_target ==null)
        { //가까운적이 없다면
            GunBody.Rotate(new Vector3(0, 45, 0)*Time.deltaTime);
            //발리스타를 y축 기준으로 계속 돌린다. 
        }
        else
        {
            Quaternion t_lookRotation = Quaternion.LookRotation(t_target.position);
            //타겟을 바라보게 만드는  회전지점을 리턴하는 함수 LookRotation
            Vector3 t_euler = Quaternion.RotateTowards(GunBody.rotation, t_lookRotation, spinSpeed * Time.deltaTime).eulerAngles;
            //RotateToward는 a지점에서 b지점까지 c스피드로 회전하게 만드는 회전값을 리턴하는함수. eulerAngles를 써서 Quaterion을
            //Vector로 변환
            GunBody.rotation =Quaternion.Euler(0,t_euler.y,0);
            //y축을기준으로 움직여야함으로 y축만반영후 쿼터니온으로 변환
            //y축만을 움직이게 만들기위해 

            Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0);
            //발리스타가 조준해야될 최종방향 
            if(Quaternion.Angle(GunBody.rotation, t_fireRotation)<0.3f)
            {//현재 포신의 방향과 조준해야할 각도의 방향의 각도차가 0.3미만일때  
                currentFireRate -=Time.deltaTime;
                //연사변수가 1초에 1씩감소하다가
                if(currentFireRate <=0)
                { // 0보다 작거나 같아지면 
                    currentFireRate = fireRate;
                    //연사변수를 초기화시켜주고
                    Debug.Log("발사!!");
                    GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
                    Arrow.transform.LookAt(t_target);
                }
            }
        }
    }
}
