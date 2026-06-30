using UnityEngine;

public class funnyscrollwheel : MonoBehaviour
{
    public float ses;
    public float clampValue;

    public RectTransform me;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(-Input.mouseScrollDelta.y < 0 && me.transform.localPosition.y < clampValue) return;
        transform.position = new Vector3(transform.position.x, transform.position.y + (-Input.mouseScrollDelta.y * ses), transform.position.z);
    }
}
