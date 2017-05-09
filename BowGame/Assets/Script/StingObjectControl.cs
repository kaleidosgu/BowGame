using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingObjectControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //todo 伤害Player
        }
        else if (collision.tag == "StingObject")
        {
        }
    }
}
