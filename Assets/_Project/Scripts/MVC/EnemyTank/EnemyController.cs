using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
namespace BattleTank
{
	public class EnemyController
	{
		private Transform tankSpawnPoint;
		private EnemyStateMachine enemyState;
		private EnemyView enemyTankView;
		private EnemyModel enemyModel;
		private Transform playerTankPosition;
		public EnemyController(EnemyModel _enemyModel, EnemyView _enemyTankView, Transform _spawnPoint, Transform _playerTankPosition)
		{
			enemyModel = _enemyModel;
			tankSpawnPoint = _spawnPoint;
			enemyTankView = GameObject.Instantiate<EnemyView>(_enemyTankView, tankSpawnPoint);
			ChangeTankColour();
			enemyState = new IdleState(this);
			enemyTankView.SetController(this);
			playerTankPosition = _playerTankPosition;
		}
		public Transform GetBulletSpawnTransform() => enemyTankView.GetBulletSpawnPoint();
		public List<Transform> GetPatrolPoints() => enemyModel.PatrolPoints;
		public Transform GetPlayerTankPosition() => playerTankPosition;
		public Transform GetEnemyTankTransform() => enemyTankView.transform;
		public NavMeshAgent GetNavMeshAgent() => enemyTankView.EnemyTankAgent();
		public float GetTankSpeed() => enemyModel.tankSpeed;
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
