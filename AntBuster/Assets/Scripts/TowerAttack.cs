using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerAttack : MonoBehaviour
{
    [SerializeField]Transform GunBody = null;
    [SerializeField] float range = 0f;
    [SerializeField] LayerMask t_layerMask = 0;
    [SerializeField] float spinSpeed = 0f;
    [SerializeField] float fireRate = 0f;
    [SerializeField] GameObject ArrowPrefab = null;
    float currentFireRate;


    Transform t_target = null;
    

    void SearchEnemy()
    {
        Collider[] rangeInMons = Physics.OverlapSphere(transform.position, range, t_layerMask);
        Transform t_shortestTarget = null;
        if(rangeInMons.Length>0)
        {
            float t_shortestDistance = Mathf.Infinity;
            foreach(Collider t_colTarget in rangeInMons)
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);
                if(t_shortestDistance> t_distance)
                {
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                }
            }
        }

        t_target = t_shortestTarget;
    }
    void Start()
    {
        currentFireRate = fireRate;
        InvokeRepeating("SearchEnemy", 0f, 0.5f);
    }

    
    void Update()
    {
        if(t_target ==null)
        {
            GunBody.Rotate(new Vector3(0, 45, 0)*Time.deltaTime);
        }
        else
        {
            Quaternion t_lookRotation = Quaternion.LookRotation(t_target.position);
            Vector3 t_euler = Quaternion.RotateTowards(GunBody.rotation, t_lookRotation, spinSpeed * Time.deltaTime).eulerAngles;
            GunBody.rotation =Quaternion.Euler(0,t_euler.y,0);

            Quaternion t_fireRotation = Quaternion.Euler(0, t_lookRotation.eulerAngles.y, 0);
            if(Quaternion.Angle(GunBody.rotation, t_fireRotation)<0.3f)
            {
                currentFireRate -=Time.deltaTime;
                if(currentFireRate <=0)
                {
                    currentFireRate = fireRate;
                    Debug.Log("น฿ป็!!");
                    GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
                    Arrow.transform.LookAt(t_target);
                }
            }
        }
    }

    public float GetDistance(Vector3 src, Vector3 dest)
    {
        float dist = Vector3.Distance(src, dest);
        return dist;
    }
}
