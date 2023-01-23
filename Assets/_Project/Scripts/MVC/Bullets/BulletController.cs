using System.Collections;
using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletController
	{
		private BulletModel bulletModel;
		private BulletView bulletPrfab;
		private ParticleSystem shellExplosionPS;
		public BulletController(BulletView _bulletPrfab, BulletModel _bulletModel)
		{
			bulletModel = _bulletModel;
			bulletPrfab = GameObject.Instantiate<BulletView>(_bulletPrfab);
			bulletPrfab.shellExplosion = GameObject.Instantiate(bulletModel.explosionParticalEffect);
			shellExplosionPS = bulletPrfab.shellExplosion.GetComponent<ParticleSystem>();
			shellExplosionPS.Stop();
			bulletPrfab.SetController(this);
		}
		public void SetVisible(bool _isActive)
		{
			bulletPrfab.ToggleActive(_isActive);
		}
		public void ShootBullet(Transform _bulletSpawnPoint)
		{
			bulletPrfab.transform.SetPositionAndRotation(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
			bulletPrfab.GetBulletRigidBody().AddForce(bulletPrfab.transform.forward * bulletModel.speed * Time.deltaTime, ForceMode.Force);
		}

		public IEnumerator ReturnBulletRoutine()
		{
			ExplosionEffect();
			yield return new WaitForSeconds(bulletModel.bulletLifeTime);
			ReturnBulletToPool();
		}
		public void ExplosionEffect()
		{
			bulletPrfab.GetComponent<MeshRenderer>().enabled = false;
			bulletPrfab.shellExplosion.SetActive(true);
			shellExplosionPS.transform.position = bulletPrfab.transform.position;
			shellExplosionPS.Play(true);
		}
		private void ReturnBulletToPool()
		{
			bulletPrfab.GetComponent<MeshRenderer>().enabled = true;
			SetVisible(false);
			BulletService.instance.bulletPool.ReturnItem(this);
			bulletPrfab.shellExplosion.SetActive(false);
			shellExplosionPS.Stop(true);
		}
	}
}
