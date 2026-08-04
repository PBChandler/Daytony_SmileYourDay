using NUnit.Framework;
using Steamworks;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public RawImage imageOne, imageTwo;
    SteamId runner, hacker;
    public bool frontways = false;
    public FriendRole[] roleState = new FriendRole[2];
    public bool locked = false;
    void Start()
    {
        pop();
        SmileYourDayTaskList.instance.dg_Heaven += lobby_swapRpcCheck;
    }

    public async void pop()
    {
        await Populate(SmileYourDayTaskList.instance.host, imageOne, "run");
        await Populate(SmileYourDayTaskList.instance.client, imageTwo, "hck");
    }

    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void SwappySwappyRpc()
    {
        if (locked) return;
        locked = true;
        
        SmileYourDayTaskList.instance.CallHeavenRpc("lobby_swapRPC");
        Invoke("unlock", 0.1f);
    }

    public void unlock()
    {
        locked = false;
    }

    public void lobby_swapRpcCheck(string input)
    {
        Debug.Log("HEAVEN'S CALL SENT");
        if(input == "lobby_swapRPC")
        {
            Debug.Log("HEAVEN'S CALL RETRIEVED");
            SwapRpc();
        }
    }
    public async void SwapRpc()
    {
       
        if(frontways)
        {
            await Populate(SmileYourDayTaskList.instance.host, imageOne, "run");
            await Populate(SmileYourDayTaskList.instance.client, imageTwo, "hck");
        }
        else
        {
            await Populate(SmileYourDayTaskList.instance.client, imageOne, "run");
            await Populate(SmileYourDayTaskList.instance.host, imageTwo, "hck");
        }
        frontways = !frontways;
    }
    public async Task Populate(SteamId ID_FRIEND, RawImage var, string ste)
    {
        //meRightNow = ID_FRIEND;
        Steamworks.Data.Image? im = await SteamFriends.GetSmallAvatarAsync(ID_FRIEND);
        var.texture = Convert(im.Value);
        switch (ste)
        {
            case "run":
                roleState[0] = new FriendRole() { id = ID_FRIEND, role = ste, name = ID_FRIEND.Value + "" };
                break;
            case "hck":
                roleState[1] = new FriendRole() { id = ID_FRIEND, role = ste, name = ID_FRIEND.Value + "" };
                break;
            default:
                break;
        }

        //ProfileName.text = meRightNow.Name;
    }

    public Texture2D Convert(Steamworks.Data.Image image)
    {
        // Create a new Texture2D
        var avatar = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false);

        // Set filter type, or else its really blury
        avatar.filterMode = FilterMode.Trilinear;

        // Flip image
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                var p = image.GetPixel(x, y);
                avatar.SetPixel(x, (int)image.Height - y, new UnityEngine.Color(p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f));
            }
        }

        avatar.Apply();
        return avatar;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public struct FriendRole
{
    public SteamId id;
    public string name;
    public string role;
}