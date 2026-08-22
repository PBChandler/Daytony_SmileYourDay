using System.Collections;
using TMPro;
using UnityEngine;

public class GamerText : MonoBehaviour
{
    public TextMeshProUGUI me;
    
    void Start()
    {
        SmileYourDayTaskList.instance.gamerText = this;
    }

    public void SetText(string text, float duration)
    {
        me.color = Color.white;
        me.text = text;
        StartCoroutine(chark(duration));
    }

    public IEnumerator chark(float boo)
    {
        yield return new WaitForSeconds(boo);
        while(me.color.a > 0)
        {
            me.color = new Color(me.color.r, me.color.g, me.color.b, me.color.a - (Time.deltaTime*0.2f));
            yield return new WaitForEndOfFrame();
        }
        me.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
