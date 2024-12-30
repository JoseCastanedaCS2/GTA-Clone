using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHints : MonoBehaviour
{
    public static int hintNumber;

    public GameObject hintText;

    void Update()
    {
        if (hintNumber == 1) {
            hintNumber = 0;
            hintText.GetComponent<Text>().text = "Mission start points can be found by finding the red glowing points on your map.";
            hintText.GetComponent<Animator>().Play("HintText");
        }
    }
}
