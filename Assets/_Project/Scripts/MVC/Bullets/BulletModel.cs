using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletModel
	{
		public float speed { get; private set; }
		public float damageAmount { get; private set; }
		public int shotsFired { get; private set; }
		public float bulletLifeTime { get; private set; }
		public GameObject explosionParticalEffect { get; private set; }
		public BulletModel(BulletSO _bulletSO)
		{
			speed = _bulletSO.Speed;
			damageAmount = _bulletSO.DamageDone;
			shotsFired = _bulletSO.ShotsFired;
			bulletLifeTime = _bulletSO.BulletLifeTime;
			explosionParticalEffect = _bulletSO.ExplosionParticalsEffect;
		}
	}
}
