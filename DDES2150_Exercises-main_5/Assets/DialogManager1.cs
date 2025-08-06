
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager1 : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public string[] dialogLines;

    private int currentLine = 0;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void StartDialog()
    {
        currentLine = 0;
        dialogPanel.SetActive(true);
        ShowLine(currentLine);
    }

    public void ShowNextLine()
    {
        currentLine++;

        if (currentLine < dialogLines.Length)
        {
            ShowLine(currentLine);
        }
        else
        {
            EndDialog();
        }
    }

    void ShowLine(int index)
    {
        dialogText.text = dialogLines[index];
    }

void EndDialog()
{
   
}




    // 如果你想通过点击整个对话面板切换对话，可以加上这个：
    void Update()
    {
        if (dialogPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }
}
