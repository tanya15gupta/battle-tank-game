using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace BattleTank
{
	public class EnemyView : GenericViewForTanks
	{
		private EnemyController enemyTankController;
		private NavMeshAgent agent;
		private void Start()
		{
			agent = gameObject.GetComponent<NavMeshAgent>();
			//patrollingPoints = enemyTankController.enemyPatrol;
		}
		public void SetController(EnemyController _enemyTankController)
		{
			enemyTankController = _enemyTankController;
		}
		public NavMeshAgent EnemyTankAgent() => agent;
		private void Update()
		{
			enemyTankController.MoveTankAI();
			//enemyTankController.ShootTank();
		}

	}
}