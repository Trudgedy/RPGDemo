using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region singleton
	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than once instance of Inventory created!");
			return;
		}
		instance = this;
	}

	#endregion

	public List<Item> items = new List<Item>();
	public int space = 20;

	public static Inventory instance;

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;


	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough inventory space");
				return false;
			}
			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();

			return true;
		}
		return false;
	}

	public void Remove(Item item)
	{
		items.Remove(item);
	}
}
