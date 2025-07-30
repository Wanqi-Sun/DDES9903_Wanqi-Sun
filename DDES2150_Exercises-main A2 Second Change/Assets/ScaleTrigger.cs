using UnityEngine;
using TMPro;  // 如果你用的是 TextMeshPro

public class ScaleTrigger : MonoBehaviour
{
    public TextMeshProUGUI weightDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlindBox") || other.CompareTag("CorrectBox"))
        {
            float w = other.GetComponent<BlindBox>().weight;
            weightDisplay.text = w.ToString("F1") + " g";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlindBox") || other.CompareTag("CorrectBox"))
        {
            weightDisplay.text = "0 g";
        }
    }
}