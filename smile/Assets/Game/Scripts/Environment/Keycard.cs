using UnityEngine;

public class Keycard : Interactable, InteractInterface
{
    public void OnInteract()
    {
        try
        {
            fpc.hasKeycard = true;
        }
        catch
        {
            SmileYourDayTaskList.instance.fpc.hasKeycard = true;
        }
       
        SmileYourDayTaskList.instance.keycardObtained = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Runner")
            return;

        fpc = other.transform.parent.GetComponent<FirstPersonController>();

        fpc.interactable = this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        fpc.interactable = null;

        fpc = null;
    }
}
