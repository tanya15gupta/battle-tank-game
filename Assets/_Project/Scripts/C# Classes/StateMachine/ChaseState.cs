using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
namespace BattleTank
{
	public class ChaseState : EnemyStateMachine
	{
		public ChaseState(EnemyController _enemyController) : base(_enemyController)
		{
			stateName = STATE.CHASE;
			agent.speed = 8;
			agent.isStopped = false;
		}
		public override void OnUpdate()
		{
			agent.SetDestination(enemyController.GetPlayerTankPosition().position);
			if(agent.hasPath)
			{
				if(IsPlayerInShootRange())
					EnterShootingState();
				else if(!IsPlayerInChaseRange() || !IsPlayerInShootRange())
					EnterPatrolState();
			}
		}
		private void EnterShootingState()
		{
			nextState = new ShootState(enemyController);
			currentStage = EVENT.EXIT;
		}
		private void EnterPatrolState()
		{
			nextState = new PatrolState(enemyController);
			currentStage = EVENT.EXIT;
		}
	}
}
