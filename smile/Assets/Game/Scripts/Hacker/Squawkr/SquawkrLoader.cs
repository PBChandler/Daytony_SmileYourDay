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
        try
        {
            LoadSquawk(profile, profile.Posts[0]);
        }catch{}
        
    }
    public void LoadSquawk(SquawkrProfileScriptableObject profiley, SquawkrPost post)
    {
        profile = profiley;
        DisplayName.text = profile.DisplayName;
        Handle.text = profile.Handle;
        SquawkContent.text = post.TweetText;
        Date.text = post.Date + " " + post.Time + "" + post.SentFrom;
        
        Likes.text = post.likeCount+"";
        Parrots.text = post.retweetCount+"";
        profilePicture.sprite = profile.profilePicture;
    }

}
