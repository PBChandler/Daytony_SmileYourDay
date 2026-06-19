using UnityEngine;

// I LIKE MY PILLOW!!!
public class RemRenderCam : MonoBehaviour
{
    public Transform deadlock;
    public void Update()
    {
        if(deadlock == null || !deadlock.gameObject.activeSelf)
        {
            try
            {
                deadlock = GameObject.Find("EYES").transform;
                deadlock.transform.localPosition = Vector3.zero;
            }
            catch
            {
                //try, try again.
            }
        }
        else
        {
            transform.parent = deadlock;
        }
    }
}
