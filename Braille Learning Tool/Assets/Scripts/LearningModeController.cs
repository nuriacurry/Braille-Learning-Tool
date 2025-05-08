using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LearningModeController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI letterDisplay;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextButton;
    
    [Header("Background Panels")]
    [SerializeField] private Image letterPanel;
    [SerializeField] private Image brailleGridPanel;
    [SerializeField] private Image navigationPanel;
    
    [Header("Braille References")]
    [SerializeField] private BrailleGridManager brailleGridManager;
    
    // Current letter index
    private int currentLetterIndex = 0;
    private char[] letters = new char[26]; // A-Z
    
    // For haptic feedback
    private bool vibrationEnabled = true;
    
    // Reference to the BrailleDatabase
    private BrailleDatabase brailleDatabase;
    
    void Start()
    {
        // Initialize the alphabet
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)('A' + i);
        }
        
        // Set up button listeners
        prevButton.onClick.AddListener(OnPrevButtonPressed);
        homeButton.onClick.AddListener(OnHomeButtonPressed);
        nextButton.onClick.AddListener(OnNextButtonPressed);
        
        // Find BrailleDatabase
        brailleDatabase = BrailleDatabase.Instance;
        if (brailleDatabase == null)
        {
            Debug.LogError("BrailleDatabase not found! Make sure it's in the scene.");
        }
        
        // Display initial letter
        DisplayCurrentLetter();
        
        // Play instructions on start
        StartCoroutine(PlayInstructions());
    }
    
    IEnumerator PlayInstructions()
    {
        // Example of how to announce instructions
        Debug.Log("Playing Learning Mode instructions");
        // AudioManager.Instance.PlayAnnouncement("Learning Mode. Explore the Braille pattern for each letter. Press Next and Previous to navigate.");
        
        // Simulate instruction audio duration
        yield return new WaitForSeconds(3f);
    }
    
    void DisplayCurrentLetter()
    {
        char currentLetter = letters[currentLetterIndex];
        
        // Update the letter display
        letterDisplay.text = currentLetter.ToString();
        
        // Update the Braille pattern using your existing BrailleGridManager
        if (brailleGridManager != null)
        {
            brailleGridManager.ResetAllButtons();
            brailleGridManager.DisplayLetter(currentLetter);
        }
        
        // Announce the letter (using your AudioManager)
        string audioDescription = brailleDatabase ? 
            brailleDatabase.GetAudioDescription(currentLetter) : 
            "Letter " + currentLetter;
        
        Debug.Log("Announcing: " + audioDescription);
        
        // If you implement TTS later, you can uncomment this
        // AudioManager.Instance.AnnounceLetter(audioDescription);
        
        // Provide haptic feedback
        if (vibrationEnabled)
        {
            Handheld.Vibrate();
        }
    }
    
    void OnPrevButtonPressed()
    {
        // Play selection sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySelectionSound();
        }
        
        // Provide haptic feedback
        if (vibrationEnabled)
        {
            Handheld.Vibrate();
        }
        
        // Navigate to previous letter
        currentLetterIndex--;
        if (currentLetterIndex < 0)
        {
            currentLetterIndex = letters.Length - 1;
        }
        
        DisplayCurrentLetter();
    }
    
    void OnNextButtonPressed()
    {
        // Play selection sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySelectionSound();
        }
        
        // Provide haptic feedback
        if (vibrationEnabled)
        {
            Handheld.Vibrate();
        }
        
        // Navigate to next letter
        currentLetterIndex++;
        if (currentLetterIndex >= letters.Length)
        {
            currentLetterIndex = 0;
        }
        
        DisplayCurrentLetter();
    }
    
    void OnHomeButtonPressed()
    {
        // Play selection sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySelectionSound();
        }
        
        // Provide haptic feedback
        if (vibrationEnabled)
        {
            Handheld.Vibrate();
        }
        
        // Navigate to main menu
        SceneManager.LoadScene("MainMenu");
    }
    
    // Handle long press for replaying instructions
    private float pressStartTime = 0f;
    private bool isLongPressing = false;
    
    void Update()
    {
        // Check for long press (touch or mouse)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                pressStartTime = Time.time;
                isLongPressing = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isLongPressing = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            pressStartTime = Time.time;
            isLongPressing = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isLongPressing = false;
        }
        
        // Check if long press duration has been reached
        if (isLongPressing && (Time.time - pressStartTime > 3.0f))
        {
            isLongPressing = false; // Reset to prevent multiple triggers
            StartCoroutine(PlayInstructions());
        }
    }
}