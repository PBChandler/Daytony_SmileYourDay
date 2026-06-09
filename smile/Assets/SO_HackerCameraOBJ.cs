using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/New Hacker Camera Position", order = 1)]
public class SO_HackerCameraOBJ : ScriptableObject
{
    public Vector3 position;
    public Vector3 rotationEulers;
    public Vector2 gameplayRotateBounds;

    public int floor; //what floor can this camera be accessed on
    public bool lockedByDefault; //camera can't be accessed until Runner does something perchance.
}
