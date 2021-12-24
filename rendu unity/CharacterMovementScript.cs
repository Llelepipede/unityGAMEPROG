using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    //[SerializeField]
    //private float JumpForce;

    [SerializeField]
    private Vector3 Velocity;

    [SerializeField]
    private Quaternion rotation;

    //private int colliderCount = 0;

    void Update()
    {

        if(GameManager.instance.enjeu)
        {
            //--Z--
            if (Input.GetKey(KeyCode.Z))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, Speed);
            if (Input.GetKeyUp(KeyCode.Z))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, 0);

            //--S--
            if (Input.GetKey(KeyCode.S))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, -Speed);
            if (Input.GetKeyUp(KeyCode.S))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, 0);

            //--D--
            if (Input.GetKey(KeyCode.D))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Speed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
            if (Input.GetKeyUp(KeyCode.D))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

            //--Q--
            if (Input.GetKey(KeyCode.Q))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-Speed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);
            if (Input.GetKeyUp(KeyCode.Q))
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);




            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude != 0)
                GetComponentInChildren<Animator>().SetLayerWeight(1, 1);
            else
                GetComponentInChildren<Animator>().SetLayerWeight(1, 0);


            Velocity = gameObject.GetComponent<Rigidbody>().velocity;
            rotation = transform.rotation;




            /*if (Input.GetKeyDown(KeyCode.Space) && colliderCount>0)
                GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
            if (Input.GetKeyDown(KeyCode.A))
                GetComponentInChildren<Animator>().SetTrigger("slashOn");*/
            //GetComponentInChildren<Animator>().SetFloat("speed", currentSpeed);
        }

    }

    /*private void OnTriggerEnter(Collider other)
    {
        colliderCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        colliderCount--;
    }*/
}
