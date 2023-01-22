using UnityEngine;
using System;

namespace BattleTank.Bullet
{
	public class BulletService : GenericSingleton<BulletService>
	{
		[SerializeField] private BulletView bulletPrefab;
		[SerializeField] private BulletList bulletSoList;
		[SerializeField] private float waitTime;
		public BulletsPoolService bulletPool;
		public Action<int> OnBulletFired;

		private void Start()
		{
			bulletPool = GetComponent<BulletsPoolService>();
		}

		public void ShootTank(Transform _bulletSpawnTransform)
		{
			BulletController bulletController;
			bulletController = bulletPool.GetBullet(bulletPrefab);
			bulletController.SetVisible(true);
			bulletController.ShootBullet(_bulletSpawnTransform);
		}

		public BulletSO BulletRandomizer()
		{
			int index = UnityEngine.Random.Range(0, bulletSoList.bulletsList.Count);
			return bulletSoList.bulletsList[index];
		}
	}
}