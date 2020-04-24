using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateInventorySize : MonoBehaviour
{
    private bool mustUpdate = false;
    private void Start()
    {
        MenuInventory.OnOpeningInventory += updateSize;
    }
    private void FixedUpdate()
    {
        if (mustUpdate)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, transform.childCount * 35);
            mustUpdate = false;
        }
    }
    public void updateSize()
    {
        mustUpdate = true;
    }
    private void OnDestroy()
    {
        MenuInventory.OnOpeningInventory -= updateSize;
    }
}
