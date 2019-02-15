using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    UnityEngine.UI.Text score;
    void Start() {
        score = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = ((int) Camera.main.transform.position.x / 10).ToString();
    }
}
