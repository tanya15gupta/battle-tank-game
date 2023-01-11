using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
namespace BattleTank
{
	public class EnemyController
	{
		private StateBaseClass enemyState;
		private EnemyView enemyTankView;
		private EnemyModel enemyModel;

		public EnemyController(EnemyModel _enemyModel, EnemyView _enemyTankView, Transform _spawnPoint)
		{
			enemyModel = _enemyModel;
			enemyTankView = GameObject.Instantiate<EnemyView>(_enemyTankView, _spawnPoint);
			ChangeTankColour();
			enemyState = new IdleState(this);
			enemyTankView.SetController(this);
		}

		public Transform GetBulletSpawnTransform() => enemyTankView.GetBulletSpawnPoint();

		public List<Transform> GetPatrolPoints() => enemyModel.PatrolPoints;

		public float GetShootingDisstance() => enemyModel.ShootingDistance;

		public float GetDetectionRadius() => enemyModel.ChasingRadius;

		public Transform GetEnemyTankTransform() => enemyTankView.transform;

		public float GetTankSpeed() => enemyModel.tankSpeed;

		public void EnemyReceivedHit() => enemyTankView.DestroySelf();

		public NavMeshAgent GetNavmeshAgent() => enemyTankView.EnemyTankAgent();

		private void ChangeTankColour()
		{
			for (int i = 0; i < enemyTankView.GetTankBody().childCount; i++)
			{
				enemyTankView.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = enemyModel.tankMaterial;
			}
		}

		public void MoveTankAI()
		{
			enemyState = enemyState.Processing();
		}

	}
}
