using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected SphereCollider interactRange;
    protected FirstPersonController fpc;

    private void Start()
    {
        interactRange = GetComponent<SphereCollider>();
    }

}
