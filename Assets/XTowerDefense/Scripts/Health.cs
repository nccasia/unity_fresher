﻿using UnityEngine;

public class Health : MonoBehaviour
{
    private TextMesh tm;
    private Camera _camera;

    private void Start()
    {
        tm = GetComponentInChildren<TextMesh>();
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.forward = _camera.transform.forward;
    }

    public int Current()
    {
        return tm.text.Length;
    }

    public void Decrease()
    {
        if (Current() > 1)
        {
            tm.text = tm.text.Remove(tm.text.Length - 1);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}