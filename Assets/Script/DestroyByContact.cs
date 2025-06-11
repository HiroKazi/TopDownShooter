using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
        
       // Destroy(other.gameObject);
        
    }

}
