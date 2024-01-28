using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum DirtyObjectType
{ 
    Default,
    PigeonShit,
    Brush,
    DirtyPuddle,
    DirtySplashes,
    Shit
};

public class DirtyObject : MonoBehaviour
{
    public DirtyObjectType type;

    private bool wasTriggered = false;
    public float dirtAmount = 10.0f;
    public bool destroyAfterCollision = false;

    private Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        gameObject.tag = "DirtyObject"; // No idea if this works
    }

    void Update()
    {
        switch (type)
        {
            case DirtyObjectType.PigeonShit:
            {
                Vector3 acceleration = new Vector3(0.0f, -9.8f, 0.0f);
                velocity += acceleration * Time.deltaTime;
                Vector3 positionDelta = Time.deltaTime * velocity + 0.5f * Time.deltaTime * Time.deltaTime * acceleration;
                
                gameObject.transform.position += positionDelta;
            } break;
        }
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
