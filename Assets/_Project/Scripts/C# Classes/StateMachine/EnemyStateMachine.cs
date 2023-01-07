using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace BattleTank
{
    public class EnemyStateMachine
    {
        public enum STATE   {   IDLE, PATROL, CHASE, ATTACK   }

        public enum EVENT   {   ENTER, UPDATE, EXIT    }

        protected STATE stateName;
        protected EVENT currentStage;
        protected GameObject enemyTank;
        protected EnemyStateMachine nextState;
        protected List<Transform> patrollingPoints;
        protected NavMeshAgent agent;
        protected EnemyController enemyController;
        protected float shootingDistance = 8.0f;
        protected float visibilityDistance = 15.0f;
        public EnemyStateMachine(EnemyController _enemyController)
		{
            enemyController = _enemyController;
            patrollingPoints = enemyController.GetPatrolPoints();
            agent = enemyController.GetNavMeshAgent();
		}

        public virtual void OnEnter()
		{
            currentStage = EVENT.UPDATE;
		}
        
        public virtual void OnUpdate()
		{
            currentStage = EVENT.UPDATE;
		}

        public virtual void OnExit()
		{
            currentStage = EVENT.EXIT;
		}

        public EnemyStateMachine Processing()
		{
            if(currentStage == EVENT.ENTER) { OnEnter(); }
            if(currentStage == EVENT.UPDATE) { OnUpdate(); }
            if(currentStage == EVENT.EXIT)
			{
                OnExit();
                return nextState;
			}
            return this;
		}
        public bool IsPlayerInChaseRange()
		{
            float distance = Vector3.Distance(enemyController.GetPlayerTankPosition().position, enemyController.GetEnemyTankTransform().position);
            if (distance < visibilityDistance)
                return true;
            return false;
		}
        public bool IsPlayerInShootRange()
        {
            float distance = Vector3.Distance(enemyController.GetPlayerTankPosition().position, enemyController.GetEnemyTankTransform().position);
            if (distance < shootingDistance)
                return true;
            return false;
        }
    }
}
