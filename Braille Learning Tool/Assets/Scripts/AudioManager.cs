using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Singleton pattern
    public static AudioManager Instance;

    [Header("Button Sounds")]
    // Six unique sounds for each Braille dot
    public AudioClip[] dotSounds = new AudioClip[6];
    
    [Header("Feedback Sounds")]
    public AudioClip correctSound;
    public AudioClip selectionSound;
    
    // Audio source components
    private AudioSource effectsSource;
    
    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // Create audio source
        effectsSource = gameObject.AddComponent<AudioSource>();
    }
    
    // Play a specific dot sound (0-5)
    public void PlayDotSound(int dotIndex)
    {
        if (dotIndex >= 0 && dotIndex < dotSounds.Length && dotSounds[dotIndex] != null)
        {
            effectsSource.PlayOneShot(dotSounds[dotIndex]);
        }
    }
    
    // Play feedback sounds
    public void PlayCorrectSound()
    {
        effectsSource.PlayOneShot(correctSound);
    }
    
    public void PlaySelectionSound()
    {
        effectsSource.PlayOneShot(selectionSound);
    }
}