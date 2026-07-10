using UnityEngine;

public class talkToTaskList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTaskList(string message)
    {
        SmileYourDayTaskList.instance.UpdateGameTask(message, 1);
    }
}
