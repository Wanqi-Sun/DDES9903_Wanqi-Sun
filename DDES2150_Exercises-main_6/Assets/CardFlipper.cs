using UnityEngine;

[RequireComponent(typeof(Collider))]  // 确保可点击（有碰撞体）
public class CardFlipper : MonoBehaviour
{
    [Header("Materials & Audio")]
    public Material frontMaterial;        // 正面
    public Material backMaterial;         // 背面
    public AudioClip rewardClip;          // 语音

    [Header("Exactly which renderer & slot to change")]
    public Renderer targetRenderer;       // 拖入“真正显示卡面”的 Mesh Renderer
    public int materialIndex = 1;         // 正面所在的材质槽索引（从0开始）

    private bool isFlipped = false;
    private AudioSource audioSource;
    private Material[] cachedMats;

    void Awake()
    {
        // 允许直接把脚本挂在带 Renderer 的物体上；若未指定则尝试就近获取
        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        isFlipped = false; // 每次启用时重置
    }

    void Start()
    {
        // 缓存实例级 materials，避免每次取/设导致不一致
        if (targetRenderer != null)
            cachedMats = targetRenderer.materials;

        ShowBack(); // 开场显示背面

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()   // PC 鼠标点击；XR/射线可改用 Flip()
    {
        Flip();
    }

    public void Flip()   // 方便射线/按钮等外部调用
    {
        if (isFlipped) return;
        ShowFront();
        isFlipped = true;
        StartCoroutine(PlaySoundAndTriggerEnd(0.5f));
    }

    public void ResetCard()  // 如需重置，可外部调用
    {
        ShowBack();
        isFlipped = false;
    }

    // —— 核心：同时写入两个材质槽，确保视觉稳定翻面 ——
    void ShowBack()   // 初始：背面
{
    SetSingleMaterial(backMaterial);
    isFlipped = false;
}

void ShowFront()  // 点击后：正面
{
    SetSingleMaterial(frontMaterial);
    isFlipped = true;
}

// 核心：强制只用 1 个材质（Element 0）
void SetSingleMaterial(Material m)
{
    if (targetRenderer == null || m == null) return;

    // 先把第0个材质设为目标材质
    targetRenderer.material = m;

    // 再把 materials 压成只有一个元素，避免第1个槽干扰
    var one = new Material[1];
    one[0] = targetRenderer.material;  // 实例化的 material
    targetRenderer.materials = one;
}


    System.Collections.IEnumerator PlaySoundAndTriggerEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (rewardClip != null)
        {
            audioSource.clip = rewardClip;
            audioSource.Play();
        }
        // 如需触发结尾序列，可在这里调用你的 EndSequence
    }
}
