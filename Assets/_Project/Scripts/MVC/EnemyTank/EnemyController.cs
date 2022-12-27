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
		public EnemyController(TankModel _enemyModel, EnemyView _enemyTankView, Transform _spawnPoint, Transform _playerTankPosition)
		{
			enemyModel = _enemyModel;
			tankSpawnPoint = _spawnPoint;
			enemyTankView = GameObject.Instantiate<EnemyView>(_enemyTankView, tankSpawnPoint);
			ChangeTankColour();
			playerTankPosition = _playerTankPosition;
			enemyTankView.SetController(this);
		}

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
			if (GetDistanceBetweenTankAndEnemy() <= 7)
			{
				BulletService.instance.ShootTank(enemyTankView.GetBulletSpawnTransform());
			}
		}
	}
}
