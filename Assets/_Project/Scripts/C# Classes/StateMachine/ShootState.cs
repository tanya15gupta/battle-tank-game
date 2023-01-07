using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using BattleTank.Bullet;
namespace BattleTank
{
	public class ShootState : EnemyStateMachine
	{
		private float shootCooldown;
		public ShootState(EnemyController _enemyController) : base(_enemyController)
		{
			stateName = STATE.ATTACK;
		}
		public override void OnEnter()
		{
			agent.isStopped = true;
			base.OnEnter();
		}
		public override void OnUpdate()
		{
			if (!IsPlayerInShootRange())
			{
				EnterPatrolState();
				return;
			}
			ShootingPlayerTank();
		}
		private void ShootingPlayerTank()
		{
			enemyController.GetEnemyTankTransform().transform.LookAt(enemyController.GetPlayerTankPosition());
			shootCooldown += Time.deltaTime;
			if (shootCooldown >= 2.0f)
			{
				shootCooldown = 0;
				BulletService.instance.ShootTank(enemyController.GetBulletSpawnTransform());
			}
		}
		private void EnterPatrolState()
		{
			nextState = new PatrolState(enemyController);
			currentStage = EVENT.EXIT;
		}
	}
}
