using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletController
	{
		private BulletModel bulletModel;
		private BulletView bulletView;
		private bool shootPressed;
		private Vector3 bulletDirection;
		public BulletController(BulletView _bulletPrfab, BulletModel _bulletModel)
		{
			bulletDirection = Vector3.zero;
			bulletModel = _bulletModel;
			bulletView = GameObject.Instantiate<BulletView>(_bulletPrfab);
			bulletView.SetBulletController(this);
		}

		public bool IsShootPressed() => shootPressed;
		public void SetVisible(bool _isActive)
		{
			bulletView.ToggleActive(_isActive);
		}
		public void ShootBullet(Transform _bulletSpawnPoint)
		{
			bulletView.transform.SetPositionAndRotation(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
			bulletDirection = bulletView.transform.forward;
			bulletView.GetBulletRigidBody().AddForce(bulletDirection * bulletModel.speed * Time.deltaTime,ForceMode.Impulse);
		}
	}
}
