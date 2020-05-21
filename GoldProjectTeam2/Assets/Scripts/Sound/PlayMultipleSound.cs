
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayMultipleSound : MonoBehaviour
{

    [SerializeField]
    private TYPE_AUDIO[] typeAudio;

    private SoundManager soundManager;
    private Sound[] soundsToPlay;
    private AudioSource audioSource;
    private TYPE_AUDIO typeAudioPlaying;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        audioSource = GetComponent<AudioSource>();
        soundsToPlay = GetAllAudio(typeAudio, soundManager.allSounds);
        CheckForPlaySoundOnAwake();
    }

    private void Update()
    {
        audioSource.volume = soundManager.volumeMusique;
        if (!soundManager.ActiveMusic)
        {
            audioSource.Stop();
            return;
        }
        else if (soundManager.ActiveMusic && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
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
        if (!soundManager.ActiveMusic)
        {
            audioSource.Stop();
            return;
        }
        for (int i = 0; i < soundsToPlay.Length; i++)
        {
            if (soundsToPlay[i].audioFor == typeAudio)
            {
                audioSource.Stop();
                audioSource.clip = soundsToPlay[i].audio;
                audioSource.loop = soundsToPlay[i].loop;
                audioSource.Play();
                typeAudioPlaying = soundsToPlay[i].audioFor;
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
                if (!soundManager.ActiveMusic)
                {
                    return;
                }
                audioSource.Play();
                typeAudioPlaying = soundsToPlay[i].audioFor;
                return;
            }
        }
    }

    public TYPE_AUDIO GetEnumOfAudioPlaying()
    {
        return typeAudioPlaying;
    }

}
