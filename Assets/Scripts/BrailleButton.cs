using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BrailleButton : MonoBehaviour, IPointerClickHandler
{
    public int buttonId; // 1-6 corresponding to Braille dot position
    public bool isSelected = false;
    public AudioClip buttonSound; // Will be assigned different notes per button
    
    private Button button;
    private Image buttonImage;
    private Color defaultColor;
    private Color selectedColor = Color.yellow;
    
    void Start()
    {
        // Get components
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        
        // Store the default color
        defaultColor = buttonImage.color;
        
        // Log initialization for debugging
        Debug.Log("Braille Button " + buttonId + " initialized");
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // Toggle selection state
        isSelected = !isSelected;
        
        // Change visual appearance
        buttonImage.color = isSelected ? selectedColor : defaultColor;
        
        // Log button press for debugging
        Debug.Log("Button " + buttonId + " clicked. Selected: " + isSelected);
    }
    
    // Function to reset button state
    public void ResetButton()
    {
        isSelected = false;
        buttonImage.color = defaultColor;
    }
    
    // Function to set button state
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        buttonImage.color = isSelected ? selectedColor : defaultColor;
    }
}