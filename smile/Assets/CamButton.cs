using UnityEngine;

public class CamButton : MonoBehaviour
{
    public string idMap;

    public void SetCamBasedOnID()
    {
        if(!SmileYourDayTaskList.instance.hackerQueue)
            SmileYourDayTaskList.instance.hackerCamera.PullUpCamera(idMap);
        else
        {
            SmileYourDayTaskList.instance.hackerCamera.GetCam(idMap).HackWithChild(SmileYourDayTaskList.instance.guardInQueue);
        }
    }
}
