using UnityEngine;

public class Door : Interactable, InteractInterface
{
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
        rend.enabled = isOpen;
        bocks.enabled = isOpen;

        isOpen = !isOpen;

        Debug.Log("bye bye");
        Destroy(gameObject);
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
