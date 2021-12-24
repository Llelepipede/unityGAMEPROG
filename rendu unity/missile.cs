using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{

    private spider spider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<spider>(out spider))
        {
            Debug.Log("prout");
            other.gameObject.GetComponent<spider>().hp -= 10;
            other.gameObject.GetComponent<spider>().LifeLost();
            gameObject.SetActive(false);
        }
        
    }

}
