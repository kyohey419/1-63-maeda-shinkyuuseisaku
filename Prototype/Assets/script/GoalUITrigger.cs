using UnityEngine;

public class GoalUITrigger : MonoBehaviour
{
    [Header("1段目：鍵が足りない時だけ出すUI")]
    [SerializeField] private GameObject missingKeyUI;

    [Header("2段目：範囲内なら常に出すUI(ゴール表示など)")]
    [SerializeField] private GameObject alwaysDisplayUI;

    [Header("必要な鍵の数")]
    [SerializeField] private int requiredKeyCount = 3;

    [Header("反応させたい特定のCollider (空なら自身のTriggerに反応)")]
    [SerializeField] private Collider targetCollider;

    void Awake()
    {
        // 初期状態はすべて非表示
        if (missingKeyUI != null) missingKeyUI.SetActive(false);
        if (alwaysDisplayUI != null) alwaysDisplayUI.SetActive(false);

        if (targetCollider == null)
        {
            targetCollider = GetComponent<Collider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateUIState(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 範囲内にいる間、鍵の状況が変わる可能性がある場合はUpdateUIStateを呼び続ける
        if (other.CompareTag("Player"))
        {
            UpdateUIState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateUIState(false);
        }
    }

    private void UpdateUIState(bool isInside)
    {
        if (!isInside)
        {
            if (missingKeyUI != null) missingKeyUI.SetActive(false);
            if (alwaysDisplayUI != null) alwaysDisplayUI.SetActive(false);
            return;
        }

        // 2段目：範囲内なら常に表示
        if (alwaysDisplayUI != null) alwaysDisplayUI.SetActive(true);

        // 1段目：鍵が足りない時だけ表示
        if (missingKeyUI != null)
        {
            bool isShortOfKeys = GameDataManager.instance != null &&
                                GameDataManager.instance.keyCount < requiredKeyCount;

            missingKeyUI.SetActive(isShortOfKeys);
        }
    }
}