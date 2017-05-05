using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyTrategy : MonoBehaviour
{
    public float selfDestroyTime = 0.0f;

    private float selfTickCount = 0.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        selfTickCount += Time.deltaTime;
        if (selfDestroyTime > 0 && selfTickCount > selfDestroyTime)
        {
            Destroy(gameObject);
        }
    }
}
