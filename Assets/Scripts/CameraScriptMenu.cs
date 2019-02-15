using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptMenu : MonoBehaviour
{
    [SerializeField]
    Vector3 translation;

    private bool reverse = false;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 1000)
            reverse = true;
        if (transform.position.x < 200)
            reverse = false;
        if (reverse)
            transform.position -= translation;
        else
            transform.position += translation;
    }
}
