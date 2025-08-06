using UnityEngine;

public class CardFlipper : MonoBehaviour
{
    public Material frontMaterial;      // 奖品图
    public Material backMaterial;       // 背面图
    public AudioClip rewardClip;        // 奖品语音
   // public EndSequence endSequence;     // 引用 EndSequence 脚本

    private bool isFlipped = false;
    private Renderer rend;
    private AudioSource audioSource;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = backMaterial;

        // 自动添加 AudioSource，如果没有的话
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        if (isFlipped) return;

        // 翻卡
        rend.material = frontMaterial;
        isFlipped = true;

        // 播放音效 + 触发结尾流程
        StartCoroutine(PlaySoundAndTriggerEnd(0.5f));
    }

    System.Collections.IEnumerator PlaySoundAndTriggerEnd(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 播放奖励语音（如果设置了音频）
        if (rewardClip != null)
        {
            audioSource.clip = rewardClip;
            audioSource.Play();
        }

        // 通知 EndSequence 播放白屏 + 字幕（EndSequence 脚本中会等待音频播放完成）
       // if (endSequence != null)
        {
         //   endSequence.StartEndSequence();
        }
    }
}

