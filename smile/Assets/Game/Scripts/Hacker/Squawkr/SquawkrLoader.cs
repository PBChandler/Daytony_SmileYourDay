using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SquawkrLoader : MonoBehaviour
{
    public Image profilePicture;
    public TextMeshProUGUI DisplayName, Handle, SquawkContent, Date, Time, Likes, Parrots, ReplyCount;

    public SquawkrProfileScriptableObject profile;

    public void Start()
    {
        LoadSquawk(profile.Posts[0]);
    }
    public void LoadSquawk(SquawkrPost post)
    {
        DisplayName.text = profile.DisplayName;
        Handle.text = profile.Handle;
        SquawkContent.text = post.TweetText;
        Date.text = post.Date + " " + post.Time + "" + post.SentFrom;
        
        Likes.text = "Likes:" + post.likeCount+"";
        Parrots.text = "Parrots:" + post.retweetCount;
        profilePicture.sprite = profile.profilePicture;
    }

}
