using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Transform target;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            var dir = target.position - transform.position;
            _rigidbody.velocity = dir.normalized * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var healthComponent = other.GetComponentInChildren<Health>();

        if (healthComponent != null)
        {
            healthComponent.Decrease();
            Destroy(gameObject);
        }
    }
}