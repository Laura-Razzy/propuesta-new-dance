using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip hitSFX;
    public AudioClip deathSFX;
    public AudioClip damageSFX;

    public void hitOneShot()
    {
        SFXSource.PlayOneShot(hitSFX);
    }

    public void deathOneShot()
    {
        SFXSource.PlayOneShot(deathSFX);
    }

    public void damageOneShot()
    {
        SFXSource.PlayOneShot(damageSFX);
    }
}
