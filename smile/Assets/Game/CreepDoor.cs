using UnityEngine;

public class CreepDoor : MonoBehaviour
{
    public Vector3 whenopened;
    public Vector3 whenopened_eulers;
    public void Update()
    {
        if(SmileYourDayTaskList.instance.garments)
        {
            transform.position = whenopened;
            transform.rotation = Quaternion.Euler(whenopened_eulers);
        }
    }
}
