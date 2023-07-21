using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon : MonoBehaviour
{
    [Header("Ant Status")]
    public int antLevel = 1;
    public int antHealth = 4;
    public float antSpeed = 5f;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TowerArrow")
        {
            //antHealth = antHealth - other.gameObject; 
        }
        else
        {

        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
