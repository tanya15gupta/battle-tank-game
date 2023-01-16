namespace BattleTank.Bullet
{
    public class BulletsPoolService : GenericPool<BulletController>
    {
        private BulletView bulletPrefab;
     
        public BulletController GetBullet(BulletView _bulletPrefab)
		{
            bulletPrefab = _bulletPrefab;
            return GetItem();
		}
        
        protected override BulletController CreateItem()
		{
            BulletController bullet = new BulletController(bulletPrefab, new BulletModel(BulletService.instance.BulletRandomizer()));
            return bullet;
		}
    }
}