using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class Testing_MissiveResponder : MonoBehaviour
{
    public string messageToListenFor;
    public UnityEvent whatItDo;
    void Start()
    {
        SmileYourDaySteam.PostToEveryone_dg += Chudling;
    }

    public void Chudling(string message)
    {
        Debug.Log(gameObject.name + "has reported it recieved " + message + "from the SmileYourDaySteam script.");
        if(message.ToLower() == messageToListenFor.ToLower()) //just making it not case sensitive.
        {
            whatItDo.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
