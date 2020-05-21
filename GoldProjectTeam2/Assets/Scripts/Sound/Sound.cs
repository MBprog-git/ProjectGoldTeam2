using UnityEngine;

public enum TYPE_AUDIO
{
    MusiqueAmbianceSoleil,
    MusiqueAmbianceDemiLune,
    MusiqueAmbianceLune
}

[System.Serializable]
public class Sound
{
    public TYPE_AUDIO audioFor;
    public AudioClip audio;
    public bool loop;
    public bool playOnAwake;
}