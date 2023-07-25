using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour,IPointerDownHandler,IDragHandler
{   //OnPointerDown�� �������� IPointerDownHandler, OnDrag�� �������� IDragHandler
    public GameObject TowerPrefab;
    public Camera subCamera;
    private GameObject tower;

    public void OnPointerDown(PointerEventData eventData)
    {   //��ư�� Ŭ�������� 
        if (Statics.gold >= 100)
        { //��尡 100���� ũ�ų� ���ٸ�
            tower = Instantiate(TowerPrefab, Vector3.zero, Quaternion.identity);
            //Ÿ���� ������
            Statics.gold -= 100;
            //��带 100����
        }
    }
    public void OnDrag(PointerEventData eventData)
    {   //�巡���ϴµ��߿�
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            subCamera.WorldToScreenPoint(transform.position).z);
        //Vector3�� �� ���� ���콺�������� ���Ͱ��� ��
        Vector3 worldPosition = subCamera.ScreenToWorldPoint(position);
        //p
        tower.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
    }

}
