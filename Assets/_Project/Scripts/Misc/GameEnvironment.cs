using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class GameEnvironment : MonoBehaviour
    {
        [SerializeField] private List<GameObject> environmentObjectsToBeDestroyed = new List<GameObject>();
        [SerializeField] private List<GameObject> enemiesToBeDestroyed = new List<GameObject>();
        [SerializeField] private int childrenCount;
        [SerializeField] private int enemiesCount;

		private void Start()
		{
            GetGameobjects();
            TankService.instance.OnPlayerDeath += DestroyGameEnvironment;
		}
		private void GetGameobjects()
        {
            childrenCount = gameObject.GetComponentInChildren<Transform>().childCount;
            for (int i = 0; i < childrenCount; i++)
            {
                environmentObjectsToBeDestroyed.Add(gameObject.transform.GetChild(i).gameObject);
            }
            enemiesCount = EnemyTankService.instance.gameObject.GetComponentInChildren<Transform>().childCount;
            for (int i = 0; i < enemiesCount; i++)
            {
                enemiesToBeDestroyed.Add(EnemyTankService.instance.gameObject.transform.GetChild(i).gameObject);
            }
        }
        private void DestroyGameEnvironment()
		{
            StartCoroutine(DestroyEnvironment());
		}
        private IEnumerator DestroyEnvironment()
		{
            for (int i = childrenCount - 1; i > 0; i--)
            {
                yield return new WaitForSeconds(3);
                Destroy(environmentObjectsToBeDestroyed[i]);
            }
        }
    }
}
