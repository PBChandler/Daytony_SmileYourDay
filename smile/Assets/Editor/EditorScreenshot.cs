using UnityEngine;

public class EditorScreenshot : MonoBehaviour
{
    [ExecuteInEditMode]
    void Update()
    {
        // Press the K key to snap a screenshot
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            string fileName = "Screenshot_.png";
            
            // Captures Game View. '1' is normal size. Increase to '2' or '3' for super-sampling.
            ScreenCapture.CaptureScreenshot(fileName, 1); 
            
            Debug.Log("Screenshot saved to project root folder as: " + fileName);
        }
    }
}