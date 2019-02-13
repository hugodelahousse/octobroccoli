using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 translation;

    [SerializeField]
    GameObject[] players;

    private bool end = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!end) {
            checkDeath();
            transform.position += translation * Time.deltaTime;
        }
    }

    void checkDeath() {
        foreach (GameObject p in players) {
            if (end || Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x >= p.transform.position.x
                    || Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y >= p.transform.position.y
                    || Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y <= p.transform.position.y
            ) {
                end = true;
                Destroy(p);
            }
        }
    }
}
