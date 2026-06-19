using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public HackerCamera epic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(epic != null) return;
        try
        {
            epic = GameObject.Find("1_PAGE").GetComponent<HackerCamera>();
            epic.cam = GetComponent<Camera>();
        }catch{}

    }
}
