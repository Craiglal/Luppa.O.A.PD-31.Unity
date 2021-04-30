using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    ItemScriptable item;
    public Button remove;

    public void AddItem(ItemScriptable nItem)
    {
        item = nItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        remove.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        remove.interactable = false;
    }

    public void OnRemove()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
