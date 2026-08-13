using UnityEngine;

public class levitator : MonoBehaviour
{
    public float moveSpeed = 20f;

    public void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}
