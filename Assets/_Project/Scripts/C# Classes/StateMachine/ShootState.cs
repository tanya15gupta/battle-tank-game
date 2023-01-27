using UnityEngine;
using BattleTank.Bullet;
namespace BattleTank
{
	public class ShootState : StateBaseClass
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
			if (!enemyController.IsPlayerInShootRange())
			{
				EnterPatrolState();
				return;
			}
			enemyController.ShootingPlayerTank();
		}

		private void EnterPatrolState()
		{
			nextState = new PatrolState(enemyController);
			currentStage = EVENT.EXIT;
		}
	}
}
