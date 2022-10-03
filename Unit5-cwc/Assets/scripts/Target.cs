using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{

    private Rigidbody targetRigidbody;
    private GameManager gameManager;

    [Header("General")] 
    [SerializeField] private int pointValue = 0;
    [SerializeField] private ParticleSystem explosionParticle;

    [Header("Force")] 
    [SerializeField] [Range(0f, 40f)] private int minSpeed;
    [SerializeField] [Range(0f, 40f)] private int maxSpeed;
    
    [Header("Torque")]
    [SerializeField] [Range(-20f, 20f)] private int minTorque;
    [SerializeField] [Range(-20f, 20f)] private int maxTorque;

    [Header("Spawn")] 
    [SerializeField] private float spawnHeight = 0;
    [SerializeField] private float spawnRange = 5;
    
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), spawnHeight);
    }
    
}
