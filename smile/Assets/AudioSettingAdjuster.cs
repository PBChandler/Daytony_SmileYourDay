using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingAdjuster : MonoBehaviour
{
    public AudioMixer mixing;
    public string id;

    public void OnEnable()
    {
        Invoke("setup", 0f);
    }
    public void setup()
    {
        if(PlayerPrefs.GetFloat("Master") == 0f)
        {
            PlayerPrefs.SetFloat("Master", 0.6f);
            PlayerPrefs.SetFloat("Music", 1f);
            PlayerPrefs.SetFloat("Sounds", 1f);
            PlayerPrefs.SetFloat("Voices", 1f);
        }
        else
        {
            mixing.SetFloat(id, PlayerPrefs.GetFloat(id));
        }
        float f = 0.0f;
        mixing.GetFloat(id, out f);
        GetComponent<Slider>().value = f;
        GetComponent<Slider>().onValueChanged.Invoke(f);
    }
    public void SetAudioMixerVolume(float reactive)
    {
        mixing.SetFloat(id, reactive);
        PlayerPrefs.SetFloat(id, reactive);
    }
}
