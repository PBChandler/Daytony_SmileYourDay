using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;

public class HackerCameraPairer : MonoBehaviour
{
    //todo:
    //make it so this creates the scriptableobject from the object this is placed on position, has to save to the asset thing.
    public string id;
    [ContextMenu("Create Object from this Location")]
    public void CreateScriptableObject()
    {
        SO_HackerCameraOBJ obj = new SO_HackerCameraOBJ();
        obj.position = transform.position;
        obj.rotationEulers = transform.rotation.eulerAngles;
        obj.floor = 0;

        AssetDatabase.CreateAsset (obj, "Assets/Resources/"+id+".asset");
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = obj;
    }

}
