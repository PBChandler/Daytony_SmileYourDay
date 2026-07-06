using System.Collections.Generic;
using UnityEngine;

public class SquawkHubManager : MonoBehaviour
{
    public List<SquawkrProfileScriptableObject> profiles = new List<SquawkrProfileScriptableObject>();
    public List<SquawkrLoader> homepagetweets = new List<SquawkrLoader>();

    public List<SquawkrPost> posts;
    void Start()
    {
        LoadFunny();
    }

    public void LoadFunny()
    {
        for(int i = 0; i <homepagetweets.Count; i++)
        {
            SquawkrProfileScriptableObject sauce = profiles[i];
            homepagetweets[i].LoadSquawk(sauce, sauce.Posts[(int)Random.Range(0, sauce.Posts.Count)]);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
