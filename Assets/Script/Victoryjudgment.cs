using UnityEngine;
using System.Collections.Generic;

public class Victoryjudgment : MonoBehaviour
{
    [SerializeField] private List<GameObject> players = new List<GameObject>();

    private GameState state;

    private void Start()
    {
        state = GameManager.Instance.nowState;
    }

    private void Update()
    {
    //    if(state != GameState.Play) return;

        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].transform.position.y <= -5f)
            {
                GameManager.Instance.ChangeState(GameState.Result);
            }
        }
    }
}
