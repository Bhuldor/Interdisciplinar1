using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateInventorySize : MonoBehaviour
{
    private bool mustUpdate = false;
    private RectTransform rt;
    private int childCount;
    private float sizeY;
    private void Start()
    {
        MenuInventory.OnOpeningInventory += updateSize;
        rt = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        if (mustUpdate)
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, childCount * sizeY);
            mustUpdate = false;
        }
    }
    public void updateSize(int childCount,float sizeY)
    {
        this.childCount = childCount;
        this.sizeY = sizeY;
        mustUpdate = true;
    }
    private void OnDestroy()
    {
        MenuInventory.OnOpeningInventory -= updateSize;
    }
}
