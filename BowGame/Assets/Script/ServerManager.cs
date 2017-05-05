using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviour {

    public int currentPlayerCounts = 0;

    public int totalScore;

    private int rightScore;
    private int leftScore;
    // Use this for initialization
    void Start () {
        rightScore = totalScore;
        leftScore = totalScore;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetCurrentPlayerCounts()
    {
        return currentPlayerCounts;
    }
    private void ServerUpdateScore()
    {
        PlayerController[] arrayPlayer = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in arrayPlayer)
        {
            player.RpcUpdateScore(rightScore, leftScore);
        }
    }
    public void AddPlayer()
    {
        currentPlayerCounts += 1;
        if( currentPlayerCounts > 1)
        {
            ServerUpdateScore();
        }
    }

    public void PlayerHit( int attackIndex, int targetIndex )
    {
        if( attackIndex == 1 )
        {
            leftScore--;
        }
        else
        {
            rightScore--;
        }
        ServerUpdateScore();
    }
}
