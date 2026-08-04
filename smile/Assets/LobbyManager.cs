using Steamworks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public RawImage imageOne, imageTwo;
    void Start()
    {
        pop();
    }

    public async void pop()
    {
        await Populate(SmileYourDayTaskList.instance.host, imageOne);
        await Populate(SmileYourDayTaskList.instance.client, imageTwo);
    }
    public async Task Populate(SteamId ID_FRIEND, RawImage var)
    {
        //meRightNow = ID_FRIEND;
        Steamworks.Data.Image? im = await SteamFriends.GetSmallAvatarAsync(ID_FRIEND);
        var.texture = Convert(im.Value);
        
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
