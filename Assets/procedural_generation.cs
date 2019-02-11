using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generation : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs = new GameObject[] {};

    int lastChunk;

    [SerializeField]
    Vector2 nextPosition = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        lastChunk = -1;
        AddChunk();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            AddChunk();
    }

    void AddChunk()
    {
        if (prefabs.Length == 0)
            return;
        int ran = Random.Range(0, prefabs.Length);
        if (ran == lastChunk)
            ran = (ran + 1) % prefabs.Length;
        GameObject prefab = Instantiate(prefabs[ran], nextPosition, Quaternion.identity);
        nextPosition.Set(nextPosition.x + prefab.GetComponent<BoxCollider2D>().bounds.size.x, nextPosition.y);
        lastChunk = ran;
    }
}