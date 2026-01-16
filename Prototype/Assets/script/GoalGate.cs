using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalGate : MonoBehaviour
{
    [Header("表示させるUI（「(E)で入る」など）")]
    [SerializeField] private GameObject displayUI;

    [Header("移動先のシーン名")]
    [SerializeField] private string nextSceneName;

    [Header("インタラクトキー")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("必要な鍵の数")]
    [SerializeField] private int requiredKeyCount = 3;

    private bool isPlayerInside = false;

    void Awake()
    {
        // 最初はUIを隠しておく
        if (displayUI != null) displayUI.SetActive(false);
    }

    void Update()
    {
        // 範囲内にいる時だけ処理
        if (isPlayerInside)
        {
            // キーが押されたら
            if (Input.GetKeyDown(interactKey))
            {
                // 鍵の数をチェック（GameDataManagerがある前提）
                if (GameDataManager.instance != null &&
                    GameDataManager.instance.keyCount >= requiredKeyCount)
                {
                    if (!string.IsNullOrEmpty(nextSceneName))
                    {
                        Debug.Log(nextSceneName + " へ移動します");
                        SceneManager.LoadScene(nextSceneName);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            // 範囲内に入ったらUIを常時出す
            if (displayUI != null) displayUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            // 範囲から出たらUIを消す
            if (displayUI != null) displayUI.SetActive(false);
        }
    }
}