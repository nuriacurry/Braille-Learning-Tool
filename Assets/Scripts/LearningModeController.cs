using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Add this for scene management

public class LearningModeController : MonoBehaviour
{
    public TextMeshProUGUI letterDisplay;
    private BrailleGridManager gridManager;
    private char currentLetter = 'A';
    private int currentPosition = 0;
    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    // Add a reference to the home button
    public Button homeButton;
    
    void Start()
    {
        gridManager = FindObjectOfType<BrailleGridManager>();
        DisplayCurrentLetter();
        
        // Set up home button listener if it exists
        if (homeButton != null)
        {
            homeButton.onClick.AddListener(GoToHomeScene);
        }
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
    
    // Modify this method to also search for the home button if not assigned
    public void OnHomeButton()
    {
        // For the "HOME" button directly in hierarchy
        GoToHomeScene();
    }
    
    // Add this new method for scene navigation
    public void GoToHomeScene()
    {
        Debug.Log("Returning to Home Scene from Learning Mode");
        SceneManager.LoadScene("HomeScene");
    }

    // Add to LearningModeController.cs
void OnEnable()
{
    // Reconnect the home button every time the component is enabled
    var homeBtn = GameObject.Find("HOME")?.GetComponent<Button>();
    if (homeBtn != null)
    {
        homeBtn.onClick.RemoveAllListeners(); // Clear any existing listeners
        homeBtn.onClick.AddListener(GoToHomeScene);
        Debug.Log("Re-connected HOME button on enable");
    }
}
}