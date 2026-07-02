using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SquawkrLoader : MonoBehaviour
{
    public Image profilePicture;
    public TextMeshProUGUI DisplayName, Handle, SquawkContent, Date, Time, Likes, Parrots, ReplyCount;

    public SquawkrProfileScriptableObject profile;

    public Vector3 basePos;

    [ContextMenu("Wing Your Ding (Set Base Position)")]
    public void setBasePos()
    {
         basePos = transform.parent.localPosition;
    }

    
    public void Start()
    {
       
        try
        {
            LoadSquawk(profile, profile.Posts[0]);
        }catch{}
        
    }

    public void LoadBlankSquawk()
    {
     //   transform.GetChild(0).gameObject.SetActive(false);
    }
    public void LoadSquawk(SquawkrProfileScriptableObject profiley, SquawkrPost post)
    {
//         transform.GetChild(0).gameObject.SetActive(true);
        profile = profiley;
        DisplayName.text = profile.DisplayName;
        Handle.text = profile.Handle;
        SquawkContent.text = post.TweetText;
        Date.text = post.Date + " " + post.Time + "";
        transform.parent.transform.localPosition = basePos;  
        Likes.text = post.likeCount+"";
        Parrots.text = post.retweetCount+"";
        profilePicture.sprite = profile.profilePicture;
    }

    public void HideSquawk()
    {
        transform.parent.localPosition = new Vector3(24601, 24601, 24601);
    }

}
