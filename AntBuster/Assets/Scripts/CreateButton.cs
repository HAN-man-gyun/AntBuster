using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour
{
    public GameObject objectToCreate; // ������ 3D ������Ʈ ������
    private GameObject spawnedObject; // ������ ������Ʈ

    private bool isCreating = false; // ��ư�� Ŭ���Ͽ� ������Ʈ�� �����ϴ� ������ ����

    void Update()
    {
        // ��ư�� Ŭ���Ǹ� ������Ʈ ����
        if (isCreating && Input.GetMouseButtonDown(0))
        {
            CreateObjectAtMousePosition();
        }

        // ������Ʈ�� �����ϰ� ���� ������ ���콺 Ŀ�� ��ġ�� ���� ������Ʈ �̵�
        if (spawnedObject != null)
        {
            MoveObjectWithMouse();
        }
    }

    // ������Ʈ�� ������ ��ư���� ȣ���� �Լ�
    public void OnCreateButtonClick()
    {
        isCreating = true;
    }

    // 3D ������Ʈ�� ���콺 Ŀ�� ��ġ�� �����ϴ� �Լ�
    private void CreateObjectAtMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // ī�޶���� �Ÿ� ���� (���� ����)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        spawnedObject = Instantiate(objectToCreate, worldPosition, Quaternion.identity);
    }

    // ������ ������Ʈ�� ���콺 Ŀ�� ��ġ�� ���� �̵��ϴ� �Լ�
    private void MoveObjectWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // ī�޶���� �Ÿ� ���� (���� ����)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        spawnedObject.transform.position = worldPosition;
    }

    // ���� ��ư���� ���� �� ���� ȣ���� �Լ�
    public void OnCreateButtonRelease()
    {
        isCreating = false;
        spawnedObject = null;
    }
}
