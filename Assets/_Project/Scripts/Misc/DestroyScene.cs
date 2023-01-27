using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	public class DestroyScene : GenericSingleton<DestroyScene>
	{
		[SerializeField] private List<GameObject> environmentObjectsToBeDestroyed;
		[SerializeField] private List<GameObject> enemiesToBeDestroyed;
		[SerializeField] private EnemyTankService enemyTankService;
		[SerializeField] private int childrenCount;
		[SerializeField] private int enemiesCount;
		[SerializeField] private float waitTime = 2.0f;
		private bool calledOnce = false;
		private void GetGameobjects()
		{
			childrenCount = gameObject.GetComponentInChildren<Transform>().childCount;
			for (int i = 0; i < childrenCount; i++)
			{
				environmentObjectsToBeDestroyed.Add(gameObject.transform.GetChild(i).gameObject);
			}
			enemiesCount = enemyTankService.gameObject.GetComponentInChildren<Transform>().childCount;
			for (int i = 0; i < enemiesCount; i++)
			{
				enemiesToBeDestroyed.Add(enemyTankService.gameObject.transform.GetChild(i).gameObject);
			}
		}

		public void SceneDestruction(GameObject _playerGameObject)
		{
			if (!calledOnce)
			{
				GetGameobjects();
				calledOnce = true;
			}
			StartCoroutine(DestroyEnvironment(_playerGameObject));
		}

		private IEnumerator DestroyEnvironment(GameObject _playerGameObject)
		{
			yield return StartCoroutine(DestroyEnemies());
			yield return StartCoroutine(DestroyObjectsInScene());
			yield return StartCoroutine(DestroyPlayer(_playerGameObject));
		}

		private IEnumerator DestroyEnemies()
		{
			for (int i = 0; i < enemiesCount; i++)
			{
				yield return new WaitForSeconds(waitTime);
				Destroy(enemiesToBeDestroyed[i]);
			}
		}
		private IEnumerator DestroyObjectsInScene()
		{
			for (int i = childrenCount - 1; i > 0; i--)
			{
				yield return new WaitForSeconds(waitTime);
				Destroy(environmentObjectsToBeDestroyed[i]);
			}
		}
		private IEnumerator DestroyPlayer(GameObject _playerGameObject)
		{
			yield return new WaitForSeconds(waitTime);
			Destroy(_playerGameObject);
			StopAllCoroutines();
		}
	}
}
