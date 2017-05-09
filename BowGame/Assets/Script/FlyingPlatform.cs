using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class FlyingPlatform : NetworkBehaviour {

    public float speed;
    public Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += moveDirection * Time.deltaTime * speed;
    }

    public void ChangeDirection( Vector3 vecDir )
    {
        moveDirection = vecDir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RailwayNode")
        {
            RailwayRules railNode = collision.GetComponent<RailwayRules>();
            ChangeDirection(railNode.vecChangeDir);
        }
    }
}


