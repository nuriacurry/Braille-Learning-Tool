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
    }
    
    void OpenLearningMode()
    {
        // Load learning mode scene
        SceneManager.LoadScene("LearningMode");
    }
    
    void OpenPractice()
    {
        // For now, just show a debug message
        Debug.Log("Practice Mode button clicked - functionality coming soon");
    }
    
    void OpenAbout()
    {
        // For now, just show a debug message
        Debug.Log("About button clicked - functionality coming soon");
    }
}


