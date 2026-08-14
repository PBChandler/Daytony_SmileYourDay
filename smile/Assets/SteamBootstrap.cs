using Steamworks;
using UnityEngine;

public static class SteamBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    public static void TURNONSTEAM()
    {
        SteamClient.Init(4998170, true);
        
    }
}
