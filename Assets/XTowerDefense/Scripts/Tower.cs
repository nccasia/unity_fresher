using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float _rotationSpeed = 35;
    private const float CONST_SHOOT_CD = 1.0f; // s
    private float _shootCdCounter = 1.0f;
    private Transform _target;
    
    public GameObject bulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        var monster = other.GetComponent<Monster>();

        if (monster != null)
        {
            if (_target == null)
            {
                _target = monster.transform; // acquire new target
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_target != null && other.gameObject == _target.gameObject)
        {
            _target = null;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);

        _shootCdCounter += Time.deltaTime;
        if (_target != null && _shootCdCounter >= CONST_SHOOT_CD)
        {
            _shootCdCounter = 0;
            ShootAt(_target);
        }
    }

    void ShootAt(Transform monster)
    {
        var bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletGO.GetComponent<Bullet>().target = monster.transform; // Set target for bullet
    }
}