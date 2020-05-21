using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public Sound[] allSounds;

    [HideInInspector]
    public bool ActiveMusic = true;
    [HideInInspector]
    public float volumeMusique = 1.0f;

    [SerializeField]
    private Slider sliderVolume;

    private void Start()
    {
        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SwitchActiveMusique()
    {
       ActiveMusic = !ActiveMusic;
    }

    public void SetVolumeMusique()
    {
        volumeMusique = sliderVolume.value;
    }
}
