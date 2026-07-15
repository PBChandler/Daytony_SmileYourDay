using System.Collections.Generic;
using UnityEngine;

public class FootStepManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip snd_default, snd_concrete, snd_asphalt, snd_carpet, snd_wood, snd_blood; //lol we do not have the time to do all this
    public List<AudioClip> randomSounds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerFootstep()
    {
        source.volume = 0.2f;
        source.pitch = Random.Range(0.7f, 1.2f);
        source.PlayOneShot(randomSounds[Random.Range(0, randomSounds.Count)]);
    }

    public void TriggerQuietStep()
    {
        source.volume = 0.02f;
        source.pitch = Random.Range(0.7f, 1.2f);
        source.PlayOneShot(randomSounds[Random.Range(0, randomSounds.Count)]);
    }

}
