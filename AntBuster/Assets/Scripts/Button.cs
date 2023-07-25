using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour,IPointerDownHandler,IDragHandler
{
    public GameObject TowerPrefab;
    public Camera subCamera;
    private GameObject tower;
    void Update()
    {
        
          
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Statics.gold >= 100)
        {
            tower = Instantiate(TowerPrefab, Vector3.zero, Quaternion.identity);
            Statics.gold -= 100;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, subCamera.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = subCamera.ScreenToWorldPoint(position);
        tower.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
    }

}
