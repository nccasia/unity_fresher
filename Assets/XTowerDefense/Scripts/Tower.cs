using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float _rotationSpeed = 35;
    public GameObject bulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        var monster = other.GetComponent<Monster>();

        if (monster != null)
        {
            var bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().target = monster.transform; // Set target for bullet
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);
    }
}