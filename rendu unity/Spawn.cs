using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int StartCast;
    public int SpawDuration;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CastSpawn());
    }

    public IEnumerator CastSpawn()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(StartCast);
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(SpawDuration);
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
