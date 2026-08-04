using UnityEngine;
using UnityEngine.Events;
public class KeyInteractable : Interactable, InteractInterface
{
    public UnityEvent screen;
    public void OnInteract()
    {
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
