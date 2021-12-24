using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowCam : MonoBehaviour
{

    float timer;
    public GameObject target;

    Vector3 StartPosition;
    Quaternion StartRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;

        StartCoroutine(CameraLerp());
    }

    // Update is called once per frame

    IEnumerator CameraLerp()
    {
        float timer = 0;
        while (timer < 10)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, timer / 10);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, timer / 10);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2);
        timer = 0;
        while (timer < 10)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, StartRotation, timer / 10);
            transform.position = Vector3.Lerp(transform.position, StartPosition, timer / 10);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
