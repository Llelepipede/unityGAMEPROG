using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    private float SpellDuration;
    [SerializeField]
    private float StartCast;
    [SerializeField]
    private float SpellDmg;

    public int  SpellCost;
    public spider Target = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CastSpell());
    }

    public IEnumerator CastSpell()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(StartCast);
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(SpellDuration);
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(StartCast + SpellDuration);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.TryGetComponent<spider>(out Target);
        if (Target)
            other.gameObject.GetComponent<spider>().InColliderSpell(SpellDmg/SpellDuration);
        Target = null;
    }
}
