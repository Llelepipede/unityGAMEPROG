using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;


    }

    public GameObject Player;
    public GameObject[] listOfMobs;
    public GameObject mob;
    public GameObject[] ListOfAnimSpanw;
    public GameObject animSpanw;
    public GameObject[] ListOfSpells;
    public GameObject Spell;
    public GameObject[] ListOfMissiles;
    public GameObject missile;


    public Transform[] PosSpaw;

    public Camera playCam;
    public Transform cursor;

    public int Score = 0;
    public GameObject ScoreText;

    public GameObject LooseText;

    public bool enjeu = true;

    private int random;

    private void Start()
    {


        listOfMobs = new GameObject[100];
        for (int i = 0; i < 30; i++)
        {
            listOfMobs[i] = Instantiate(mob);
            listOfMobs[i].SetActive(false);
        }

        ListOfAnimSpanw = new GameObject[100];
        for (int i = 0; i < 100; i++)
        {
            ListOfAnimSpanw[i] = Instantiate(animSpanw);
            ListOfAnimSpanw[i].SetActive(false);
        }

        ListOfSpells = new GameObject[100];
        for (int i = 0; i < 100; i++)
        {
            ListOfSpells[i] = Instantiate(Spell);
            ListOfSpells[i].SetActive(false);
        }

        ListOfMissiles = new GameObject[100];
        for (int i = 0; i < 100; i++)
        {
            ListOfMissiles[i] = Instantiate(missile);
            ListOfMissiles[i].SetActive(false);
        }
        StartCoroutine(spawnsMobs());

    }


    private void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: "+Score;


        if (Player.GetComponent<Stats>().hp < 1)
        {
            GameManager.instance.enjeu = false;
            LooseText.SetActive(true);
        }
            

    }

    public void spawnSpell(float x, float z)
    {
        if (Player.GetComponent<Stats>().Mana > Spell.GetComponent<Spell>().SpellCost)
        {
            Player.GetComponent<Stats>().Mana -= this.Spell.GetComponent<Spell>().SpellCost;
            GameObject Spell = IsAvailable(ListOfSpells, x, 0.2f, z);
            StartCoroutine(Spell.GetComponent<Spell>().CastSpell());
        }
    }


    public IEnumerator spawnsMobs()
    {
        random = (int)Random.Range(0, PosSpaw.Length);

        StartCoroutine(spawnMob(PosSpaw[random].transform.position.x, PosSpaw[random].transform.position.z));
        Random.Range(0, 10);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(spawnsMobs());
    }

    public IEnumerator spawnMob(float x, float z)
    {
        GameObject spawn = IsAvailable(ListOfAnimSpanw, x, 0.2f, z);
        if (spawn != null)
        {
            yield return new WaitForSeconds(3);
            GameObject mob = IsAvailable(listOfMobs, x, 0, z);
            mob.GetComponent<Collider>().isTrigger = true;
            mob.GetComponent<Rigidbody>().isKinematic = true;
            mob.GetComponent<spider>().Fullheal();
            yield return new WaitForSeconds(10);
            mob.GetComponent<Collider>().isTrigger = false;
            spawn.SetActive(false);
        }
    }

    public IEnumerator SpawnMissile()
    {
        GameObject missile = IsAvailable(ListOfMissiles, Player.transform.position.x, 0, Player.transform.position.z);
        missile.transform.LookAt( cursor);
        missile.GetComponent<NavMeshAgent>().SetDestination(cursor.position);
        for (int i = 0; i < 500; i++)
        {
            if (Vector3.Distance(missile.transform.position,missile.GetComponent<NavMeshAgent>().destination) < 0.1f)
                missile.SetActive(false);
            yield return new WaitForSeconds(0.01f);
        }
        
        
        missile.SetActive(false);

    }

    private GameObject IsAvailable(GameObject[] list,float x , float y, float z)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].activeInHierarchy == false)
            {
                list[i].transform.position =  new Vector3(x,y,z);
                list[i].SetActive(true);
                return list[i];
            }
        }
        return null;
    }
}
