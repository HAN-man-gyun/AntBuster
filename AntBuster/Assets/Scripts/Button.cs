using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour,IPointerDownHandler,IDragHandler
{   //OnPointerDown을 쓰기위해 IPointerDownHandler, OnDrag를 쓰기위해 IDragHandler
    public GameObject TowerPrefab;
    public Camera subCamera;
    private GameObject tower;

    public void OnPointerDown(PointerEventData eventData)
    {   //버튼을 클릭했을때 
        if (Statics.gold >= 100)
        { //골드가 100보다 크거나 같다면
            tower = Instantiate(TowerPrefab, Vector3.zero, Quaternion.identity);
            //타워를 생성함
            Statics.gold -= 100;
            //골드를 100깎음
        }
    }
    public void OnDrag(PointerEventData eventData)
    {   //드래그하는도중에
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            subCamera.WorldToScreenPoint(transform.position).z);
        //Vector3값 에 현재 마우스포인터의 백터값을 줌
        Vector3 worldPosition = subCamera.ScreenToWorldPoint(position);
        //p
        tower.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
    }

}
