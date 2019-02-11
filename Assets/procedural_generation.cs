﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generation : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs = new GameObject[] {};

    Vector2[] sizes;

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
        if (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x >= nextPosition.x - 20)
            AddChunk();
    }

    void AddChunk()
    {
        if (prefabs.Length == 0)
            return;
        int ran = Random.Range(0, prefabs.Length);
        if (ran == lastChunk)
            ran = (ran + 1) % prefabs.Length;
        GameObject prefab = Instantiate(prefabs[ran], new Vector2(nextPosition.x, nextPosition.y), Quaternion.identity);
        float width = prefab.GetComponent<BoxCollider2D>().bounds.size.x;
        prefab.transform.position = new Vector3(nextPosition.x + width / 2, nextPosition.y, 0);
        nextPosition = new Vector2(nextPosition.x + width, nextPosition.y);
        lastChunk = ran;
    }
}