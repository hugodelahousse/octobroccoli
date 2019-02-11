using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableScript : MonoBehaviour
{
    public int value;

    public void consume() {
        Destroy(this.gameObject);
    }
}
