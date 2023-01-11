using UnityEngine;
using BattleTank.Bullet;
namespace BattleTank
{
	public class EnemyTankService : GenericSingleton<EnemyTankService>
	{
		[SerializeField] private EnemyView enemyTankPrefab;
		[SerializeField] private TankObjectsList tankSoList;
		private TankScriptableObject tankSO;
		private EnemyController enemyTankController;
		private void Start()
		{
			enemyTankController = new EnemyController(new TankModel(TankRandomizer()), enemyTankPrefab, this.gameObject.transform, TankService.instance.PlayerPosition());
		}

		private TankScriptableObject TankRandomizer()
		{
			int index = Random.Range(0, tankSoList.list.Count);
			tankSO = tankSoList.list[index];
			return tankSO;
		}
	}
}
