using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerHeaven : NetworkBehaviour, IEquatable<PlayerHeaven>
{
    public PLAYERTYPE playerType;
    public GameObject PlayerScreen, HackerScreen;
    public SmileYourDayManager manager; //statics crash everything, frown;
    public Camera localRunnersEyes;
    public ulong id;
    bool flipflop;

    public void OnEnable()
    {
        manager = GameObject.Find("[SmileYourDayManager]").GetComponent<SmileYourDayManager>();
        
    }


    public void CheckAssignment()
    {
        //TESTING, NEEDS TO BE REMOVED IN THE ACTUAL BUILD:
#if UNITY_EDITOR
        //SmileYourDayTaskList.instance.hostIsRunner.Value = true;
 #endif
        //REMOVE ABOVE REMOVE ABOVE REMOVE ABOVE REMOVE ABOVE
        //this should not be running every frame but PLEASE let it work.
        //also this will have to only run once the playable scene is actually loaded, because we fake one player in the world by warping the other to HELL.
        if (SmileYourDayTaskList.instance.hostIsRunner.Value == true && id == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SetPlayerState(PLAYERTYPE.Runner);
            if(IsOwner)
                NetworkManager.Singleton.ConnectedClients[1].PlayerObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        //if this user is the host and the host is not the runner
        if (SmileYourDayTaskList.instance.hostIsRunner.Value == false && id == 0)
        {
            SetPlayerState(PLAYERTYPE.Hacker);
           
            // transform.position = new Vector3(-999, 999, 999);
            Cursor.lockState = CursorLockMode.None;
        }
        if (SmileYourDayTaskList.instance.hostIsRunner.Value == false && id == 1)
        {
            SetPlayerState(PLAYERTYPE.Runner);
            if (IsOwner)
                NetworkManager.Singleton.ConnectedClients[0].PlayerObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (SmileYourDayTaskList.instance.hostIsRunner.Value == true && id == 1)
        {
            
            SetPlayerState(PLAYERTYPE.Hacker);
            //transform.position = new Vector3(-999, 999, 999);
            Cursor.lockState = CursorLockMode.None;
        }

        if(IsOwner && playerType == PLAYERTYPE.Runner)
        {
            
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void Update()
    {
        id = OwnerClientId;

        if(SmileYourDayTaskList.instance.gameHasStarted && !flipflop)
        {
            flipflop = true;    
            CheckAssignment();
        }
            
        if (SmileYourDayTaskList.instance.hostIsRunner.Value == true)
        {
            if(IsHost)
            {
                SetPlayerState(PLAYERTYPE.Runner);
            }
            else
            {
                SetPlayerState(PLAYERTYPE.Hacker);
            }
        }
        
        if(!IsOwner) return;
        if(Input.GetKeyDown(KeyCode.H))
        {
            SetPlayerState(PLAYERTYPE.Hacker);
            CheckAssignment();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetPlayerState(PLAYERTYPE.Runner);
            CheckAssignment();

        }
    }

    public void SetPlayerState(PLAYERTYPE typeGuy)
    {
        switch(typeGuy)
        {
            //the issue is the hacker screen is not hidden
            case PLAYERTYPE.Hacker:
                playerType = PLAYERTYPE.Hacker;
                HackerScreen.gameObject.SetActive(true);
                PlayerScreen.gameObject.SetActive(false);
            break;
            case PLAYERTYPE.Runner:
                playerType = PLAYERTYPE.Runner;
                HackerScreen.gameObject.SetActive(false);
                PlayerScreen.gameObject.SetActive(true);
            break;
        }
    }

    public bool Equals(PlayerHeaven other)
    {
        if(other.playerType == playerType)
        return true;
        return false;
    }
}

public enum PLAYERTYPE
{
    Undecided,
    Hacker,
    Runner,
}
