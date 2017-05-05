using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PlayerController FindLocalPlayer()
    {
        PlayerController playerFound = null;
        PlayerController[] playerArray = FindObjectsOfType<PlayerController>();
        foreach( PlayerController player in playerArray)
        {
            if(player.isLocalPlayer == true )
            {
                playerFound = player;
                break;
            }
        }
        return playerFound;
    }

    public void Jump()
    {
        PlayerController playerFound = FindLocalPlayer();
        if( playerFound != null )
        {
            playerFound.RequestJump();
        }
    }

    public void Shoot()
    {
        PlayerController playerFound = FindLocalPlayer();
        if (playerFound != null)
        {
            playerFound.RequestShoot();
        }
    }
}
