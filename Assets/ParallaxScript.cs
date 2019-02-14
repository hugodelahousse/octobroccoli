using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField]
    private float factor = 0;

    private Vector3 originalPosition;
    private Vector3 originalCameraPosition;


    void Start() {
        originalPosition = transform.localPosition;
        originalCameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(
            originalPosition.x + (originalCameraPosition.x - Camera.main.transform.position.x) * factor,
            transform.localPosition.y,
            transform.localPosition.z
        );         
    }
}