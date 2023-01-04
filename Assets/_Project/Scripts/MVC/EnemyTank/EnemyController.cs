using UnityEngine;
using BattleTank.Bullet;
namespace BattleTank
{
	public class EnemyController
	{
		private EnemyView enemyTankView;
		private TankModel enemyModel;
		private Transform tankSpawnPoint;
		private Transform playerTankPosition;
		private float distanceBetweenPlayerAndEnemy;
		private float minDistance;
		private float maxDistance;
		private float shootCooldown;
		private float resetCooldownTime;
		public EnemyController(TankModel _enemyModel, EnemyView _enemyTankView, Transform _spawnPoint, Transform _playerTankPosition)
		{
			resetCooldownTime = 2.0f;
			shootCooldown = resetCooldownTime;
			enemyModel = _enemyModel;
			tankSpawnPoint = _spawnPoint;
			enemyTankView = GameObject.Instantiate<EnemyView>(_enemyTankView, tankSpawnPoint);
			ChangeTankColour();
			playerTankPosition = _playerTankPosition;
			minDistance = 7;
			maxDistance = 50;
			enemyTankView.SetController(this);
		}
		public Transform GetBulletSpawnTransform() => enemyTankView.GetBulletSpawnPoint();

		private void ChangeTankColour()
		{
			for (int i = 0; i < enemyTankView.GetTankBody().childCount; i++)
			{
				enemyTankView.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = enemyModel.tankMaterial;
			}
		}

		private float GetDistanceBetweenTankAndEnemy()
		{
			if(playerTankPosition != null)
			{
				distanceBetweenPlayerAndEnemy = Vector3.Distance(playerTankPosition.position, enemyTankView.transform.position);
				return distanceBetweenPlayerAndEnemy;
			}
			return Mathf.Infinity;
		}

		public void MoveTankAI()
		{
			if (GetDistanceBetweenTankAndEnemy() < maxDistance)
			{
				enemyTankView.transform.LookAt(playerTankPosition);
				if (GetDistanceBetweenTankAndEnemy() > minDistance)
					enemyTankView.GetRigidbody().velocity = enemyTankView.transform.forward * enemyModel.tankSpeed * Time.deltaTime;
				else
					enemyTankView.GetRigidbody().velocity = Vector3.zero;
			}
		}

		public void ShootTank()
		{
			shootCooldown -= Time.deltaTime;
			if (shootCooldown <= 0)
			{
				if (GetDistanceBetweenTankAndEnemy() <= minDistance)
				{
					shootCooldown = resetCooldownTime;
					BulletService.instance.ShootTank(GetBulletSpawnTransform());
				}
			}
		}
	}
}
