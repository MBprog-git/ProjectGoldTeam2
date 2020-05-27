using UnityEngine;

public enum TYPE_AUDIO
{
    None,
    MusiqueAmbianceSoleil,
    MusiqueAmbianceDemiLune,
    MusiqueAmbianceLune,
    MusiqueMainMenu,
    SfxChucotement,
    SfxDechirement1,
    SfxDechirement2,
    SfxPeleMeleOuverture1,
    SfxPeleMeleOuverture2,
    SfxPeleMeleOuverture3,
    SfxPolaroid1,
    SfxPolaroid2,
    SfxPolaroid3,
    BruitPas,
    SfxPhotoShadowLoin,
    SfxPhotoShadowMi,
    SfxPhotoShadowProche,
    SfxFermePele1,
    SfxFermePele2,
    SfxFermePele3,
    SfxCorbeau1,
    SfxCorbeau2,
    SfxCloche,
    Running,
    SlamDoor

}

[System.Serializable]
public class Sound
{
    public TYPE_AUDIO audioFor;
    public AudioClip audio;
    [Range(0.0f, 1.0f)]
    public float volume = 1.0f;
    public bool loop;
    public bool playOnAwake;
}