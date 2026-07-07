using UnityEngine;

public class Door : Interactable, InteractInterface
{
    [SerializeField] bool requiresKeycard;
    bool isOpen = false;
    MeshRenderer rend;
    BoxCollider bocks;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        bocks = GetComponent<BoxCollider>();
    }

    public void OnInteract()
    {
        if (requiresKeycard)
        {
            if (fpc.hasKeycard)
                OpenDoor();
        }
        else
            OpenDoor();
    }

    void OpenDoor()
    {
        rend.enabled = isOpen;
        bocks.enabled = isOpen;

        isOpen = !isOpen;
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
