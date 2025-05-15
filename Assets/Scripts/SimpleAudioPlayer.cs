using UnityEngine;

public class SimpleAudioPlayer : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    void Awake()
    {
        // Get or add audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("SimpleAudioPlayer: Added AudioSource");
        }
        
        // Set properties
        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        
        Debug.Log("SimpleAudioPlayer initialized with AudioSource: " + 
                 (audioSource != null ? "Found" : "Missing") + ", SoundClip: " + 
                 (soundClip != null ? "Found" : "Missing"));
    }

    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            Debug.Log("SimpleAudioPlayer: About to play sound");
            audioSource.clip = soundClip;
            audioSource.Play();
            Debug.Log("SimpleAudioPlayer: Sound played");
        }
        else
        {
            if (audioSource == null)
                Debug.LogError("SimpleAudioPlayer: Cannot play - AudioSource missing");
            else
                Debug.LogError("SimpleAudioPlayer: Cannot play - SoundClip missing");
        }
    }
}