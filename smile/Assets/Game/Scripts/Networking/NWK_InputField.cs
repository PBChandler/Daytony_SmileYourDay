using UnityEngine;
using UnityEngine.Networking;
using Steamworks;
using Unity.Netcode;
using TMPro;
using Unity.VisualScripting;
public class NWK_InputField : NetworkBehaviour
{
    public TMP_InputField inputField;

    public override void OnNetworkSpawn()
    {
        Debug.Log("hello! :) I'm here! " + gameObject.name);
        base.OnNetworkSpawn();
    }
    public void isUITheProblem(string val)
    {
        NWK_UpdateTextField_ServerRpc(val);
    }
    [Rpc(SendTo.Server)]
    public void NWK_UpdateTextField_ServerRpc(string value)
    {
        if(!IsSpawned)
        {
            Debug.Log("Garfield.Com/d_a_m_n__y_o_u__t_e_n_n_a (the network hasn't spawned yet)");
            return;
        }
        Debug.Log("SERVER RPC FIRING!");
        
        NWK_ReceiveUpdateTextField_Rpc(value);
    }

    [Rpc(SendTo.Everyone)]
    public void NWK_ReceiveUpdateTextField_Rpc(string value)
    {
         if(!IsSpawned)
        {
            Debug.Log("Garfield.Com/d_a_m_n__y_o_u__t_e_n_n_a (the network hasn't spawned yet)");
            return;
        }
         Debug.Log("Garfield.Com/findher");
        UI_GameLog.gamelog("this:" + value);
        inputField.text = value;
    }
   
}
