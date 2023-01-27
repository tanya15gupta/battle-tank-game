using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
namespace BattleTank
{
	public class EnemyController
	{
		private StateBaseClass enemyState;
		private EnemyView enemyTankPrefab;
		private EnemyModel enemyModel;
		private float shootCooldown;
		public EnemyController(EnemyModel _enemyModel, EnemyView _enemyTankView, Transform _spawnPoint)
		{
			enemyModel = _enemyModel;
			shootCooldown = enemyModel.ShootCoolDown;
			enemyTankPrefab = GameObject.Instantiate<EnemyView>(_enemyTankView, _spawnPoint);
			ChangeTankColour();
			enemyState = new IdleState(this);
			enemyTankPrefab.SetController(this);
		}

		public Transform GetBulletSpawnTransform() => enemyTankPrefab.GetBulletSpawnPoint();

		public List<Transform> GetPatrolPoints() => enemyModel.PatrolPoints;

		public Transform GetEnemyTankTransform() => enemyTankPrefab.transform;

		public float GetTankSpeed() => enemyModel.tankSpeed;

		public void EnemyReceivedHit() => Object.Destroy(enemyTankPrefab.gameObject);

		public NavMeshAgent GetNavmeshAgent() => enemyTankPrefab.EnemyTankAgent();

		private void ChangeTankColour()
		{
			for (int i = 0; i < enemyTankPrefab.GetTankBody().childCount; i++)
			{
				enemyTankPrefab.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = enemyModel.tankMaterial;
			}
		}
		private float DistanceBetweenTanks()
		{
			if (TankService.instance.GetPlayerPosition() == null)
				return Mathf.Infinity;
			float distance = Vector3.Distance(TankService.instance.GetPlayerPosition(), enemyTankPrefab.transform.position);
			return distance;
		}
		public void MoveTankAI()
		{
			enemyState = enemyState.Processing();
		}
		public bool IsPlayerInChaseRange()
		{
			float distance = DistanceBetweenTanks();
			if (distance < enemyModel.ChasingRadius)
				return true;
			return false;
		}
		public bool IsPlayerInShootRange()
		{
			float distance = DistanceBetweenTanks();
			if (distance < enemyModel.ShootingDistance)
				return true;
			return false;
		}
		public void ShootingPlayerTank()
		{
			GetEnemyTankTransform().LookAt(TankService.instance.GetPlayerPosition());
			shootCooldown += Time.deltaTime;
			if (shootCooldown >= enemyModel.ShootCoolDown)
			{
				shootCooldown = 0;
				Bullet.BulletService.instance.ShootTank(GetBulletSpawnTransform());
			}
		}
	}
}
