using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon : MonoBehaviour
{
    [Header("Ant Status")]
    public int antLevel = 1;
    public int antHealth = 4;
    public float antSpeed = 5f;

    private Rigidbody Monrigidbody = default;

    private void Start()
    {
        Monrigidbody = GetComponent<Rigidbody>();
        Monrigidbody.velocity = Vector3.forward * antSpeed;
    }



    public void Die()
    {
        Debug.Log("ав╬З╢ы");
        gameObject.SetActive(false);
    }
}
