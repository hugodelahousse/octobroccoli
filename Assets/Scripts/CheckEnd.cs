using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnd : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canvasEnabled = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canvasEnabled) {
            GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
            if (players.Length == 0) {
                GetComponent<Canvas>().enabled = true;
                canvasEnabled = true;
            }
        }
    }
}
