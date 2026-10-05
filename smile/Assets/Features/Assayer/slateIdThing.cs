using UnityEngine;

public class slateIdThing : Interactable, InteractInterface
{
    public void OnInteract()
    {
        SmileYourDayTaskList.instance.slateObtained = true;
        Destroy(this);
    }
}
