using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    private AudioSource audioSource;
    private bool[] activeButtons = new bool[6];
    private char currentLetter = 'A';
    
    private void Awake()
    {
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
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.playOnAwake = false;
        
        for (int i = 0; i < activeButtons.Length; i++)
        {
            activeButtons[i] = false;
        }
        
        activeButtons[0] = true;
    }
    
    public void SetActiveButtons(bool[] pattern, char letter)
    {
        currentLetter = letter;
        
        for (int i = 0; i < activeButtons.Length; i++)
        {
            activeButtons[i] = false;
        }
        
        for (int i = 0; i < pattern.Length && i < activeButtons.Length; i++)
        {
            activeButtons[i] = pattern[i];
        }
        
        Debug.Log("Active buttons updated for letter " + letter + ": " + string.Join(", ", activeButtons));
    }
    
    public void PlaySound(AudioClip clip, int buttonId)
    {
        if (currentLetter == 'A' && buttonId != 0)
        {
            Debug.Log("Button " + buttonId + " won't play for letter A");
            return;
        }
        
        if (buttonId < 0 || buttonId >= activeButtons.Length)
        {
            return;
        }
        
        if (activeButtons[buttonId])
        {
            if (clip != null && audioSource != null)
            {
                Debug.Log("Playing sound for button " + buttonId);
                audioSource.PlayOneShot(clip);
            }
        }
        else
        {
            Debug.Log("Button " + buttonId + " is not active, no sound played");
        }
    }
    
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}