using UnityEngine;

public class fixkillplane : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.transform.position += new Vector3(0, 20, 0);
    }
}
