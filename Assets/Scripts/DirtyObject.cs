using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyObject : MonoBehaviour
{
    private bool wasTriggered = false;
    public float dirtAmount = 10.0f;

    void Start()
    {
        gameObject.tag = "DirtyObject"; // No idea if this works
    }

    void Update()
    {
    }

    // WHY THE FUCK I'M DOING THIS?
    public bool GetWasTriggered()
    {
        return wasTriggered;
    }

    public void SetWasTriggered()
    {
        wasTriggered = true;
    }
}
