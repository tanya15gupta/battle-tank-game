using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace BattleTank
{
    public class PatrolState : EnemyStateMachine
	{
		private int currentIndex = -1;
		public PatrolState(EnemyController _enemyController) : base(_enemyController)
		{
			stateName = STATE.PATROL;
			agent.speed = enemyController.GetTankSpeed()/100;
			agent.isStopped = false;
		}
		public override void OnEnter()
		{
			currentIndex = 0;
			base.OnEnter();
		}
		public override void OnUpdate()
		{
			if (IsPlayerInChaseRange())
			{
				EnterChaseState();
				return;
			}
			Patrolling();
		}
		private void Patrolling()
		{
			if (agent.remainingDistance < 1)
			{
				if (currentIndex >= (patrollingPoints.Count - 1))
					currentIndex = 0;
				else
					currentIndex++;
				agent.SetDestination(patrollingPoints[currentIndex].transform.position);
			}
		}
		private void EnterChaseState()
		{ 
			nextState = new ChaseState(enemyController);
			currentStage = EVENT.EXIT;
		}
	}
}
