using UnityEngine;
using UnityEngine.Events;
public class KeyInteractable : Interactable, InteractInterface
{
    public UnityEvent screen;
    public bool requiresKeycard;
    public void OnInteract()
    {
        if (requiresKeycard && !SmileYourDayTaskList.instance.keycardObtained)
        {
            SmileYourDayTaskList.instance.gamerText.SetText("KEYCARD REQUIRED", 0.2f);
            return;
        }
       
        screen.Invoke();
    }

    public void Update()
    {
      
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            screen.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
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
