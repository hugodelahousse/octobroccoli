using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = new Sprite[0];
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(
           0, sprites.Length
       )];
    }
}
