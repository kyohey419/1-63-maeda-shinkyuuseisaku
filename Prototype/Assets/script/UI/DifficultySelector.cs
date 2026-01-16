using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private Toggle easyToggle;
    [SerializeField] private Toggle hardToggle;
    [SerializeField] private Button startButton;

    // 選択された時の色（明るい）と未選択の色（暗い）
    private Color selectedColor = Color.white;
    private Color unselectedColor = new Color(0.5f, 0.5f, 0.5f);

    void Start()
    {
        // 最初は何も選ばれていない状態にする
        easyToggle.isOn = false;
        hardToggle.isOn = false;
        startButton.interactable = false;

        // 値が変わった時に実行する処理を登録
        easyToggle.onValueChanged.AddListener(delegate { OnChanged(); });
        hardToggle.onValueChanged.AddListener(delegate { OnChanged(); });
    }

    void OnChanged()
    {
        // どちらかがONならスタートボタンを押せるようにする
        startButton.interactable = easyToggle.isOn || hardToggle.isOn;

        // 見た目の色を変える（TargetGraphicの色を直接変更）
        easyToggle.targetGraphic.color = easyToggle.isOn ? selectedColor : unselectedColor;
        hardToggle.targetGraphic.color = hardToggle.isOn ? selectedColor : unselectedColor;
    }

    public void OnStartClicked()
    {
        if (easyToggle.isOn) Debug.Log("イージーで開始");
        else if (hardToggle.isOn) Debug.Log("ハードで開始");

        SceneManager.LoadScene("GameScene"); // ゲーム本編のシーン名
    }
}