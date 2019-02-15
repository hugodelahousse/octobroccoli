using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int distance = 0;

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
        if (players.Length > 0) {
            distance++;
            GetComponent<UnityEngine.UI.Text>().text = distance.ToString();
        }
    }
}
