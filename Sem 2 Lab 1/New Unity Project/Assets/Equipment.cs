using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public static Equipment instance;

    public ItemScriptable leftArm;
    public ItemScriptable rightArm;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void Add(ItemScriptable item)
    {
        if(item.equipmentSlot == EquipmentSlot.LeftArm)
        {
            leftArm = item;
        }
        if(item.equipmentSlot == EquipmentSlot.RightArm)
        {
            rightArm = item;
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(ItemScriptable item)
    {
        if (item.equipmentSlot == EquipmentSlot.LeftArm)
        {
            Inventory.instance.Add(leftArm);
            leftArm = null;
        }
        if (item.equipmentSlot == EquipmentSlot.RightArm)
        {
            Inventory.instance.Add(rightArm);
            rightArm = null;
        }
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
