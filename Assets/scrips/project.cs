using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class project : MonoBehaviour {

	public GameObject PrefabsToPool;
	public int poolSize = 10;
	[HideInInspector]
	public List<GameObject> objectPool = new List<GameObject> ();
	public List<GameObject> activePoolObject = new List<GameObject>();

	void Start()
	{
		if (PrefabsToPool == null) 
		{
			Debug.LogError ("PrefabToPool is null. Assing reference in Inspector.");
		}	

		for (int i = 0; i < poolSize; i++) {
			GameObject newGameObject = (GameObject)Instantiate (PrefabsToPool);
			newGameObject.name = "Enemy_" + i;
			newGameObject.transform.parent = this.transform;
			objectPool.Add (newGameObject);
			newGameObject.SetActive (false);
		}
	}

	public GameObject spawnObject ()
	{
		if (objectPool.Count <= 0) 
		{
			Debug.LogWarning ("no more game objects pooled to spawn.");
			return null;
		}
		int i = objectPool.Count - 1;
		activePoolObject.Add(objectPool[i]);
		int j = activePoolObject.Count - 1;
		objectPool.RemoveAt (i);
		activePoolObject [j].transform.position = new Vector2(Random.Range(-2f,2f), Random.Range(-2f,2f));
		activePoolObject [j].SetActive (true);
		return activePoolObject [j];
	}
}


