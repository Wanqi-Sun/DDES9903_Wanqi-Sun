using UnityEngine;

public class FinalButtonTrigger : MonoBehaviour
{
    public AudioSource npcCryAudio;
    public GameObject helpTextUI;
    public GameObject handIcon;

    private bool hasTriggered = false;

    public void TriggerSadNpcEvent()
    {
        if (hasTriggered) return;
        hasTriggered = true;

        if (npcCryAudio != null)
        {
            npcCryAudio.Play();
        }

        if (helpTextUI != null)
        {
            helpTextUI.SetActive(true);
        }

        if (handIcon != null)
        {
            handIcon.SetActive(true);
        }
    }
}
