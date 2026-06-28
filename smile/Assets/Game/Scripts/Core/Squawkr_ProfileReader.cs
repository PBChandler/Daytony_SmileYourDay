using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections.Generic;
public class Squawkr_ProfileReader : MonoBehaviour
{
    public TextMeshProUGUI profileName, handle, biography, followerCount, retweetCount, likeCount;
    public Image pfpDisplay;

    public SquawkrProfileScriptableObject profile;

    public List<SquawkrLoader> loader = new List<SquawkrLoader>();
    public void Start()
    {
        Load();
    }
    public void Load()
    {
        profileName.text = profile.DisplayName;
        handle.text = profile.Handle;
        biography.text = profile.bio;
        followerCount.text = profile.followerCount+"";
        retweetCount.text = profile.retweetCount+"";
        likeCount.text = profile.likeCount+"";

        for(int i = 0; i < profile.Posts.Count; i++)
        {
            loader[i].LoadSquawk(profile.Posts[i]);
        }
    }
}
