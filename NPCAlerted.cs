using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlerted : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC")) {
            other.GetComponent<Animator>().Play("Running");
            other.GetComponent<NavMeshAgent>().speed = 7.5f;
            NPCAI.isfleeing = true;
        }
    }
}
