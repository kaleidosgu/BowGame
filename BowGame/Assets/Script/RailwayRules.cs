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
}
