using System.Collections;
using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletController
	{
		private BulletModel bulletModel;
		private BulletView bulletPrfab;
		private bool shootPressed;
		private GameObject explosionEffect;
		public BulletController(BulletView _bulletPrfab, BulletModel _bulletModel)
		{
			bulletModel = _bulletModel;
			bulletPrfab = GameObject.Instantiate<BulletView>(_bulletPrfab);
			explosionEffect = GameObject.Instantiate(bulletModel.explosionParticalEffect);
			bulletPrfab.SetController(this);
		}

		public bool IsShootPressed() => shootPressed;
		public void SetVisible(bool _isActive)
		{
			bulletPrfab.ToggleActive(_isActive);
		}
		public void ShootBullet(Transform _bulletSpawnPoint)
		{
			bulletPrfab.transform.SetPositionAndRotation(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
			bulletPrfab.GetBulletRigidBody().AddForce(bulletPrfab.transform.forward * bulletModel.speed * Time.deltaTime,ForceMode.Impulse);
		}

		public IEnumerator ReturnBulletRoutine()
		{
			ExplosionEffect();
			yield return new WaitForSeconds(bulletModel.bulletLifeTime);
			ReturnBulletToPool();
		}
		private void ExplosionEffect()
		{
			explosionEffect.SetActive(true);
			bulletModel.explosionParticalEffect.GetComponent<ParticleSystem>().Play(true);
		}
		private void ReturnBulletToPool()
		{
			SetObjectInteractable(true);
			SetVisible(false);
			BulletService.instance.bulletPool.ReturnItem(this);
			explosionEffect.SetActive(false);
			bulletModel.explosionParticalEffect.GetComponent<ParticleSystem>().Stop(true);
		}
		public void SetObjectInteractable(bool _isTrue)
		{
			bulletPrfab.GetComponent<MeshRenderer>().enabled = _isTrue;
			bulletPrfab.GetBulletRigidBody().isKinematic = _isTrue;
		}
	}
}
