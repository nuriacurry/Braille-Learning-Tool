using System.Collections.Generic;
using UnityEngine;

public class BrailleGridManager : MonoBehaviour
{
    public BrailleDotButton[] brailleButtons;
    
    private AudioSource audioSource;
    private Dictionary<char, bool[]> braillePatterns = new Dictionary<char, bool[]>();
    
    void Start()
    {
        // Get audio source and disable auto-play
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
        
        // Auto-find buttons if not assigned
        if (brailleButtons == null || brailleButtons.Length < 6)
        {
            Debug.Log("Finding Braille buttons automatically...");
            BrailleDotButton[] foundButtons = FindObjectsOfType<BrailleDotButton>();
            
            System.Array.Sort(foundButtons, (a, b) => a.buttonId.CompareTo(b.buttonId));
            
            if (foundButtons.Length >= 6)
            {
                brailleButtons = new BrailleDotButton[6];
                for (int i = 0; i < 6; i++)
                {
                    brailleButtons[i] = foundButtons[i];
                }
                Debug.Log("Found and assigned " + brailleButtons.Length + " buttons.");
            }
            else
            {
                Debug.LogError("Not enough Braille buttons found: " + foundButtons.Length);
            }
        }
        
        AssignButtonSounds();
        InitializeBraillePatterns();
        Debug.Log("Braille Grid Manager initialized");
    }
    
    void AssignButtonSounds()
    {
        if (brailleButtons == null || brailleButtons.Length < 6) return;
        
        // Find sounds
        AudioClip doSound = Resources.Load<AudioClip>("Do");
        AudioClip reSound = Resources.Load<AudioClip>("Re");
        AudioClip miSound = Resources.Load<AudioClip>("Mi");
        AudioClip faSound = Resources.Load<AudioClip>("Fa");
        AudioClip solSound = Resources.Load<AudioClip>("So");
        AudioClip laSound = Resources.Load<AudioClip>("La");
        
        // Try alternate paths if not found
        if (doSound == null) doSound = Resources.Load<AudioClip>("Sounds/Do");
        if (reSound == null) reSound = Resources.Load<AudioClip>("Sounds/Re");
        if (miSound == null) miSound = Resources.Load<AudioClip>("Sounds/Mi");
        if (faSound == null) faSound = Resources.Load<AudioClip>("Sounds/Fa");
        if (solSound == null) solSound = Resources.Load<AudioClip>("Sounds/So");
        if (laSound == null) laSound = Resources.Load<AudioClip>("Sounds/La");
        
        // Assign to buttons
        if (doSound != null) brailleButtons[0].buttonSound = doSound;
        if (reSound != null) brailleButtons[1].buttonSound = reSound;  
        if (miSound != null) brailleButtons[2].buttonSound = miSound;  
        if (faSound != null) brailleButtons[3].buttonSound = faSound;  
        if (solSound != null) brailleButtons[4].buttonSound = solSound;
        if (laSound != null) brailleButtons[5].buttonSound = laSound;  
    }
    
    void InitializeBraillePatterns()
    {
        braillePatterns.Add('A', new bool[] { true, false, false, false, false, false });
        braillePatterns.Add('B', new bool[] { true, true, false, false, false, false });
        braillePatterns.Add('C', new bool[] { true, false, false, true, false, false });
        // Add more letters as needed
    }
    
    public void DisplayLetter(char letter)
    {
        letter = char.ToUpper(letter);
        
        if (braillePatterns.ContainsKey(letter))
        {
            bool[] pattern = braillePatterns[letter];
            
            // Update buttons using only public methods
            for (int i = 0; i < brailleButtons.Length && i < pattern.Length; i++)
            {
                // Call the public SetSelected method instead of directly setting isSelected
                if (brailleButtons[i] != null)
                {
                    brailleButtons[i].SetSelected(pattern[i]);
                    
                    // No need to call UpdateVisuals() as SetSelected() will do that internally
                }
            }
            
            // Update AudioManager
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.SetActiveButtons(pattern, letter);
            }
            
            Debug.Log("Displaying letter: " + letter);
        }
        else
        {
            Debug.LogWarning("No pattern for letter: " + letter);
        }
    }
    
    public void ResetAllButtons()
    {
        foreach (var button in brailleButtons)
        {
            if (button != null)
            {
                // Call the public ResetButton method
                button.ResetButton();
            }
        }
    }
    
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    
    public void PlayButtonSound(int buttonId)
    {
        if (buttonId >= 0 && buttonId < brailleButtons.Length)
        {
            BrailleDotButton button = brailleButtons[buttonId];
            if (button != null && button.buttonSound != null)
            {
                PlaySound(button.buttonSound);
            }
        }
    }
    
    public BrailleDotButton GetButtonById(int buttonId)
    {
        foreach (var button in brailleButtons)
        {
            if (button != null && button.buttonId == buttonId)
            {
                return button;
            }
        }
        return null;
    }
}