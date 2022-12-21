using UnityEngine;

namespace BattleTank.Bullet
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damageAmount { get; private set; }
        public float shotsFired { get; private set; }
        public BulletModel(BulletSO _bulletSO)
		{
            speed = _bulletSO.speed;
            damageAmount = _bulletSO.damageDone;
            shotsFired = _bulletSO.shotsFired;
		}
    }
}
