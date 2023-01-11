using UnityEngine;
using UnityEngine.AI;
using BattleTank.Bullet;
namespace BattleTank
{
	public class EnemyTankService : GenericSingleton<EnemyTankService>
	{
		[SerializeField] private EnemyView enemyTankPrefab;
		[SerializeField] private TankObjectsList tankSoList;
		private EnemyController enemyTankController;
		private void Start()
		{
			SpawnEnemy();
		}

		private void SpawnEnemy()
		{
			enemyTankController = new EnemyController(new EnemyModel(TankRandomizer()), enemyTankPrefab, this.gameObject.transform);
		}

		private TankScriptableObject TankRandomizer()
		{
			TankScriptableObject tankSO;
			int index = Random.Range(0, tankSoList.list.Count);
			tankSO = tankSoList.list[index];
			return tankSO;
		}
	}
}
