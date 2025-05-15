using UnityEngine;

[RequireComponent(typeof(BrailleDotButton))]
[RequireComponent(typeof(SimpleAudioPlayer))]
public class ButtonSoundConnector : MonoBehaviour
{
    private BrailleDotButton brailleButton;
    private SimpleAudioPlayer audioPlayer;
    
    void Start()
    {
        brailleButton = GetComponent<BrailleDotButton>();
        audioPlayer = GetComponent<SimpleAudioPlayer>();
        
        if (brailleButton != null && audioPlayer != null)
        {
           
            brailleButton.buttonSound = audioPlayer.soundClip;
            
            Debug.Log("ButtonSoundConnector: Successfully connected button " + brailleButton.buttonId + " to SimpleAudioPlayer");
        }
        else
        {
            Debug.LogError("ButtonSoundConnector: Missing required components");
        }
    }
    

    public void PlayRedirectedSound()
    {
        Debug.Log("ButtonSoundConnector: Redirecting sound playback");
        if (audioPlayer != null)
        {
            audioPlayer.PlaySound();
        }
    }
}