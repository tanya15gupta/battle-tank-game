using UnityEngine;
using System;
using System.Collections;

namespace BattleTank.Bullet
{
	public class BulletService : GenericSingleton<BulletService>
	{
		[SerializeField] private BulletView bulletPrefab;
		[SerializeField] private BulletList bulletSoList;
		[SerializeField] private float waitTime;
		private BulletModel bulletModel;
		private BulletController bulletController;
		private BulletsPoolService createBullet;
		public Action<int> OnBulletFired;

		private void Start()
		{
			createBullet = GetComponent<BulletsPoolService>();
		}

		IEnumerator ReturnBulletToPool(float _waitTime, BulletController _bulletController)
		{
			yield return new WaitForSeconds(_waitTime);
			bulletController.SetVisible(false);
			createBullet.ReturnItem(_bulletController);
		}

		public void ShootTank(Transform _bulletSpawnTransform)
		{
			bulletController = createBullet.GetBullet(bulletPrefab);
			bulletController.SetVisible(true);
			bulletController.ShootBullet(_bulletSpawnTransform);
			StartCoroutine(ReturnBulletToPool(waitTime, bulletController));
		}

		public BulletSO BulletRandomizer()
		{
			int index = UnityEngine.Random.Range(0, bulletSoList.bulletsList.Count);
			return bulletSoList.bulletsList[index];
		}
	}
}