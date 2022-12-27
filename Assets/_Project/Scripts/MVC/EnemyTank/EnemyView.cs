using UnityEngine;

namespace BattleTank
{
	public class EnemyView : GenericViewForTanks
	{
		private EnemyController enemyTankController;
		private void FixedUpdate()
		{
			enemyTankController.MoveTankAI();
			enemyTankController.ShootTank();
		}

		public void SetController(EnemyController _enemyTankController)
		{
			enemyTankController = _enemyTankController;
		}
	}
}