using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletController
	{
		private BulletModel bulletModel;
		private BulletView bulletView;
		private BulletView bulletPrefab;
		private Transform bulletSpawnPoint;
		private bool shootPressed;
		private Vector3 bulletDirection;
		public BulletController(BulletView _bulletView, BulletModel _bulletModel)
		{
			bulletDirection = Vector3.zero;
			bulletModel = _bulletModel;
			bulletView = _bulletView;
			bulletView.SetBulletController(this);
		}

		public bool IsShootPressed() => shootPressed;

		public void ShootBullet(Transform _bulletSpawnPoint)
		{
			bulletPrefab = GameObject.Instantiate<BulletView>(bulletView, _bulletSpawnPoint);
			bulletDirection = bulletPrefab.transform.forward;
			bulletPrefab.GetBulletRigidBody().AddForce(bulletDirection * bulletModel.speed * Time.deltaTime,ForceMode.Impulse);
			/*for (int i = 0; i < bulletModel.shotsFired; i++)
			{
				bullets[i] = GameObject.Instantiate<BulletView>(bulletView, bulletSpawnPoint);
				bullets[i].GetBulletRigidBody().AddForce(Vector3.forward, ForceMode.Impulse);
			}*/
		}
	}
}
