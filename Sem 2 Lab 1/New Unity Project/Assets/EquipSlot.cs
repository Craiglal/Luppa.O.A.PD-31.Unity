using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Image icon;
    ItemScriptable item;
    public Button remove;
    public EquipmentSlot type;

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
        Equipment.instance.Remove(item);
    }
}
