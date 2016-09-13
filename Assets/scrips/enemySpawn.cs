using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour
{
	public project objectPool;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			objectPool.spawnObject ();
		}
	}
}
