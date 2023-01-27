namespace BattleTank
{
	public class ChaseState : StateBaseClass
	{
		public ChaseState(EnemyController _enemyController) : base(_enemyController)
		{
			stateName = STATE.CHASE;
			agent.speed = enemyController.GetTankSpeed() / 100;
			agent.isStopped = false;
		}
		public override void OnUpdate()
		{
			if (TankService.instance.GetPlayerPosition() == null)
				return;
			agent.SetDestination(TankService.instance.GetPlayerPosition());
			if (agent.hasPath)
			{
				if (enemyController.IsPlayerInShootRange())
					EnterShootingState();
				else if (!enemyController.IsPlayerInChaseRange() || !enemyController.IsPlayerInShootRange())
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
