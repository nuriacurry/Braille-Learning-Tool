using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BrailleDotButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public int buttonId;
    public bool isSelected = false;
    public AudioClip buttonSound;
    
    public Color defaultColor = Color.white;
    public Color selectedColor = Color.yellow;
    public Color pressedColor = new Color(1f, 0.8f, 0f);
    public float pressScaleAmount = 0.9f;
    public float animationSpeed = 10f;
    
    private Button button;
    private Image buttonImage;
    //private AudioSource audioSource;
    public AudioSource audioSource;
    private Vector3 originalScale;
    private bool isPressed = false;
    
    void Start()
    {
        // Get components
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        //audioSource = GetComponent<AudioSource>();
        
        // Add AudioSource if missing
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        
        originalScale = transform.localScale != Vector3.zero ? transform.localScale : Vector3.one;
        
        UpdateVisualState();
        
        Debug.Log("Button " + buttonId + " ready to go");
    }
    
    void Update()
    {
        // Handle squish animation
        if (isPressed)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, 
                                              originalScale * pressScaleAmount, 
                                              Time.deltaTime * animationSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, 
                                              originalScale, 
                                              Time.deltaTime * animationSpeed);
        }
        
        // Keyboard shortcuts (1-6)
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
        // Toggle selection state
        isSelected = !isSelected;
        
        // Update appearance
        UpdateVisualState();
        
        // Play sound
        PlayButtonSound();
        
        Debug.Log("Dot " + buttonId + " is now " + (isSelected ? "ON" : "OFF"));
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Button pressed down
        isPressed = true;
        buttonImage.color = pressedColor;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        // Button released
        isPressed = false;
        UpdateVisualState();
    }
    
    // Update visual state based on selection
    public void UpdateVisualState()
    {
        if (buttonImage != null)
        {
            buttonImage.color = isSelected ? selectedColor : defaultColor;
        }
    }
    
    // Play button sound directly
    public void PlayButtonSound()
    {
        if (audioSource != null && buttonSound != null)
        {
            audioSource.clip = buttonSound;
            audioSource.Play();
            Debug.Log("Playing sound for button " + buttonId);
        }
        else
        {
            Debug.LogWarning("Cannot play sound - AudioSource or AudioClip missing");
        }
    }
    
    // Reset button state
    public void ResetButton()
    {
        isSelected = false;
        UpdateVisualState();
    }
    
    // Set button state
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateVisualState();
    }
}