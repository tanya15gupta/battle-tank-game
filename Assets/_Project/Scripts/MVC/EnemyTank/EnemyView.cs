using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
	public class EnemyView : BaseTankView
	{
		private EnemyController enemyTankController;
		private NavMeshAgent agent;
		public NavMeshAgent EnemyTankAgent() => agent;

		private void Start()
		{
			agent = gameObject.GetComponent<NavMeshAgent>();
			TankService.instance.OnPlayerDeath += DestroyTank;
		}
		private void Update()
		{
			enemyTankController.MoveTankAI();
		}
		public void SetController(EnemyController _enemyTankController)
		{
			enemyTankController = _enemyTankController;
		}
		public override void DestroyTank()
		{
			enemyTankController.EnemyReceivedHit();
		}
		private void OnDisable()
		{
			TankService.instance.OnPlayerDeath -= DestroyTank;
		}
	}
}