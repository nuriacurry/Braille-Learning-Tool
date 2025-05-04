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
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BrailleButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public int buttonId; // 1-6 for standard Braille dot positions
    public bool isSelected = false;
    public AudioClip buttonSound; // Different tone for each button
    
    // Customize these to change button look & feel
    public Color defaultColor = Color.white;
    public Color selectedColor = Color.yellow;
    public Color pressedColor = new Color(1f, 0.8f, 0f); // Orange-ish when pressed
    public float pressScaleAmount = 0.9f; // Shrink to 90% when pressed
    public float animationSpeed = 10f; // Higher = faster animation
    
    private Button button;
    private Image buttonImage;
    private AudioSource audioSource;
    private Vector3 originalScale;
    private bool isPressed = false;
    
    void Start()
    {
        // Grab all the stuff we need
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        
        // No audio? No problem, let's add it
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false; // Don't play until we say so
        }
        
        // Remember how big the button is supposed to be
        originalScale = transform.localScale;
        
        // Set the button to look right based on selected/not selected
        UpdateVisualState();
        
        // Let's see if this works
        Debug.Log("Button " + buttonId + " ready to go");
    }
    
    void Update()
    {
        // Handle the squish animation
        if (isPressed)
        {
            // Squish down when pressed
            transform.localScale = Vector3.Lerp(transform.localScale, 
                                               originalScale * pressScaleAmount, 
                                               Time.deltaTime * animationSpeed);
        }
        else
        {
            // Pop back up when released
            transform.localScale = Vector3.Lerp(transform.localScale, 
                                               originalScale, 
                                               Time.deltaTime * animationSpeed);
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // Flip between selected/not selected
        isSelected = !isSelected;
        
        // Make it look right
        UpdateVisualState();
        
        // Beep boop
        PlayButtonSound();
        
        // For troubleshooting
        Debug.Log("Dot " + buttonId + " is now " + (isSelected ? "ON" : "OFF"));
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Button is being pressed down
        isPressed = true;
        buttonImage.color = pressedColor;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        // Finger lifted off button
        isPressed = false;
        UpdateVisualState();
    }
    
    // Update color based on whether dot is on or off
    private void UpdateVisualState()
    {
        buttonImage.color = isSelected ? selectedColor : defaultColor;
    }
    
    // Play the button sound
    private void PlayButtonSound()
    {
        if (audioSource != null && buttonSound != null)
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
        }
    }
    
    // Turn off this dot
    public void ResetButton()
    {
        isSelected = false;
        UpdateVisualState();
    }
    
    // Manually set dot state (for showing patterns)
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateVisualState();
    }
}
