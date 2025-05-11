using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BrailleDotButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
        
        // Make sure the audio clip is assigned
        if (buttonSound != null && audioSource != null)
        {
            audioSource.clip = buttonSound;
        }
        
        // Remember how big the button is supposed to be
        originalScale = transform.localScale != Vector3.zero ? transform.localScale : Vector3.one;
        
        // Set the button to look right based on selected/not selected
        UpdateVisualState();
        
        // Let's see if this works
        Debug.Log("Button " + buttonId + " ready to go");
        
        // DIRECT SOUND TEST - play directly for testing
        if (buttonSound != null)
        {
            Debug.Log("Playing test sound for Button " + buttonId + " directly");
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position, 1.0f);
        }
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
        
        // Test with keyboard (press 1-6 to toggle buttons)
        if (buttonId == 1 && Input.GetKeyDown(KeyCode.Alpha1) || 
            buttonId == 2 && Input.GetKeyDown(KeyCode.Alpha2) || 
            buttonId == 3 && Input.GetKeyDown(KeyCode.Alpha3) || 
            buttonId == 4 && Input.GetKeyDown(KeyCode.Alpha4) || 
            buttonId == 5 && Input.GetKeyDown(KeyCode.Alpha5) || 
            buttonId == 6 && Input.GetKeyDown(KeyCode.Alpha6))
        {
            isSelected = !isSelected;
            UpdateVisualState();
            PlayButtonSound();
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
        if (buttonImage != null)
        {
            buttonImage.color = isSelected ? selectedColor : defaultColor;
        }
    }
    
    // Play the button sound - using direct PlayClipAtPoint for reliability
    private void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            Debug.Log("Playing sound for Button " + buttonId);
            
            // Method 1: Try using the AudioSource component
            if (audioSource != null)
            {
                audioSource.clip = buttonSound;
                audioSource.Play();
            }
            
            // Method 2: Use PlayClipAtPoint as a backup
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position, 1.0f);
        }
        else
        {
            Debug.LogWarning("Button " + buttonId + " has no sound assigned!");
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