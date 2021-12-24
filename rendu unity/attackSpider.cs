using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSpider : MonoBehaviour
{
    public GameObject target;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            target = player;
        }

        /*        Debug.Log(other);
                Debug.Log("player On");
                Stats last = Target;
                if (!other.TryGetComponent<Stats>(out Stats tested))
                {
                    Debug.Log("prout targeted false");
                    Target = last;
                }
                else
                {
                    Debug.Log("prout targeted true");
                    other.TryGetComponent<Stats>(out Target);
                }*/
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            target = null;
        }

        /*        if (other.gameObject.tag == "Player")
                {
                    if (other.gameObject.TryGetComponent<Stats>(out Stats tested))
                    {
                        Debug.Log("prout leaved");
                        Target = null;
                    }
                }*/
    }
}
