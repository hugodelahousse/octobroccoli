using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    PlayerScript player;
    ParticleSystem particles;
    ParticleSystem.EmissionModule module;

    float originalRate = 0.1f;

    [SerializeField]
    float rate;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();   
        player = FindObjectOfType<PlayerScript>();
        module = particles.emission;
        originalRate = module.rate.constantMax;
        Debug.Log(originalRate);
    }

    // Update is called once per frame
    void Update()
    {
        module.rate = originalRate - (rate * player.score);
    }
}
