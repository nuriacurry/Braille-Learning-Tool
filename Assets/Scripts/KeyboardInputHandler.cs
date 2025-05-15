using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour
{
    private BrailleGridManager gridManager;
    
    void Start()
    {
        // Get reference to the BrailleGridManager
        gridManager = GetComponent<BrailleGridManager>();
        
        if (gridManager == null)
        {
            gridManager = FindObjectOfType<BrailleGridManager>();
        }
        
        if (gridManager == null)
        {
            Debug.LogError("KeyboardInputHandler: Could not find BrailleGridManager!");
        }
    }
    
    void Update()
    {
        // Only process if we have a grid manager
        if (gridManager == null || gridManager.brailleButtons == null) return;
        
        // Check for number keys 1-6
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ToggleButton(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ToggleButton(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            ToggleButton(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            ToggleButton(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            ToggleButton(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            ToggleButton(5);
        }
    }
    
    private void ToggleButton(int index)
    {
        if (index >= 0 && index < gridManager.brailleButtons.Length)
        {
            BrailleDotButton button = gridManager.brailleButtons[index];
            if (button != null)
            {
                button.isSelected = !button.isSelected;
                button.UpdateVisualState();
                button.PlayButtonSound();
                Debug.Log("Keyboard toggled button " + (index + 1) + " to " + button.isSelected);
            }
        }
    }
}

