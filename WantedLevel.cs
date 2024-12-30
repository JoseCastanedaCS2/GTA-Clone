using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedLevel : MonoBehaviour
{
    public bool isWanted;

    public static int wantedLevel;
    public static bool activeStar;

    public GameObject[] wantedStars;

    void Update()
    {
        if (isWanted == false && activeStar == true) {
            activeStar = false;
            isWanted = true;

            StartCoroutine(ShowStar());
        }
    }

    IEnumerator ShowStar() 
    {
        wantedStars[wantedLevel - 1].SetActive(true);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(true);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(true);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);

        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(true);
    }
}
