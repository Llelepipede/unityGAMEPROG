using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    private Camera MainCam;

    [SerializeField]
    private GameObject[] listOfInstance;


    public GameObject[] prefabs;
    public string nameOfThePrefab;

    public GameObject missile;

    private int count = 0;

    private int index;


    [SerializeField]
    private LayerMask LayerMask;

    void Start()
    {
        nameOfThePrefab = prefabs[index].name;
    }

    private void Update()
    {
        if (GameManager.instance.enjeu)
        {
            nameOfThePrefab = prefabs[index].name;
            Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, LayerMask))
            {
                transform.position = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
            }
            if (Input.GetMouseButtonDown(1))
            {
                GameManager.instance.spawnSpell(transform.position.x, transform.position.z);
            }
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(GameManager.instance.SpawnMissile());
            }
        }
    }

    // Spawning a Prefab of a Complete Effect on mouse position
    public void SpawnPrefab()
    {
        if (listOfInstance[count])
        {
            DestroyImmediate(listOfInstance[count]);
        }
        listOfInstance.SetValue(Instantiate(prefabs[index], transform.position, new Quaternion(Quaternion.identity.x, Random.Range(0f, 3.6f), Quaternion.identity.z, Quaternion.identity.w)), count);

        Destroy(listOfInstance[count], listOfInstance.GetLength(0));
        count++;


        
        if (count == 10)
            count = 0;
    }
}
