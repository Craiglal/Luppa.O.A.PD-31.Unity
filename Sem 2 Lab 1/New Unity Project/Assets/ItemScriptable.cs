using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemScriptable : ScriptableObject
{
	new public string name = "New item";
	public Sprite icon = null;
	public bool defaultItem = false;
	public EquipmentSlot equipmentSlot;
	public Equipment equipment;

	public virtual void Use()
    {
		Equipment.instance.Add(this);
		Inventory.instance.Remove(this);
	}
}

public enum EquipmentSlot
{
    LeftArm, RightArm
}