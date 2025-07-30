using UnityEngine;
using TMPro;

public class SadNpcDialogSequence : MonoBehaviour
{
    public GameObject dialogUI; // 拖入 Canvas
    public TextMeshProUGUI dialogText; // 拖入 Text
    public string[] dialogLines; // 对话数组
    private int currentIndex = 0;
    private bool isDialogActive = false;

    void Start()
    {
        dialogUI.SetActive(false);
    }

    public void OnInteract()
    {
        if (!isDialogActive)
        {
            dialogUI.SetActive(true);
            currentIndex = 0;
            dialogText.text = dialogLines[currentIndex];
            isDialogActive = true;
        }
        else
        {
            currentIndex++;
            if (currentIndex < dialogLines.Length)
            {
                dialogText.text = dialogLines[currentIndex];
            }
            else
            {
                dialogUI.SetActive(false);
                isDialogActive = false;
            }
        }
    }
}
