using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class PlayerControl : NetworkBehaviour
{
    // プレイヤー
    private GameObject player;

    // フリックの座標
    private Vector2 flickStartPos;
    private Vector2 flickEndPos;

    [SerializeField]
    private float flickPower;

    [SerializeField]
    private float maxForce;

    private Rigidbody rb;

    private void Start()
    {
        player = gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // オブジェクトのオーナーでなければ無視
        // if(IsOwner == false)
        // {
        //     return;
        // }

        // マウスの左クリックの開始を検知
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            flickStartPos = Mouse.current.position.ReadValue();
        }

        // マウスの左クリックの終わりを検知
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            flickEndPos = Mouse.current.position.ReadValue();
            Flick();
        }
    }

    private void Flick()
    {
        // フリック情報
        Vector2 flickVector = flickEndPos - flickStartPos;

        // フリック方向
        Vector2 flickDirection = flickVector.normalized;

        // フリックの強さ
        float flickStrength = Mathf.Clamp(
            flickVector.magnitude * flickPower, 
            0f, 
            maxForce
        );

        // 力を加える
        rb.AddForce(
            new Vector3(-flickDirection.x, 0, -flickDirection.y) * flickStrength,
            ForceMode.Impulse
        );
    }
}
