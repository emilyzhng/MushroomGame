using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bookOpenSound;
    public AudioClip collectSound;

    public AudioClip[] footstepSounds;
    public AudioClip buttonclick;

    public void OpenBook()
    {
        audioSource.PlayOneShot(bookOpenSound);
    }

    public void FootStep()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[randomIndex]);
        }
    }

    public void ButtonClick()
    {
        audioSource.PlayOneShot(buttonclick);
    }

    public void CollectObject()
    {
        audioSource.PlayOneShot(collectSound);
    }
}