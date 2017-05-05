using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletMovement : NetworkBehaviour {

    [SyncVar(hook = "ChangeDirection")]
    public bool directionRight;
    [SyncVar(hook = "ChangeOwnerIndex")]
    public int ownerIndex;

    public float speed;
    private Rigidbody2D rigbody;
	// Use this for initialization
	void Start () {
        rigbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if(directionRight == true)
        {
            rigbody.velocity = Vector2.right * speed;
        }
        else
        {
            rigbody.velocity = Vector2.left * speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (player.GetCurrentIndex() != ownerIndex)
                {
                    //todo击中加分
                    Destroy(gameObject);
                }
            }
        }
    }

    public void ChangeDirection( bool bDirRight )
    {
        directionRight = bDirRight;
    }
    public void ChangeOwnerIndex( int nIndex )
    {
        ownerIndex = nIndex;
    }
    
}
