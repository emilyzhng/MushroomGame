using UnityEngine;
public class SimpleBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime = 3.0f;

    void Start()
    {
        Invoke(nameof(PlayMusic), 5f);
    }

    void PlayMusic()
    {
        audioSource.Play();
        Invoke("PlayMusic", audioSource.clip.length + 20f);
    }
    void Update()
    {
        if (!audioSource.isPlaying) return;

        if (audioSource.time < fadeTime) //fade in
        {
            audioSource.volume = audioSource.time / fadeTime;
        }
        else if (audioSource.time > audioSource.clip.length - fadeTime) //fade out
        {
            audioSource.volume = (audioSource.clip.length - audioSource.time) / fadeTime;
        }
        else 
        {
            audioSource.volume = 0.707f;
        }
    }
}
