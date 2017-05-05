using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviour {

    public int currentPlayerCounts = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetCurrentPlayerCounts()
    {
        return currentPlayerCounts;
    }

    public void AddPlayer()
    {
        currentPlayerCounts += 1;
    }
}
