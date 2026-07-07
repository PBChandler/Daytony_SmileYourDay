using UnityEngine;

public class playerAnimationDetacher : MonoBehaviour
{
    public Transform host;
    public Transform heavenHost;
    public Vector3 offset = new Vector3(0, -1, 0);

    void Start()
    {
        transform.parent = heavenHost;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = host.position + offset;
        transform.rotation = host.rotation;
    }
}
