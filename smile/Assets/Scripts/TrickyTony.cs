using NUnit.Framework;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class TrickyTony : MonoBehaviour
{
    public GameObject trickwall;
    public List<GameObject> items;
    int state = 0;

    public bool firstOne;
    public TrickyTony friend;
    public void OnTriggerEnter(Collider other)
    {
        if(firstOne)
        {
            if (state == 0)
            {
                if (other.tag.ToLower() == "runner")
                {
                    trickwall.SetActive(true);
                    state = 1;
                }
            }

            if (state == 3) // the player has returned after going to the fake wall
            {
                if (other.tag.ToLower() == "runner")
                {
                    
                    trickwall.SetActive(false);
                }
            }
        }
        else
        {
            if(friend.state == 1)
            {
                friend.state = 3;
                foreach (GameObject g in items)
                {
                    g.SetActive(false);
                }
                Destroy(gameObject);
            }
            
        }
        
        
    }
}
