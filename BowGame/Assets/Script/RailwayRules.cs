using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailwayRules : MonoBehaviour {

    public Vector3 vecChangeDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "RailwayObject" )
        {
            FlyingPlatform flyObj = collision.GetComponent<FlyingPlatform>();
            flyObj.ChangeDirection(vecChangeDir);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.collider.tag == "Player" )
        {
            int a = 0;
        }
        else if (collision.collider.tag == "StingObject")
        {
            int a = 0;
        }
    }
}
