using UnityEngine;

public class FPSRaycast : MonoBehaviour
{
    public FirstPersonController fpc;
    public LayerMask mask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward * 5, out hit);
        if(hit.transform != null)
        {
            fpc.interactable = hit.transform.GetComponent<InteractInterface>();
        }
    }
}
