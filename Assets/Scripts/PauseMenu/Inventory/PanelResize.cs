using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelResize : MonoBehaviour
{
    private RectTransform RT;
    [SerializeField] private RectTransform textRectTransform;
    private bool ok = false;
    void Start()
    {
        RT = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (!ok)
        {
            RT.sizeDelta = new Vector2(2 * (textRectTransform.sizeDelta.x * 0.2f), RT.sizeDelta.y);
            ok = true;
        }
    }
}
