using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generation : MonoBehaviour
{
    [SerializeField]
    GameObject firstChunk;

    [SerializeField]
    GameObject[] prefabs = new GameObject[] {};

    Queue<GameObject> active = new Queue<GameObject>();

    int lastChunk;

    [SerializeField]
    Vector2 nextPosition = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        lastChunk = -1;
        if (firstChunk != null)
            AddFirstChunk();
        else
            AddChunk();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x >= nextPosition.x - 1000)
            AddChunk();
        if (active.Peek() != null &&
            Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x >= active.Peek().transform.position.x +
            active.Peek().GetComponent<BoxCollider2D>().bounds.size.x/2 + 1000)
            Destroy(active.Dequeue());
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
        active.Enqueue(prefab);
    }

    private void AddFirstChunk()
    {
        GameObject prefab = Instantiate(firstChunk, new Vector2(nextPosition.x, nextPosition.y), Quaternion.identity);
        float width = prefab.GetComponent<BoxCollider2D>().bounds.size.x;
        prefab.transform.position = new Vector3(nextPosition.x + width / 2, nextPosition.y, 0);
        nextPosition = new Vector2(nextPosition.x + width, nextPosition.y);
        active.Enqueue(prefab);
    }
}