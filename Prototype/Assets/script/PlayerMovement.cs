using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f; // 回転の速さ（この値を調整してね）

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized; // normalizedで斜め移動の速さを一定に

        // 1. 移動の処理
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // 2. 回転の処理（ここが修正ポイント！）
        if (move != Vector3.zero)
        {
            // 行きたい方向への回転を作成
            Quaternion targetRotation = Quaternion.LookRotation(move);

            // 現在の向きから目標の向きへ、少しずつ回転させる（Slerp）
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}