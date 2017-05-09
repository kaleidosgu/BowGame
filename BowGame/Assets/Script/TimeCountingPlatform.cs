using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountingPlatform : MonoBehaviour {

    public float TriggerCountedTime;
    public float ConstDisableCollideTime;
    public Sprite sprHasCollide;
    public Sprite sprHasNoCollide;

    private bool StartToCountTime;
    private float fCountedTime;
    private bool DisableCollide;
    private float DisableCollideTime;
    private BoxCollider2D boxCollide;
    // Use this for initialization
    void Start () {
        boxCollide = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if( StartToCountTime == true )
        {
            fCountedTime += Time.deltaTime;

            if( fCountedTime >= TriggerCountedTime )
            {
                //去除碰撞
                DisableCollide = true;
                BoxCollider2D boxCollide = GetComponent<BoxCollider2D>();
                boxCollide.enabled = false;
                DisableCollideTime = 0.0f;
                StartToCountTime = false;
                _ChangeSprite(sprHasNoCollide);
            }
        }

        if(DisableCollide == true)
        {
            DisableCollideTime += Time.deltaTime;

            if( DisableCollideTime >= ConstDisableCollideTime )
            {
                boxCollide.enabled = true;
                DisableCollide = false;
                _ChangeSprite(sprHasCollide);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player" )
        {
            StartToCountTime = true;
            fCountedTime = 0.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartToCountTime = false;
        }
    }

    private void _ChangeSprite( Sprite sprChanged )
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        render.sprite = sprChanged;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartToCountTime = true;
            fCountedTime = 0.0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartToCountTime = false;
        }
    }
}
