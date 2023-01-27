using UnityEngine;
namespace BattleTank
{
	public class IdleState : StateBaseClass
	{
		public IdleState(EnemyController _enemyController) : base(_enemyController)
		{
			stateName = STATE.IDLE;
		}
		public override void OnUpdate()
		{
			if (Random.Range(0, 100) <= 10)
			{
				EnterPatrolState();
			}
		}
		private void EnterPatrolState()
		{
			nextState = new PatrolState(enemyController);
			currentStage = EVENT.EXIT;
		}
	}
}
