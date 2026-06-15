using UnityEngine;

[CreateAssetMenu(fileName = "EncounterDialog", menuName = "ScriptableObjects/New Encounter Dialog")]
public class EncounterDialog : ScriptableObject
{
    public string dialog;
    public string correctDialog;
    public string okDialog;
    public string badDialog;

    public string correctAnswer;
    public string okAnswer;
    public string badAnswer;
}
