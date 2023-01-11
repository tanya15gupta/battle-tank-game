using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
	public class EnemyView : GenericViewForTanks
	{
		private EnemyController enemyTankController;
		private NavMeshAgent agent;
		public NavMeshAgent EnemyTankAgent() => agent;
		public void SetController(EnemyController _enemyTankController)
		{
			enemyTankController = _enemyTankController;
		}
		private void Start()
		{
			agent = gameObject.GetComponent<NavMeshAgent>();
		}
		private void Update()
		{
			enemyTankController.MoveTankAI();
		}

		public override void TankGotHit()
		{
			enemyTankController.EnemyReceivedHit();
		}

		public void DestroySelf()
		{
			Destroy(gameObject);
		}
	}
}