using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 translation;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += translation * Time.deltaTime;
    }
}
