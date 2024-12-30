using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeath : MonoBehaviour
{
    public int health = 100;
    public bool isdead = false;

    public GameObject npcObj;
    public GameObject interationTrigger;
    public GameObject helpMeFX;

    void Update()
    {
        this.gameObject.transform.position = npcObj.transform.position;
    }

    void DamageNPC(int pistolDamage) 
    {
        health -= pistolDamage;
        if (health <= 0 && isdead == false) {
            isdead = true;
            StartCoroutine(NPCDead());
        }
    }

    IEnumerator NPCDead() 
    {
        WantedLevel.wantedLevel++;
        WantedLevel.activeStar = true;
        npcObj.GetComponent<NPCAI>().enabled = false;
        npcObj.GetComponent<NavMeshAgent>().enabled = false;
        npcObj.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        interationTrigger.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        npcObj.GetComponent<Animator>().Play("Dying");
        helpMeFX.SetActive(false);

        yield return new WaitForSeconds(3);
        npcObj.GetComponent<Animator>().enabled = false;
    }
}
