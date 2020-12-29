using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Quaternion = UnityEngine.Quaternion;

public class TweenExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.DOMoveX(-10, 5f, true);
        this.transform.DOJump(new Vector3(-2, 0, 0), 1, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
