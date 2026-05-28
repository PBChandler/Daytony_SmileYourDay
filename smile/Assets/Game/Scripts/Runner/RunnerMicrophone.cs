using System.Collections;
using UnityEngine;

public class RunnerMicrophone : MonoBehaviour
{
    // script will probably be fiddled with at least a little but the general idea was taken from Louis Vanhove
    // https://medium.com/@louisvanhove/microphone-input-has-never-been-easier-in-unity-no-library-no-plugins-366062e7c74a

    [SerializeField] LayerMask enemiesnwalls;
    [SerializeField] LayerMask justenemies;
    string mic;
    AudioClip recording = null;
    int sampleWindow = 128;
    bool isInitialized = false;
    public static float micLoudness;
    Ray voiceCast;
    EnemyBehavior eBehavior;

    private void OnEnable()
    {
        InitializeMic();
        isInitialized = true;
    }

    private void OnDisable() => StopMic();

    private void OnDestroy() => StopMic();
    private void StopMic() => Microphone.End(mic);

    private void Update()
    {
        micLoudness = LevelMax();
        transform.localScale = Vector3.one * micLoudness * 5000;
    }

    private void InitializeMic()
    {
        if (mic == null) mic = Microphone.devices[0];
        recording = Microphone.Start(mic, true, 1, 44100);
    }

    private float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (sampleWindow + 1);

        if (micPosition < 0) return 0;

        recording.GetData(waveData, micPosition);

        for (int i = 0; i < sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];

            if (wavePeak > levelMax)
                levelMax = wavePeak;
        }
        return levelMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
            return;

        eBehavior = other.GetComponent<EnemyBehavior>();

        voiceCast.origin = transform.position;
        voiceCast.direction = (other.transform.position - voiceCast.origin).normalized;

        if (Physics.Raycast(voiceCast, out RaycastHit extraHit, transform.localScale.x / 2, justenemies))
        {
            if (extraHit.collider.tag == "Enemy")
                eBehavior.AddSuspicion(5);
        }
        else if (Physics.Raycast(voiceCast, out RaycastHit hit, transform.localScale.x, enemiesnwalls))
        {
            if (hit.collider.tag == "Enemy")
                eBehavior.AddSuspicion(5);
        }

    }

}
