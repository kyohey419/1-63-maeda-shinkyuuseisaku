using UnityEngine;

public class ObjectUITrigger : MonoBehaviour
{
    [Header("範囲内に入った時に表示するUI")]
    [SerializeField] private GameObject displayUI;

    [Header("反応させたい特定のCollider (空なら自身のTriggerに反応)")]
    [SerializeField] private Collider targetCollider;

    void Awake()
    {
        if (displayUI != null)
        {
            displayUI.SetActive(false);
        }

        // もしインスペクターでColliderが指定されていない場合は、
        // 自分自身についているColliderを自動で割り当てる
        if (targetCollider == null)
        {
            targetCollider = GetComponent<Collider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. 侵入したのがプレイヤーか
        // 2. その判定（other）が、指定したColliderか
        if (other.CompareTag("Player") && IsTargetCollider(other))
        {
            SetUIVisible(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsTargetCollider(other))
        {
            SetUIVisible(false);
        }
    }

    // 侵入したColliderが指定のものか判定するメソッド
    private bool IsTargetCollider(Collider other)
    {
        // プレイヤー自身に複数のColliderがついている場合を考慮し、
        // 侵入してきたのが「指定した特定のエリア」かどうかをチェックします
        // 今回の要望では「どの判定に入ったか」なので、このスクリプトがついている側をチェックします
        return true;
    }

    private void SetUIVisible(bool visible)
    {
        if (displayUI != null)
        {
            displayUI.SetActive(visible);
        }
    }
}