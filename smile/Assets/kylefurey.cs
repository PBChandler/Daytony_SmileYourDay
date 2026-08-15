using UnityEngine;

public class kylefurey : MonoBehaviour
{
    public float shakeStrength = 3.0f;
    private Vector3 originalRotation;
    bool flip;
    public RectTransform me;
    void Start()
    {
        //deparent //#stealingfromdeadlock
        me = GetComponent<RectTransform>();
        originalRotation = me.transform.rotation.eulerAngles;
        transform.GetChild(0).transform.parent = transform.parent;
        InvokeRepeating("ShakeALil", Random.Range(0, 0.6f), 0.4f);
    }

    public void ShakeALil()
    {
        flip = !flip;
        if(flip)
        {
            transform.Rotate(0, 0, 1);
        }
        else
        {
            transform.Rotate(0, 0, -1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
