using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateInventorySize : MonoBehaviour
{
    int childs;
    private void Start()
    {
        childs = transform.childCount;
    }
    void Update()
    {
          if(childs != transform.childCount)
          {
            if(childs < transform.childCount)
            {
                int dif = transform.childCount - childs;
                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y + (dif*35));
                transform.position = new Vector3(transform.position.x, transform.position.y - (dif*17.5f), 0);
            }
            else
            {
                int dif = childs - transform.childCount;
                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y - (dif*35));
                transform.position = new Vector3(transform.position.x, transform.position.y + (dif*17.5f), 0);
            }
            Debug.Log($"Child count: {childs} tamanho setado: {childs * 35}");
            childs = transform.childCount;
          }
    }
}
