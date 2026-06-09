using System.Collections.Generic;
using UnityEngine;

public class HackerCamera : MonoBehaviour
{
    public List<SO_HackerCameraOBJ> hacker;
    public Camera cam;
    public int index = 0;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        SetNextCamera();
    }
    public void SetNextCamera()
    {
        if(index > hacker.Count-2)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        cam.transform.position = hacker[index].position;
        cam.transform.rotation = Quaternion.Euler(hacker[index].rotationEulers);
    }

}
