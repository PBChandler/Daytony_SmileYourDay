using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SecurityCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<HackerCamera> cams;
    void Start()
    {
        
    }

    public void PullUpCamera(HackerCamera hc)
    {
        transform.position = hc.cameraOutlook.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
