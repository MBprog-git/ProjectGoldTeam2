
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayMultipleSound : MonoBehaviour
{
    [HideInInspector]
    public bool declencherAudio = false;

    [SerializeField]
    private TYPE_AUDIO[] typeAudio;

    private SoundManager soundManager;
    private Sound[] soundsToPlay;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        audioSource = GetComponent<AudioSource>();
        soundsToPlay = GetAllAudio(typeAudio, soundManager.allSounds);
        CheckForPlaySoundOnAwake();
    }

    public Sound[] GetAllAudio(TYPE_AUDIO[] typeAudio, Sound[] allSounds)
    {
        Sound[] newListSound = new Sound[typeAudio.Length];
        int nombreAjout = 0;
        for (int i = 0; i < allSounds.Length; i++)
        {
            for (int j = 0; j < typeAudio.Length; j++)
            {
                if (allSounds[i].audioFor == typeAudio[j])
                {
                    newListSound[nombreAjout] = allSounds[i];
                    nombreAjout++;
                    break;
                }
            }
        }
        
        return newListSound;
    }

    public void PlaySound(TYPE_AUDIO typeAudio)
    {
        declencherAudio = true;
        for (int i = 0; i < soundsToPlay.Length; i++)
        {
            if (soundsToPlay[i].audioFor == typeAudio)
            {
                audioSource.Stop();
                audioSource.clip = soundsToPlay[i].audio;
                audioSource.loop = soundsToPlay[i].loop;
                audioSource.Play();
                return;
            }
        }
    }

    public void CheckForPlaySoundOnAwake()
    {
        for (int i = 0; i < soundsToPlay.Length; i++)
        {
            if (soundsToPlay[i].playOnAwake && !audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = soundsToPlay[i].audio;
                audioSource.loop = soundsToPlay[i].loop;
                audioSource.Play();
                return;
            }
        }
    }

}
