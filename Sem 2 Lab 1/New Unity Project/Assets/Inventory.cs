using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int space = 30;
    public List<ItemScriptable> items = new List<ItemScriptable>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        instance = this;
    }

    public void Add(ItemScriptable item)
    {
        if (items.Count <= space)
        {
            items.Add(item);
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove(ItemScriptable item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
