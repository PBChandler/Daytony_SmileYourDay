using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class SkipCutsceneLogic : MonoBehaviour
{
    public bool keyHeld;
    public Image heldImage;
    public float progression;
    public float timeRequired = 1f;
    public GameObject container;
    public bool buttonPressedAtAll;
    public PlayableDirector direct;
    public float jumpToTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyHeld = Input.anyKey;
        if(keyHeld)
        {
            progression += Time.deltaTime;
            buttonPressedAtAll = true;
            if(progression >= timeRequired)
            {
                direct.time = jumpToTime;
            }
        }
        else
        {
            if (progression > 0)
                progression -= Time.deltaTime;
        }

        heldImage.fillAmount = progression / timeRequired;
        container.SetActive(buttonPressedAtAll);
    }
}
