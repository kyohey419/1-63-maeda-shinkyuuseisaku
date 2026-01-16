using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [Header("表示させるUI（名前やガイド）")]
    [SerializeField] private GameObject displayUI;

    [Header("移動先のシーン名")]
    [SerializeField] private string nextSceneName;

    [Header("インタラクトキー")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    // プレイヤーが範囲内にいるかどうかの内部フラグ
    private bool isPlayerInside = false;

    void Awake()
    {
        if (displayUI != null) displayUI.SetActive(false);
    }

    void Update()
    {
        // 範囲内にいる時だけ、キー入力を監視する
        if (isPlayerInside && Input.GetKeyDown(interactKey))
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log(nextSceneName + " へ移動します");
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 侵入してきたオブジェクトのタグがPlayerならUIを出す
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (displayUI != null) displayUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 離れたらUIを消し、キー入力を受け付けなくする
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (displayUI != null) displayUI.SetActive(false);
        }
    }
}