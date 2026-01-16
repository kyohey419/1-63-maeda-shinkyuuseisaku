using UnityEngine;

public class SimpleFollowCamera : MonoBehaviour
{
    public Transform target;      // 追いかける対象（Player）
    public Vector3 offset = new Vector3(0, 10, -5); // プレイヤーとの距離感（夜廻風の斜め上）
    public float smoothSpeed = 0.125f; // 追従の滑らかさ（0に近いほどゆっくり）

    void LateUpdate() // カメラ移動はLateUpdateで行うのが基本
    {
        if (target == null) return;

        // 目標地点を計算
        Vector3 desiredPosition = target.position + offset;

        // 現在地から目標地点まで滑らかに移動させる（Lerp）
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // 常にターゲットの方を向く（必要に応じてオフにしてください）
        transform.LookAt(target);
    }
}