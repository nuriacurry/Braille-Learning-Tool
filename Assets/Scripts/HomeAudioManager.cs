using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeAudioManager : MonoBehaviour
{
    public static HomeAudioManager instance;
    
    public AudioSource audioSource;
    public AudioClip homeScreenInstructions;
    public AudioClip aboutScreenInstructions;
    public AudioClip learningModeInstructions;
    public AudioClip practiceModeInstructions;
    
    void Awake()
    {
        // Singleton pattern to persist across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
    
    // Called when a new scene is loaded
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play different instructions based on scene name
        if (scene.name == "HomeScene")
        {
            PlayHomeInstructions();
        }
        else if (scene.name == "About")
        {
            PlayAboutInstructions();
        }
        else if (scene.name == "LearningMode")
        {
            PlayLearningModeInstructions();
        }
        else if (scene.name == "PracticeMode")
        {
            PlayPracticeModeInstructions();
        }
    }
    
    public void PlayHomeInstructions()
    {
        if (homeScreenInstructions != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = homeScreenInstructions;
            audioSource.Play();
        }
    }
    
    public void PlayAboutInstructions()
    {
        if (aboutScreenInstructions != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = aboutScreenInstructions;
            audioSource.Play();
        }
    }
    
    public void PlayLearningModeInstructions()
    {
        if (learningModeInstructions != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = learningModeInstructions;
            audioSource.Play();
        }
    }
    
    public void PlayPracticeModeInstructions()
    {
        if (practiceModeInstructions != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = practiceModeInstructions;
            audioSource.Play();
        }
    }
    
    // Method to play any audio clip
    public void PlayAudioClip(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    
    // Method to stop currently playing audio
    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}