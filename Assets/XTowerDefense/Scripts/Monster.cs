using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public TextMesh _textMesh;
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
        var castle = GameObject.Find("Castle");

        if (castle != null)
        {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    }

    private void Update()
    {
        _textMesh.transform.forward = _camera.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Castle")
        {
            other.GetComponentInChildren<Health>().Decrease();
            Destroy(gameObject);
        }
    }
}