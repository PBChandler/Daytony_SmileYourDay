using Unity.Netcode;
using UnityEngine;

public class Heaven_NetworkedPlayer : NetworkBehaviour
{
    public NetworkVariable<bool> runnerJoined= new NetworkVariable<bool>(
    
    readPerm: NetworkVariableReadPermission.Everyone, 
    writePerm: NetworkVariableWritePermission.Owner
    );
    public NetworkVariable<bool> hackerJoined= new NetworkVariable<bool>(
    
    readPerm: NetworkVariableReadPermission.Everyone, 
    writePerm: NetworkVariableWritePermission.Owner
    );
  
    public GameObject Runner, Hacker;
/// <summary>
/// this will have to be changed when we let people queue up as Hacker and Runner.
/// </summary>
    public void OnEnable()
    {
        
        if(runnerJoined.Value == false)
        {
            runnerJoined.Value = true;
            Runner.SetActive(true);
        }
        else
        {
            hackerJoined.Value = true;
            Hacker.SetActive(true);
        }
    }
}
