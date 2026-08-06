using System.Collections.Generic;
using UnityEngine;

public class HackerCamera : MonoBehaviour
{
    public string camSystemID;
    public Transform cameraOutlook;

    public void OnEnable()
    {
        SmileYourDayTaskList.instance.hackerCamera.cams.Add(this);
    }
}
