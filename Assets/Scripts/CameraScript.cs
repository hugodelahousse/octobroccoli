using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 translation;

    GameObject[] players;

    private bool end = false;

    void Start() {
        players = GameObject.FindGameObjectsWithTag ("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!end) {
            checkDeath();
            transform.position += translation * Time.deltaTime;
        }
    }

    void checkDeath() {
        for (var i = 0; i < players.Length; i++) {
            if (end || Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x >= players[i].transform.position.x
                    || Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y >= players[i].transform.position.y
                    || Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y <= players[i].transform.position.y
            ) {
                end = true;
                for (var j = 0; j < players.Length; j++) {
                    Destroy(players[j]);
                }
                return;
            }
        }
    }
}
