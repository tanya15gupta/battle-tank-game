using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	public class GenericPool<T> : GenericSingleton<GenericPool<T>> where T : class
	{
		private List<PooledItems<T>> itemsInPool;

		private void Start()
		{
			itemsInPool = new List<PooledItems<T>>();
		}

		public virtual void ReturnItem(T _item)
		{
			PooledItems<T> pooledItem = itemsInPool.Find(item => item.item.Equals(_item));
			pooledItem.isUsed = false;
			return;
		}

		public virtual T GetItem()
		{
			if (itemsInPool.Count > 0)
			{
				PooledItems<T> item = itemsInPool.Find(findItem => findItem.isUsed == false);
				if (item != null)
				{
					item.isUsed = true;
					return item.item;
				}
			}
			return CreateNewItem();
		}

		protected T CreateNewItem()
		{
			PooledItems<T> newItem = new PooledItems<T>();
			newItem.item = CreateItem();
			newItem.isUsed = true;
			itemsInPool.Add(newItem);
			return newItem.item;
		}

		protected virtual T CreateItem()
		{
			return null as T;
		}

		private class PooledItems<T>
		{
			public T item;
			public bool isUsed;
		}
	}
}
