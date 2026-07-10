using System;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class SmileYourDayTaskList : NetworkBehaviour
{
    public static SmileYourDayTaskList instance;

    public SteamId host, client;
//
    public TextMeshProUGUI display;
    public NetworkVariable<List<GameTask>> tasks;
    //public List<GameTask> sourceTasks; //has to copy from inspector;
    private void Awake()
    {
       // tasks.Value = sourceTasks;
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        UpdateGameTask("show", 0);
    }
    public void UpdateGameTask(string id, int value)
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
