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
		float shootCooldown;
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
			enemyTankView.SetController(this);
		}
		public Transform GetBulletSpawnTransform() => enemyTankView.GetBulletSpawnPoint();

		public void ChangeTankColour()
		{
			for (int i = 0; i < enemyTankView.GetTankBody().childCount; i++)
			{
				enemyTankView.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = enemyModel.tankMaterial;
			}
		}

		public float GetDistanceBetweenTankAndEnemy()
		{
			distanceBetweenPlayerAndEnemy = Vector3.Distance(playerTankPosition.position, enemyTankView.transform.position);
			return distanceBetweenPlayerAndEnemy;
		}

		public void MoveTankAI()
		{
			if (GetDistanceBetweenTankAndEnemy() < 50)
			{
				enemyTankView.transform.LookAt(playerTankPosition);
				if (GetDistanceBetweenTankAndEnemy() > 7)
					enemyTankView.GetRigidbody().velocity = enemyTankView.transform.forward * enemyModel.tankSpeed * Time.deltaTime;
				else
					enemyTankView.GetRigidbody().velocity = Vector3.zero;
			}
		}

		public void ShootTank()
		{
			shootCooldown -= Time.deltaTime;
			if (GetDistanceBetweenTankAndEnemy() <= 7 && shootCooldown <= 0)
			{
				shootCooldown = resetCooldownTime;
				BulletService.instance.ShootTank(GetBulletSpawnTransform());
			}
		}
	}
}
