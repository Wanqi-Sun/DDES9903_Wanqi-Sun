using UnityEngine;

public class NpcBoxTrigger : MonoBehaviour
{
    public string correctBoxTag = "CorrectBox";  // 正确盲盒的Tag
    public GameObject hiddenButton;              // 拖隐藏按钮进来
    public GameObject guidingArrows;             // 拖引导箭头父物体进来
    public AudioSource tipSound;                 // 拖提示音效AudioSource进来

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctBoxTag))
        {
            Debug.Log("正确盲盒放对啦！");

            // 1️⃣ 出现隐藏按钮
            hiddenButton.SetActive(true);

            // 2️⃣ 出现地面引导箭头
            if (guidingArrows != null)
            {
                guidingArrows.SetActive(true);
            }

            // 3️⃣ 播放提示音
            if (tipSound != null)
            {
                tipSound.Play();
            }
        }
    }
}
