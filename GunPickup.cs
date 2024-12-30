using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject pistol;
    public GameObject pickupTrigger;
    public GameObject pistolFireObj;

    public AudioSource pickupSound;

    void OnTriggerEnter(Collider other)
    {
        pickupSound.Play();
        pistol.SetActive(true);
        pickupTrigger.SetActive(false);
        pistolFireObj.SetActive(true);
    }
}