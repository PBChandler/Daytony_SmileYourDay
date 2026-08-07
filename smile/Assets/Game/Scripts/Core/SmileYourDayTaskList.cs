using System;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script has effectively become the real game manager and is responsible for sending RPCs through a janky system cos I hate the syntax of RPC calls.
/// </summary>
public class SmileYourDayTaskList : NetworkBehaviour
{
    public static SmileYourDayTaskList instance;

    public SteamId host, client;
    public NetworkVariable<bool> hostIsRunner;
    public delegate void HeavensCall(string input);
    public HeavensCall dg_Heaven;
    public TextMeshProUGUI display;
    public NetworkVariable<List<GameTask>> tasks;
    public SecurityCamera hackerCamera;
    public NetworkVariable<int> funValue;
    public delegate void onFunValueChanged(int newValue);
    public onFunValueChanged dg_onFunValueChanged;
    public List<GameObject> player;
    public bool gameHasStarted;
    public Vector3 hackerDistractionLocation;
    public RadioAOE ActiveHackerCameraInWorld;
    public bool hackerQueue; //while the hacker is queueing the camera.
    public EnemyStateMachine guardInQueue;
    //public List<GameTask> sourceTasks; //has to copy from inspector;
    private void Awake()
    {
       // tasks.Value = sourceTasks;
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        int funnerValue = UnityEngine.Random.Range(0, 10);
        if(funnerValue < 1)
        {
            funValue.Value = Mathf.Clamp(DateTime.UtcNow.Hour + DateTime.UtcNow.Day + SteamClient.Name[0],0,100);
        }
        else
        {
            funValue.Value = UnityEngine.Random.Range(0, 100);
        }
        instance = this;
        UpdateGameTask("show", 0);
        dg_onFunValueChanged += dummy;
        dg_Heaven += dummy;
    }

    public void dummy(string s){}
    public void dummy(int s){ Debug.Log("FUN VALUE:" + s);}
    public void UpdateGameTask(string id, int value)
    {
        UpdateGameTaskRpc(id, value);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void UpdateGameTaskRpc(string id, int value)
    {
        
        display.text = "Core Gameplay Tests\n";
        foreach(GameTask t in tasks.Value)
        {
            if(t.ID.ToLower() == id.ToLower())
            {
                switch(value)
                {
                    case 0:
                     t.value = false;
                     break;
                    case 1:
                     t.value = true;
                     break;
                    default:
                     t.value = false;
                     Debug.LogError("Nonbinary answer inputted for UpdateGameTask:" + t.throwError); //we fw nonbinary people this is just literally a not binary number checker
                    break;

                }
            }
            display.text += t.value ? "<color=green>" + t.ID + "\t[X] </color>\n" : "<color=red>" + t.ID + "\t[ ]</color>\n";
        }
        dg_Heaven(id);
    }

    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void LoadNextSceneRpc(string sceneName)
    {
        
        NetworkManager.SceneManager.LoadScene("Avery_Runner_Building", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void CallHeavenRpc(string message)
    {
        dg_Heaven(message);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void SetHostIsRunnerRpc(bool state)
    {
        hostIsRunner.Value = state;
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void InitializePlayersRpc()
    {
        player[0].GetComponent<PlayerHeaven>().SetPlayerState(PLAYERTYPE.Hacker);
        player[1].GetComponent<PlayerHeaven>().SetPlayerState(PLAYERTYPE.Runner);
        gameHasStarted = true;
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void AddNetworkedPlayerRpc(string john)
    {
        player.Add(GameObject.Find(john));
    }
}

 
[System.Serializable]
public class GameTask : INetworkSerializable, IEquatable<GameTask>
{
    public string ID;
    public bool value;
    public string throwError;

    public bool Equals(GameTask other)
    {
        return other.ID == ID;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
         serializer.SerializeValue(ref ID);
        serializer.SerializeValue(ref value);
        serializer.SerializeValue(ref throwError);
    }
}
