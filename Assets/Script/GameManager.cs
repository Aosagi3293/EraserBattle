using UnityEngine;

public enum GameState
{
    Start,
    Play,
    Result
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public GameState nowState;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Start);
    }

    // ゲームの状態変更メソッド
    public void ChangeState(GameState state)
    {
        nowState = state;
    }
}
