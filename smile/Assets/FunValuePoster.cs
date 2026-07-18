using UnityEngine;

public class FunValuePoster : MonoBehaviour
{
    public int funValueMinimum, funValueMaximum;
    public Material normal, scary;
    public void Start()
    {
        SmileYourDayTaskList.instance.dg_onFunValueChanged += Check;
        Check(SmileYourDayTaskList.instance.funValue.Value);
    }

    public void Check(int newValue)
    {
        Debug.Log("FUN FUN FUN");
        if(newValue >= funValueMinimum && newValue <= funValueMaximum)
        {
            GetComponent<MeshRenderer>().material = scary;
        }
        else
        {
            GetComponent<MeshRenderer>().material = normal;
        }
    }

    public void OnDestroy()
    {
        SmileYourDayTaskList.instance.dg_onFunValueChanged -= Check;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            SmileYourDayTaskList.instance.funValue.Value = Random.Range(0, 100);
            SmileYourDayTaskList.instance.dg_onFunValueChanged(SmileYourDayTaskList.instance.funValue.Value);
        }
    }
}
