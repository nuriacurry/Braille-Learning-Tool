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
    private Vector3 originalScale;
    private bool isPressed = false;
    
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        
        originalScale = transform.localScale != Vector3.zero ? transform.localScale : Vector3.one;
        
        UpdateVisualState();
        
        Debug.Log("Button " + buttonId + " ready to go");
    }
    
    void Update()
    {
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
        
        if (buttonId == 1 && Input.GetKeyDown(KeyCode.Alpha1) || 
            buttonId == 2 && Input.GetKeyDown(KeyCode.Alpha2) || 
            buttonId == 3 && Input.GetKeyDown(KeyCode.Alpha3) || 
            buttonId == 4 && Input.GetKeyDown(KeyCode.Alpha4) || 
            buttonId == 5 && Input.GetKeyDown(KeyCode.Alpha5) || 
            buttonId == 6 && Input.GetKeyDown(KeyCode.Alpha6))
        {
            isSelected = !isSelected;
            UpdateVisualState();
            PlaySoundThroughAudioManager();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        UpdateVisualState();
        PlaySoundThroughAudioManager();
        
        Debug.Log("Dot " + buttonId + " is now " + (isSelected ? "ON" : "OFF"));
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        buttonImage.color = pressedColor;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        UpdateVisualState();
    }
    
    public void UpdateVisualState()
    {
        if (buttonImage != null)
        {
            buttonImage.color = isSelected ? selectedColor : defaultColor;
        }
    }
    
    private void PlaySoundThroughAudioManager()
    {
        if (buttonSound != null)
        {
            int buttonIndex = buttonId - 1; // Adjust for zero-based indexing
            
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(buttonSound, buttonIndex);
            }
        }
    }
    
    public void ResetButton()
    {
        isSelected = false;
        UpdateVisualState();
    }
    
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateVisualState();
    }
}