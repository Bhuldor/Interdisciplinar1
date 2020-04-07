using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DropObtain : MonoBehaviour
{
    public GameObject dropPanel;
    public Text textPanel;

    private Queue listToShow = new Queue();
    private bool showingPanel = false;
    void Start()
    {
        TestInventory.OnDropObtain += DropObtained;
    }

    void Update()
    {
        if(listToShow.Count > 0 && !showingPanel)
        {
            showingPanel = true;
            showPanel();
        }
    }

    public void DropObtained(Item item)
    {
        listToShow.Enqueue(item);
    }
    public void showPanel()
    {
        Item itemToShow = listToShow.Dequeue() as Item;
        textPanel.text = $"Você obteve {itemToShow.name} x{itemToShow.quantity}";
        Vector3 dest = dropPanel.transform.position - new Vector3(0, Screen.height * 0.1f, 0);
        LeanTween.move(dropPanel, dest, 0.3f);
        StartCoroutine(hidePanel());
    }

    IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(3f);
        Vector3 dest = dropPanel.transform.position + new Vector3(0, Screen.height * 0.1f, 0);
        LeanTween.move(dropPanel, dest, 0.3f);
        yield return new WaitForSeconds(0.3f);
        showingPanel = false;
    }

    public void OnDestroy()
    {
        TestInventory.OnDropObtain -= DropObtained;
    }
}
