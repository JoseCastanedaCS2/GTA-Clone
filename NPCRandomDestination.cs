using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomDestination : MonoBehaviour
{
    public int generatePos;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC")) {
            generatePos = Random.Range(1, 5);

            if (generatePos == 4) {
                this.gameObject.transform.position = new Vector3(204, 16, 1948);
            }
            if (generatePos == 3) {
                this.gameObject.transform.position = new Vector3(204, 16, 1824);
            }
            if (generatePos == 2) {
                this.gameObject.transform.position = new Vector3(136, 16, 1824);
            }
            if (generatePos == 1) {
                this.gameObject.transform.position = new Vector3(143, 16, 1868);
            }
        }
    }
}
