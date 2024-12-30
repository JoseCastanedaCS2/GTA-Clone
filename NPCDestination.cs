using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{
    public int triggerNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC")) {
            if (triggerNumber == 4)
                triggerNumber = 0;
            if (triggerNumber == 3) {
                this.gameObject.transform.position = new Vector3(54, 16, 1868);
                triggerNumber = 4;
            }
            if (triggerNumber == 2) {
                this.gameObject.transform.position = new Vector3(113, 16, 1868);
                triggerNumber = 3;
            }
            if (triggerNumber == 1) {
                this.gameObject.transform.position = new Vector3(113, 16, 1947);
                triggerNumber = 2;
            }
            if (triggerNumber == 0) {
                this.gameObject.transform.position = new Vector3(54, 16, 1947);
                triggerNumber = 1;
            }
        }
    }
}
