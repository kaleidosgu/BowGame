using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : NetworkBehaviour {

    private Rigidbody2D playerRig;
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SyncVar(hook = "changeIndex")]
    public int currentIndex;
	// Use this for initialization
	void Start () {
        playerRig = GetComponent<Rigidbody2D>();
        if( isLocalPlayer )
        {
            CmdRequestCurrentPlayerCount();
        }

    }

    [ClientRpc]
    private void RpcResponseCurrentPlayerCount( int nCurIndex)
    {
        SpawnPoint[] arrayPoint = FindObjectsOfType<SpawnPoint>();
        if (nCurIndex < arrayPoint.Length)
        {
            SpawnPoint pointObj = arrayPoint[nCurIndex];
            transform.position = pointObj.transform.position;
        }
        currentIndex = nCurIndex;
    }

    public void changeIndex(int nIndex )
    {
        currentIndex = nIndex;
    }

    [Command]
    private void CmdRequestCurrentPlayerCount()
    {
        int nCurrentCount = 0;
        ServerManager svrMgr = FindObjectOfType<ServerManager>();
        if (svrMgr != null)
        {
            nCurrentCount = svrMgr.GetCurrentPlayerCounts();
            currentIndex = nCurrentCount;
            svrMgr.AddPlayer();
        }
        RpcResponseCurrentPlayerCount( nCurrentCount );
    }
    	
	// Update is called once per frame
	void Update () {
		
	}
    [ClientRpc]
    private void RpcRotateIt()
    {
        transform.Rotate(Vector3.forward, 180);
        transform.Rotate(Vector3.up, 180);
    }
    [Command]
    private void CmdRotateIt()
    {
        RpcRotateIt();
    }

    [Client]
    private void FixedUpdate()
    {
        if( isLocalPlayer )
        {
            bool bJump = CrossPlatformInputManager.GetButtonDown("Fire1");
            bool bShoot = CrossPlatformInputManager.GetButtonDown("Fire2");


            if (bJump)
            {
                //playerRig.gravityScale *= -1;
                //CmdRotateIt();
            }

            if (bShoot)
            {
                //CmdShoot(currentIndex);
            }
        }
    }

    public void RequestJump()
    {
        playerRig.gravityScale *= -1;
        CmdRotateIt();
    }
    public void RequestShoot()
    {
        CmdShoot(currentIndex);
    }
    [Command]
    private void CmdShoot(int nCurrentIndex)
    {
        GameObject gmObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if(gmObj != null)
        {
            BulletMovement movement = gmObj.GetComponent<BulletMovement>();
            if(movement != null)
            {
                movement.ChangeOwnerIndex(nCurrentIndex);
                if ( nCurrentIndex == 0 )
                {
                    movement.ChangeDirection(false);
                }
                else if ( nCurrentIndex == 1)
                {
                    movement.ChangeDirection(true);
                }
            }
            NetworkServer.Spawn(gmObj);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    [ClientRpc]
    public void RpcUpdateScore( int nRight, int nLeft )
    {
        ScoreSystem scoreSys = FindObjectOfType<ScoreSystem>();
        Text txtScore = scoreSys.GetComponent<Text>();
        if(txtScore != null)
        {
            string str = "";
            str = string.Format("{0}:{1}", nRight, nLeft);
            txtScore.text = str;
        }
    }
}
