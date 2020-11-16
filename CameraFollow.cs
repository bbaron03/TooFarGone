﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    public Transform followTransform;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(followTransform != null)
            this.transform.position = new Vector3(followTransform.position.x,
                followTransform.position.y, followTransform.position.z - 10);
    }
}
