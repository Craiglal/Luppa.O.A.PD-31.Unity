using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUI : MonoBehaviour
{
    Equipment inventory;
    public Transform itemsParent;
    EquipSlot[] slots;
    public GameObject inventoryUi;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Equipment.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
    }

    void UpdateUI()
    {
        if (inventory.leftArm != null)
        {
            slots[0].AddItem(inventory.leftArm);
        }
        else
        {
            slots[0].ClearSlot();
        }

        if (inventory.rightArm != null)
        {
            slots[1].AddItem(inventory.rightArm);
        }
        else
        {
            slots[1].ClearSlot();
        }
    }
}
