using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutSceneController : MonoBehaviour
{
    public Button homeButton; 
    
    void Start()
    {
        
        if (homeButton == null)
            homeButton = GameObject.Find("HOME").GetComponent<Button>();
            
        
        if (homeButton != null)
            homeButton.onClick.AddListener(GoToHome);
        else
            Debug.LogError("Home button not found or assigned!");
    }
    
    // Method to handle button click
    public void GoToHome()
    {
        Debug.Log("Home button clicked - returning to HomeScene");
        SceneManager.LoadScene("HomeScene");
    }
}