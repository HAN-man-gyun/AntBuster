using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    GameObject hpPrefab =default(GameObject);

    List<Transform> transObjectList = new List<Transform>();
    List<GameObject> hpBarList = new List<GameObject>();
    Camera cam= default;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Monster");
        for(int i=0; i<targetObjects.Length; i++)
        {
            Debug.LogFormat("{0}",i);
            transObjectList.Add(targetObjects[i].transform);
            GameObject  transHpBar = Instantiate(hpPrefab, targetObjects[i].transform.position,Quaternion.identity,transform);
            hpBarList.Add(transHpBar);
        }
    }
    // 이방법은 오브젝트 풀링을 사용해야만 적용할수있다???
    // 오브젝트가 
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<hpBarList.Count;i++)
        {
            hpBarList[i].transform.position = cam.WorldToScreenPoint(transObjectList[i].position + new Vector3(0, 1.15f, 0));
        }
    }
}
