using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour
{
    public GameObject objectToCreate; // 생성할 3D 오브젝트 프리팹
    private GameObject spawnedObject; // 생성된 오브젝트

    private bool isCreating = false; // 버튼을 클릭하여 오브젝트를 생성하는 중인지 여부

    void Update()
    {
        // 버튼이 클릭되면 오브젝트 생성
        if (isCreating && Input.GetMouseButtonDown(0))
        {
            CreateObjectAtMousePosition();
        }

        // 오브젝트를 생성하고 있을 때에만 마우스 커서 위치에 따라 오브젝트 이동
        if (spawnedObject != null)
        {
            MoveObjectWithMouse();
        }
    }

    // 오브젝트를 생성할 버튼에서 호출할 함수
    public void OnCreateButtonClick()
    {
        isCreating = true;
    }

    // 3D 오브젝트를 마우스 커서 위치에 생성하는 함수
    private void CreateObjectAtMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // 카메라와의 거리 설정 (조정 가능)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        spawnedObject = Instantiate(objectToCreate, worldPosition, Quaternion.identity);
    }

    // 생성된 오브젝트를 마우스 커서 위치에 따라 이동하는 함수
    private void MoveObjectWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // 카메라와의 거리 설정 (조정 가능)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        spawnedObject.transform.position = worldPosition;
    }

    // 생성 버튼에서 손을 뗄 때에 호출할 함수
    public void OnCreateButtonRelease()
    {
        isCreating = false;
        spawnedObject = null;
    }
}
