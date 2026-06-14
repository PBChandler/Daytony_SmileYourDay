using Unity.Netcode;
using UnityEngine;

public class NWK_TestingCube : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(10, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-10, 0, 0);
        }
    }

    [Rpc(SendTo.Everyone, RequireOwnership = false)]
    public void tellServerToMoveCube_Rpc()
    {
        
    }
}
