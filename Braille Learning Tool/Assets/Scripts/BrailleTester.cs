using UnityEngine;
using UnityEngine.UI;

public class BrailleTester : MonoBehaviour
{
    // Reference to UI elements (to be connected in Inspector)
    public Text characterDisplay;
    public Text descriptionDisplay;
    public Text exampleWordDisplay;
    public Image[] dotImages = new Image[6]; // Array of 6 dot images
    
    // Current character being displayed
    private char currentCharacter = 'A';
    
    void Start()
    {
        // Wait a frame to ensure BrailleDatabase is initialized
        Invoke("UpdateDisplay", 0.1f);
    }
    
    // Update the display with current character
    void UpdateDisplay()
    {
        // Check if database exists
        if (BrailleDatabase.Instance == null)
        {
            Debug.LogError("BrailleDatabase not found! Make sure it's in the scene.");
            return;
        }
        
        // Get pattern for current character
        bool[] pattern = BrailleDatabase.Instance.GetPatternForCharacter(currentCharacter);
        
        // Update text displays
        characterDisplay.text = currentCharacter.ToString();
        descriptionDisplay.text = BrailleDatabase.Instance.GetAudioDescription(currentCharacter);
        
        // If it's a letter, show example word
        if (char.IsLetter(currentCharacter))
        {
            string exampleWord = BrailleDatabase.Instance.GetExampleWord(currentCharacter);
            exampleWordDisplay.text = "Example: " + exampleWord;
            exampleWordDisplay.gameObject.SetActive(true);
        }
        else
        {
            exampleWordDisplay.gameObject.SetActive(false);
        }
        
        // Update dot colors
        for (int i = 0; i < 6; i++)
        {
            // If this dot is active in the pattern, color it black
            dotImages[i].color = pattern[i] ? Color.black : Color.white;
        }
        
        // Debug print pattern to console
        BrailleDatabase.Instance.DebugPrintPattern(currentCharacter);
    }
    
    // Button functions to navigate characters
    public void NextLetter()
    {
        if (currentCharacter >= 'A' && currentCharacter < 'Z')
        {
            currentCharacter = (char)(currentCharacter + 1);
        }
        else if (currentCharacter == 'Z')
        {
            // Wrap around to A
            currentCharacter = 'A';
        }
        
        UpdateDisplay();
    }
    
    public void PreviousLetter()
    {
        if (currentCharacter > 'A' && currentCharacter <= 'Z')
        {
            currentCharacter = (char)(currentCharacter - 1);
        }
        else if (currentCharacter == 'A')
        {
            // Wrap around to Z
            currentCharacter = 'Z';
        }
        
        UpdateDisplay();
    }
    
    // Switch to numbers
    public void ShowNumbers()
    {
        currentCharacter = '1';
        UpdateDisplay();
    }
    
    // Switch to letters
    public void ShowLetters()
    {
        currentCharacter = 'A';
        UpdateDisplay();
    }
}