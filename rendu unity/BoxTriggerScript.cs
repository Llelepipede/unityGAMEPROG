using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerScript : MonoBehaviour
{
    [SerializeField]
    private float GrowUpSpeed;


    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.localScale += Vector3.one * GrowUpSpeed * Time.deltaTime;
    }
}
