using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    // For letter navigation within a scene
    public TextMeshProUGUI letterDisplay;
    private BrailleGridManager gridManager;
    private char currentLetter = 'A';
    private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    // For navigating between lettered scenes
    private bool useSceneNavigation = true; // Set to true if you want to navigate between scenes
    
    void Start()
    {
        useSceneNavigation = true;
        // Find components
        if (letterDisplay == null)
            letterDisplay = FindObjectOfType<TextMeshProUGUI>();
            
        gridManager = FindObjectOfType<BrailleGridManager>();
        
        // Get current scene name to determine current letter
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        // If we're in a Learning Mode scene with a letter suffix
        if (currentSceneName.StartsWith("LearningMode-") && currentSceneName.Length > 13)
        {
            char sceneLetter = currentSceneName[currentSceneName.Length - 1];
            if (sceneLetter >= 'A' && sceneLetter <= 'Z')
            {
                currentLetter = sceneLetter;
            }
        }
        
        // Display the initial letter
        DisplayCurrentLetter();
        
        Debug.Log("SceneLoader initialized with letter: " + currentLetter + " in scene: " + currentSceneName);
    }
    
    // Scene Loading Methods
    public void LoadScene(string sceneName)
    {
        Debug.Log("SceneLoader: Loading scene " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadHomeScene()
    {
        Debug.Log("SceneLoader: Loading HomeScene");
        SceneManager.LoadScene("HomeScene");
    }
    
    // Letter navigation methods
    void DisplayCurrentLetter()
    {
        if (letterDisplay != null)
        {
            letterDisplay.text = currentLetter.ToString();
            Debug.Log("SceneLoader: Displaying letter " + currentLetter);
        }
        
        if (gridManager != null)
        {
            gridManager.DisplayLetter(currentLetter);
        }
    }
    
    // Next button - either changes letter in current scene or loads next scene
    public void NextLetter()
    {
        if (useSceneNavigation)
        {
            // Navigate to next scene
            if (currentLetter < 'Z')
            {
                char nextLetter = (char)(currentLetter + 1);
                string nextScene = "LearningMode-" + nextLetter;
                Debug.Log("SceneLoader: Loading next letter scene: " + nextScene);
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Debug.Log("SceneLoader: Already at Z, cannot go to next scene");
            }
        }
        else
        {
            // Change letter within current scene
            if (currentLetter < 'Z')
            {
                currentLetter = (char)(currentLetter + 1);
                DisplayCurrentLetter();
            }
        }
    }
    
    // Previous button - either changes letter in current scene or loads previous scene
    public void PreviousLetter()
    {
        if (useSceneNavigation)
        {
            // Navigate to previous scene
            if (currentLetter > 'A')
            {
                char prevLetter = (char)(currentLetter - 1);
                string prevScene = "LearningMode-" + prevLetter;
                Debug.Log("SceneLoader: Loading previous letter scene: " + prevScene);
                SceneManager.LoadScene(prevScene);
            }
            else
            {
                Debug.Log("SceneLoader: Already at A, cannot go to previous scene");
            }
        }
        else
        {
            // Change letter within current scene
            if (currentLetter > 'A')
            {
                currentLetter = (char)(currentLetter - 1);
                DisplayCurrentLetter();
            }
        }
    }
}