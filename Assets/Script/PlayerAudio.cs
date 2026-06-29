using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip walk;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip attack;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip dash;
    public AudioClip pickup;

    public void PlayWalk()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(walk);
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void PlayLand()
    {
        audioSource.PlayOneShot(land);
    }

    public void PlayAttack()
    {
        audioSource.PlayOneShot(attack);
    }

    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurt);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(death);
    }

    public void PlayDash()
    {
        audioSource.PlayOneShot(dash);
    }

    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup);
    }
}