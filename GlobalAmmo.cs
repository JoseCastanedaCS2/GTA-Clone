using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int pistolAmmo;

    public GameObject ammoDisplay;

    void Update()
    {
        ammoDisplay.GetComponent<Text>().text = "" + pistolAmmo;
    }
}
