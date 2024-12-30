using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public int pistolDamage;
    public static float targetDistance;
    public static bool isAiming = false;
    public static bool isFiring = false;

    public GameObject player;
    public GameObject aimingDistanceObj;

    public AudioSource pistolShot;
    
    void Update()
    {
        RaycastHit hit;

//AIMING
        if (Input.GetMouseButton(1)) {
            isAiming = true;
            if (isFiring == false) {
                player.GetComponent<Animation>().Play("Pistol Aim");
                aimingDistanceObj.SetActive(true);
            }
        }
        else {
            isAiming = false;
            aimingDistanceObj.SetActive(false);
        }
//SHOOTING
        if (Input.GetMouseButtonDown(0) && isAiming == true) {
            if (GlobalAmmo.pistolAmmo > 0) {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
                    targetDistance = hit.distance;
                    pistolDamage = 20;
                    hit.transform.SendMessage("DamageNPC", pistolDamage, SendMessageOptions.DontRequireReceiver);
                }

                isFiring = true;
                player.GetComponent<Animation>().Play("Fire Pistol");
                pistolShot.Play();
                GlobalAmmo.pistolAmmo--;
                StartCoroutine(FirePistol());
            }
        }
    }

    IEnumerator FirePistol() 
    {
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
