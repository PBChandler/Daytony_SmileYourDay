using Unity.Netcode;
using UnityEngine;

public class NoClones : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            Destroy(gameObject);
        }
    }
}
