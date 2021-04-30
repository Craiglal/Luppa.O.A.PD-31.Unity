using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemScriptable item;
	private void OnTriggerEnter(Collider collision)
	{
		Player pl = collision.GetComponent<Player>();
		if (pl != null)
		{
			Inventory.instance.Add(item);

            Destroy(gameObject);
		}
	}
}

