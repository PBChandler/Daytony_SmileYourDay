using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class ToothblueGrouper : MonoBehaviour
{
    public List<HackerQueueButton> hackerQueueOptions = new List<HackerQueueButton>();

    public void OnEnable()
    {
        SmileYourDayTaskList.instance.toothblue = this;   
    }

    public void Initialize(List<EnemyStateMachine> jamesajanneise)
    {
        for (int i = 0; i < hackerQueueOptions.Count; i++)
        {
            hackerQueueOptions[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < hackerQueueOptions.Count; i++)
        {
            hackerQueueOptions[i].gameObject.SetActive(true);
            hackerQueueOptions[i].Set(jamesajanneise[i]);
            //for(int j = 0; j < jamesajanneise.Count; j++)
            //{
                
            //}
        }
    }
}
