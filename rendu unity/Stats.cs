using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Mana;
    public int MaxMana;
    public float manaRegen;
    public float hp;
    public float MaxHp;


    private float time;

    [SerializeField]
    private RectTransform lifeBar;
    [SerializeField]
    private RectTransform manaBar;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        
        if (time > manaRegen)
        {
            if (Mana < MaxMana)
            {
                Mana += 1;
                time = 0;
            }
        }
        else
        {
            time += Time.deltaTime;
        }
        LifeLost();
        ManaLost();
    }

    public void LifeLost()
    {
        Vector3 hpBarScale = lifeBar.localScale;
        hpBarScale.x = (float)hp / (float)MaxHp;
        lifeBar.localScale = hpBarScale;

    }

    public void InColliderAtk(float dmg)
    {
        hp -= dmg * Time.deltaTime;
        LifeLost();
    }

    public void ManaLost()
    {
        Vector3 ManaBarScale = manaBar.localScale;
        ManaBarScale.x = (float)Mana / (float)MaxMana;
        manaBar.localScale = ManaBarScale;

    }
}
