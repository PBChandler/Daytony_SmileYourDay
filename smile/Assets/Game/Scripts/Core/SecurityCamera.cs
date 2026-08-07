using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SecurityCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<HackerCamera> cams = new List<HackerCamera>();
    void Start()
    {
        
    }

    public void PullUpCamera(HackerCamera hc)
    {
        transform.position = hc.cameraOutlook.transform.position;
        transform.rotation = hc.cameraOutlook.transform.rotation;
    }

    public void PullUpCamera(string id)
    {
        foreach(HackerCamera c in cams)
        {
            if (c == null) continue; //idk why null cameras appear but we're crunching on time so uhhhhh don't mattah
            if(c.camSystemID == id)
            {
                PullUpCamera(c);
                c.setCustomActive(true);
            }
            else
            {
                c.setCustomActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
