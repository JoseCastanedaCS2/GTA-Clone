using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public static bool isfleeing = false;
    public bool isFleeingOver = false;

    public GameObject destination;
    public GameObject fleeDestination;

    public AudioSource helpMeFX;

    NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isfleeing == false) {
            agent.SetDestination(destination.transform.position);
        }
        else {
            agent.SetDestination(fleeDestination.transform.position);
            if (isFleeingOver == false) {
                isFleeingOver = true;
                StartCoroutine(Fleeing());
            }
        }
    }

    IEnumerator Fleeing() 
    {
        helpMeFX.Play();

        yield return new WaitForSeconds(13);
        isfleeing = false;
        isFleeingOver = false;
        this.gameObject.GetComponent<Animator>().Play("Walking");
        this.gameObject.GetComponent<NavMeshAgent>().speed = 2.5f;
    }
}
