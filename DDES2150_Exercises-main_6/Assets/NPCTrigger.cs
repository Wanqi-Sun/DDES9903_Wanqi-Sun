using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject floatingHint; // 漂浮提示字幕
    public DialogManager1 dialogManager;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floatingHint.SetActive(false);      // 隐藏漂浮提示
            dialogManager.StartDialog();        // 开始对话
        }
    }
}
