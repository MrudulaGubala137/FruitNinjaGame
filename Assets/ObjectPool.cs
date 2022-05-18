using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	private List<GameObject> pool;
	private GameObject prefab;
	// Start is called before the first frame update
	public ObjectPool(GameObject _prefab, int initialCapacity)
	{
		pool = new List<GameObject>();
		prefab = _prefab;

		for (int i = 0; i < initialCapacity; i++)
		{
			GameObject obj = GameObject.Instantiate(prefab) as GameObject;
			obj.SetActive(false);
			pool.Add(obj);
		}
	}

	// Spawn an object from the pool.
	public GameObject Spawn()
	{
		GameObject item;

		if (pool.Count > 0)
		{
			foreach (GameObject obj in pool)
			{
				if (obj.activeInHierarchy == false)
				{
					obj.SetActive(true);
					return obj;
				}
			}

		}
		else
		{
			item = GameObject.Instantiate(prefab) as GameObject;

		}
		return null;
	}

	// Recycle an object back into the pool.
	public void BackToPool(GameObject obj)
	{
		obj.SetActive(false);

	}


}
