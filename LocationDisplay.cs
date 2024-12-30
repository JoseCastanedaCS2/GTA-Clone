using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationDisplay : MonoBehaviour
{
    public string locationName;

    public GameObject locationText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            locationText.GetComponent<Text>().text = locationName;
            locationText.GetComponent<Animator>().Play("LocationText");
            StartCoroutine(ResetLocation());
        }
    }

    IEnumerator ResetLocation() 
    {
        yield return new WaitForSeconds(6);
        locationText.GetComponent<Animator>().Play("New State");
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
