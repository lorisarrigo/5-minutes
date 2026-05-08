using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [HideInInspector] public AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void PlayBg(AudioClip audioClip, float volume = 1f)
    {
        StartCoroutine(PlayBgMusic(audioClip, volume));
    }

    IEnumerator PlayBgMusic(AudioClip audioClip, float volume = 1f)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource);
    }
    private void Update()
    {
        if (audioSource == null) return;
        if (Time.timeScale == 0)
        {
            audioSource.Pause();
        }
        else if (Time.timeScale == 1f)
        {
            audioSource.UnPause();
        }
    }
}