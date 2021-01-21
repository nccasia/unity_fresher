using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject monsterPrefab;

    public float interval = 3f; // Delay in seconds

    private void Start()
    {
        InvokeRepeating("SpawnNext", interval, interval);
    }

    private void SpawnNext()
    {
        Instantiate(monsterPrefab, transform.position, Quaternion.identity);
    }
}