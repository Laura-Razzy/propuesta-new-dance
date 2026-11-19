using UnityEngine;

public class DanceAudioManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip wellDoneSFX;
    public AudioClip noteHitSFX;
    public AudioClip victorySFX;

    public void wellDoneOneShot()
    {
        SFXSource.PlayOneShot(wellDoneSFX);
    }

    public void notehitOneShot()
    {
        SFXSource.PlayOneShot(noteHitSFX);
    }

    public void victoryOneShot()
    {
        SFXSource.PlayOneShot(victorySFX);
    }
}
