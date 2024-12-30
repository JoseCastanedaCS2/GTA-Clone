using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public int lineNumber;

    public AudioSource[] voiceLines;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            StartCoroutine(NPCVoiceLine());
        }
    }

    IEnumerator NPCVoiceLine() 
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        lineNumber = Random.Range(0, 3);
        voiceLines[lineNumber].Play();

        yield return new WaitForSeconds(4);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
