using UnityEngine;

// I LIKE MY PILLOW!!!
public class RemRenderCam : MonoBehaviour
{
    public Transform deadlock, portal;
    public bool justRotation = false;
    public Transform basepos;
    public Quaternion deadWeight;
    public void Update()
    {
        if(deadlock == null || !deadlock.gameObject.activeSelf)
        {
            try
            {
                deadlock = GameObject.Find("EYES").transform;
                
            }
            catch
            {
                //try, try again.
            }
        }
        else
        {
            if(justRotation)
            {
                if(portal == null)
                {
                    portal = GameObject.Find("PORTAL").transform;

                }
                else
                {
                    transform.position = basepos.position + (deadlock.transform.position - portal.transform.position); 
                    float f = (deadlock.transform.position - portal.transform.position).magnitude;
                    f = Mathf.Clamp(f, -999, 0);
                    deadWeight = Quaternion.Euler(-f,-f,-f);
                    //transform.rotation = transform.rotation * deadlock.transform.rotation;
                }
               // transform.localPosition = deadlock.transform.position - transform.position;
                transform.rotation = deadlock.rotation * deadWeight;
                return;
            }
            transform.parent = deadlock;
            transform.localPosition = Vector3.zero;
            transform.rotation.Set(0,0,0,0);
        }
    }
}
