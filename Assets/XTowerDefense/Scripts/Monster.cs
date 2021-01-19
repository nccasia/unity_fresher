using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public TextMesh _textMesh;
    private void Start()
    {
        var castle = GameObject.Find("Castle");

        if (castle != null)
        {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    }

    private void Update()
    {
        _textMesh.transform.forward = Camera.main.transform.forward;
    }
}