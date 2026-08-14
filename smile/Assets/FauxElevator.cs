using UnityEngine;

public class FauxElevator : MonoBehaviour
{
    public float cap = 26f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
    }
}
