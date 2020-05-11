
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayOneSound : MonoBehaviour
{
    [HideInInspector]
    public bool declencherAudio = false;

    [SerializeField]
    private TYPE_AUDIO typeAudio;

    private SoundManager soundManager;
    private Sound soundToPlay;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        audioSource = GetComponent<AudioSource>();
        soundToPlay = GetAudio(typeAudio, soundManager.allSounds);
        if (soundToPlay != null)
        {
            audioSource.clip = soundToPlay.audio;
            audioSource.loop = soundToPlay.loop;
            audioSource.volume = soundToPlay.volume;
            if (soundToPlay.playOnAwake)
            {
                PlaySound();
            }
        }
        else
        {
            Debug.LogError("AUCUN AUDIO POUR CE TYPE D'AUDIO REFERENCER DANS SOUNDMANAGER");
        }

    }

    public Sound GetAudio(TYPE_AUDIO typeAudio, Sound[] allSounds)
    {
        foreach (Sound soundSelected in allSounds)
        {
            if (soundSelected.audioFor == typeAudio)
            {
                return soundSelected;
            }
        }
        return null;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

}
