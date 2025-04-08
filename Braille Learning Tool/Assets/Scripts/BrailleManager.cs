using System.Collections.Generic;
using UnityEngine;

public class BrailleGridManager : MonoBehaviour
{
    public BrailleButton[] brailleButtons;
    
    // Dictionary to store Braille patterns for each letter
    private Dictionary<char, bool[]> braillePatterns = new Dictionary<char, bool[]>();
    
    void Start()
    {
        // Auto-find buttons if not assigned
        if (brailleButtons == null || brailleButtons.Length < 6)
        {
            Debug.Log("Finding Braille buttons automatically...");
            BrailleButton[] foundButtons = FindObjectsOfType<BrailleButton>();
            
            // Sort buttons by their button ID
            System.Array.Sort(foundButtons, (a, b) => a.buttonId.CompareTo(b.buttonId));
            
            if (foundButtons.Length >= 6)
            {
                brailleButtons = new BrailleButton[6];
                for (int i = 0; i < 6; i++)
                {
                    brailleButtons[i] = foundButtons[i];
                }
                Debug.Log("Found and assigned " + brailleButtons.Length + " buttons.");
            }
            else
            {
                Debug.LogError("Could not find enough Braille buttons. Found: " + foundButtons.Length);
            }
        }
        
        // Initialize the Braille patterns
        InitializeBraillePatterns();
        Debug.Log("Braille Grid Manager initialized");
    }
    
    void InitializeBraillePatterns()
    {
        // Just a few examples to get started
        braillePatterns.Add('A', new bool[] { true, false, false, false, false, false });
        braillePatterns.Add('B', new bool[] { true, false, true, false, false, false });
        braillePatterns.Add('C', new bool[] { true, true, false, false, false, false });
        // More letters can be added later
    }
    
    // Method to display a specific letter pattern
    public void DisplayLetter(char letter)
    {
        letter = char.ToUpper(letter); // Convert to uppercase for pattern matching
        
        if (braillePatterns.ContainsKey(letter))
        {
            bool[] pattern = braillePatterns[letter];
            
            for (int i = 0; i < brailleButtons.Length && i < pattern.Length; i++)
            {
                brailleButtons[i].SetSelected(pattern[i]);
            }
            
            Debug.Log("Displaying Braille pattern for letter: " + letter);
        }
        else
        {
            Debug.LogWarning("No Braille pattern found for letter: " + letter);
        }
    }
    
    // Method to reset all buttons
    public void ResetAllButtons()
    {
        foreach (var button in brailleButtons)
        {
            button.ResetButton();
        }
    }
}