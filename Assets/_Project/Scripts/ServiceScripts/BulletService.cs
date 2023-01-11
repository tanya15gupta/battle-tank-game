using UnityEngine;
using System;
namespace BattleTank.Bullet
{
	public class BulletService : GenericSingleton<BulletService>
	{
		[SerializeField] private BulletView bulletPrefab;
		[SerializeField] private BulletList bulletSoList;
		[SerializeField] private BulletSO bulletSO;
		private BulletController bulletController;
		public Action<int> OnBulletFired;

		private void Start()
		{
			bulletController = new BulletController(bulletPrefab, new BulletModel(BulletRandomizer()) );
		}

		public void ShootTank(Transform _bulletSpawnTransform)
		{
			bulletController.ShootBullet(_bulletSpawnTransform);
		}

		private BulletSO BulletRandomizer()
		{
			int index = UnityEngine.Random.Range(0, bulletSoList.bulletsList.Count);
			bulletSO = bulletSoList.bulletsList[index];
			return bulletSO;
		}
	}
}
