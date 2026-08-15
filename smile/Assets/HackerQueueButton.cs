using TMPro;
using UnityEngine;

public class HackerQueueButton : MonoBehaviour
{
    private TextMeshProUGUI text;
    private EnemyStateMachine currentStateMachine;
   
    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void Set(EnemyStateMachine esm)
    {
        currentStateMachine = esm;
        text.text = esm.guardRadioID;
    }

    public void OnClick()
    {
        //todo: put them in the queue, make the buttons glowing and clickable so you know that's where you're sending them.
        SmileYourDayTaskList.instance.hackerQueue = true;
        //This code is correct but we don't have the radios paired to the CSM's now.
        SmileYourDayTaskList.instance.guardInQueue = currentStateMachine;
    }
}
