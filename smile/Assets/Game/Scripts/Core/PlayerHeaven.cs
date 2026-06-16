using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerHeaven : NetworkBehaviour, IEquatable<PlayerHeaven>
{
    public PLAYERTYPE playerType;
    public GameObject PlayerScreen, HackerScreen;
    public SmileYourDayManager manager; //statics crash everything, frown;
    public Camera localRunnersEyes;

    public void OnEnable()
    {
        manager = GameObject.Find("[SmileYourDayManager]").GetComponent<SmileYourDayManager>();
    }
    public void Update()
    {
        if(!IsOwner) return;
        if(Input.GetKeyDown(KeyCode.H))
        {
            SetPlayerState(PLAYERTYPE.Hacker);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetPlayerState(PLAYERTYPE.Runner);
            
        }
    }

    public void SetPlayerState(PLAYERTYPE typeGuy)
    {
        switch(typeGuy)
        {
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
