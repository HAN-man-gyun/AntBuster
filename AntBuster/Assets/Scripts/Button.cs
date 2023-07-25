using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour,IPointerDownHandler,IDragHandler
{   //OnPointerDown을 쓰기위해 IPointerDownHandler, OnDrag를 쓰기위해 IDragHandler
    public GameObject TowerPrefab;
    //타워프리팹
    public Camera subCamera;
    //서브카메라
    private GameObject tower;
    //게임오브젝트 객체 타워
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
        //Vector3값 에 현재 마우스포인터의 백터값을 줌 z는 스크린스페이스에 존재하지 않기때문에 
        //subCamera에서 위치를 월드스페이스로바꾼다음에 z값을 주었다.
        Vector3 worldPosition = subCamera.ScreenToWorldPoint(position);
        //position을 서브카메라에서 전부 월드포지션으로 바꿨다.
        tower.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
        //y축이 2d에서 본대로 움직이면 곤란하기에 0.5f고정값으로 주었고 worldPosition에서 x,z를 사용하여
        //타워의 포지션을 계속 움직이게했다.
    }

}
