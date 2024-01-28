using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class DirtAmountDirt : MonoBehaviour
{
    private RectTransform rectTransform;

    public Bride bride;
    public float maxWidth = 200.0f;

    void Start()
    {
        bride = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Bride>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (bride != null) 
        {
            float dirtinessPercent = bride.GetDirtiness() / bride.GetMaxDirtiness();
            float width = maxWidth * dirtinessPercent;
            // Debug.Log($"dirtinessPercent {dirtinessPercent}, bride.GetDirtiness() {bride.GetDirtiness()}, bride.GetMaxDirtiness() {bride.GetMaxDirtiness()}");
            rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
            rectTransform.anchoredPosition = new Vector2(width / 2.0f, 0.0f);
        }
    }
}
