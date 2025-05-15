using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    public Button learningModeButton;
    public Button practiceButton;
    public Button aboutButton;
    
    void Start()
    {
        // Set up button listeners
        learningModeButton.onClick.AddListener(OpenLearningMode);
        practiceButton.onClick.AddListener(OpenPractice);
        aboutButton.onClick.AddListener(OpenAbout);
        Debug.Log("HomeScreenController started successfully");
    }
    
    public void OpenLearningMode()
    {
        // Load learning mode scene
        Debug.Log("Attempting to load LearningMode scene");
        SceneManager.LoadScene("LearningMode");
    }
    
    public void OpenPractice()
    {
        // Load practice mode scene
        Debug.Log("Attempting to load PracticeMode scene");
        SceneManager.LoadScene("PracticeMode");
        
    }
    
    public void OpenAbout()
    {
        // Load about scene
        Debug.Log("Attempting to load About scene");
        SceneManager.LoadScene("About");
    }
}


