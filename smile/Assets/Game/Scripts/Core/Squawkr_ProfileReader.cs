using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.Collections;
public class Squawkr_ProfileReader : MonoBehaviour
{
    public TextMeshProUGUI profileName, handle, biography, followerCount, retweetCount, likeCount;
    public UnityEngine.UI.Image pfpDisplay;

    public SquawkrProfileScriptableObject profile;

    public List<SquawkrLoader> loader = new List<SquawkrLoader>();
    Vector3 pos;
    public void Start()
    {
       
        Load();
        
    }

    public void OnEnable()
    {
        Load();
    }
    int joe = 0;//mama
    public void Load()
    {
        profileName.text = profile.DisplayName;
        handle.text = profile.Handle;
        biography.text = profile.bio;
        followerCount.text = profile.followerCount+"";
        retweetCount.text = profile.retweetCount+"";
        likeCount.text = profile.likeCount+"";
        int overflowIndex = 0;
        for(int i = 0; i < loader.Count; i++)
        {
            //loader[i].gameObject.SetActive(true);
            try
            {
             
                loader[i].LoadSquawk(profile, profile.Posts[i]);
            }
            catch
            {
                StartCoroutine(bigshotLoader(i));
            }
           
            overflowIndex = i;
        }
       
        pfpDisplay.sprite = profile.profilePicture;
    }

    public void bigshot()
    {
        
    }

    IEnumerator bigshotLoader(int ludwig)
    {
        yield return new WaitForSeconds(0.05f);
       // loader[ludwig].HideSquawk();
    }
}


