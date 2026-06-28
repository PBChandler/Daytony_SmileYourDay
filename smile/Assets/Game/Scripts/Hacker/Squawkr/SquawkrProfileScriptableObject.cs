using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/New Squawkr Profile", order = 1)]
public class SquawkrProfileScriptableObject : ScriptableObject
{
    public Sprite profilePicture;
    public string DisplayName, Handle;
    public string bio;
    public int followerCount, likeCount, retweetCount;
    public List<SquawkrPost> Posts;
}

[System.Serializable]
public class SquawkrPost
{
    public string TweetText;
    public string Date;
    public string Time;
    public string SentFrom;

    public float likeCount;
    public float retweetCount;

    [Header("Reply Only Variant")]

    public List<SquawkrReply> replies;
}

[System.Serializable]
public class SquawkrReply
{
    public SquawkrProfileScriptableObject profile;
    public SquawkrPost replyContext;
}
