using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    public GameObject towerPrefab;

    private void OnMouseUpAsButton()
    {
        var g = Instantiate(towerPrefab);
        g.transform.position = transform.position + Vector3.up;
    }
}