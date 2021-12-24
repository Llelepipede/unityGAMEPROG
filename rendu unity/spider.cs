using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spider : MonoBehaviour
{
    [SerializeField]
    public float hp;

    [SerializeField]
    private RectTransform lifeBar;

    [SerializeField]
    private RectTransform AttackZone;
    [SerializeField]
    private GameObject AttackBox;


    private float MaxHp;
    private int time;

    private attackSpider cible = null;

    [SerializeField]
    private Transform TargetTransform;
    [SerializeField]
    private bool Ontrack= true;
    [SerializeField]
    private bool Attacking= false;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = hp;
        GetComponent<NavMeshAgent>().SetDestination(TargetTransform.position);
        Ontrack = true;
        Attacking = false;  
    }

    // Update is called once per frame
    void Update()
    {

        if (Ontrack)
        {
            GetComponent<NavMeshAgent>().SetDestination(TargetTransform.position);
            if (Vector3.Distance(transform.position,TargetTransform.position) > GetComponent<NavMeshAgent>().stoppingDistance)
            {
                GetComponent<Animator>().SetLayerWeight(1, 1);
            }
            else
            {
                GetComponent<Animator>().SetLayerWeight(1, 0);
                Ontrack = false;
            }
        }
        else
        {
            if (!Attacking)
            {
                Attacking = true;
                StartCoroutine(Attack());
            }

        }
        if (hp < 0)
            die();

    }

    public IEnumerator Attack()
    {
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
        GetComponent<Animator>().SetTrigger("attack");
        AttackZone.gameObject.SetActive(true);
        AttackBox.gameObject.SetActive(true);
        Debug.Log("attack ok");
        Vector3 AttackZoneBar = AttackZone.localScale;

        GetComponent<Animator>().speed = 2f;
        for (float i = 0; i < 10; i++)
        {
            AttackZoneBar.y = i*(1/10f);
            AttackZone.localScale = AttackZoneBar;
            yield return new WaitForSeconds(1/20f);
        }
        GetComponent<Animator>().speed = 2f;
        AttackZone.gameObject.SetActive(false);
        AttackBox.TryGetComponent<attackSpider>(out cible);
        if (cible.target)
        {
            Debug.Log("attack damage");
            cible.target.GetComponent<Stats>().hp -= 10;
        }
        AttackBox.gameObject.SetActive(false);
        GetComponent<Animator>().speed = 1f;
        Ontrack = true;
        Attacking = false;
        GetComponent<NavMeshAgent>().SetDestination(TargetTransform.position);
    }

    public void LifeLost()
    {
        Vector3 hpBarScale = lifeBar.localScale;
        hpBarScale.x = (float)hp / (float)MaxHp;
        lifeBar.localScale = hpBarScale;

    }

    public void InColliderSpell(float dmg)
    {
        hp -= dmg * Time.deltaTime;
        LifeLost();
        Debug.Log(hp);
    }

    public void die()
    {
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
        Ontrack = true;
        Attacking = false;
        AttackZone.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameManager.instance.Score += 10;
    }

    public void Fullheal()
    {
        if (MaxHp != 0)
            hp = MaxHp;
        else
            MaxHp = hp;
        LifeLost();
    }
}
