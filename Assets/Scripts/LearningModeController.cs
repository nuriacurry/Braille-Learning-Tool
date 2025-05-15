using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LearningModeController : MonoBehaviour
{
    public TextMeshProUGUI letterDisplay;
    private BrailleGridManager gridManager;
    private char currentLetter = 'A';
    private int currentPosition = 0;
    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    void Start()
    {
        gridManager = FindObjectOfType<BrailleGridManager>();
        DisplayCurrentLetter();
    }
    
    void DisplayCurrentLetter()
    {
        if (letterDisplay != null)
        {
            letterDisplay.text = currentLetter.ToString();
        }
        
        if (gridManager != null)
        {
            gridManager.DisplayLetter(currentLetter);
        }
    }
    
    public void NextLetter()
    {
        currentPosition = (currentPosition + 1) % alphabet.Length;
        currentLetter = alphabet[currentPosition];
        DisplayCurrentLetter();
    }
    
    public void PreviousLetter()
    {
        currentPosition = (currentPosition - 1 + alphabet.Length) % alphabet.Length;
        currentLetter = alphabet[currentPosition];
        DisplayCurrentLetter();
    }
    
    public void ResetToFirstLetter()
    {
        currentPosition = 0;
        currentLetter = alphabet[currentPosition];
        DisplayCurrentLetter();
    }
    
    public void OnNextButton()
    {
        NextLetter();
    }
    
    public void OnPreviousButton()
    {
        PreviousLetter();
    }
    
    public void OnHomeButton()
    {
        ResetToFirstLetter();
    }
}