using UnityEngine;

public class GarmentCollection : Interactable, InteractInterface
{
    public void OnInteract()
    {
        SmileYourDayTaskList.instance.garments = true;
        //todo: make the runner wear garments.
    }
}
