using System;
using System.Collections;
using Lesson10.Scripts;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float force = 10;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Fly(float angle)
    {
        var direction = new Vector3(angle, angle, 0).normalized;
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);

        StartCoroutine(ReturnToPool());
    }

    private IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(5);
        SimplePool.Instance.Release(this.gameObject);
    }
}