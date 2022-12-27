using UnityEngine;

namespace BattleTank
{
	public class EnemyView : MonoBehaviour
	{
		[SerializeField] private Rigidbody tankRigidbody;
		[SerializeField] private Transform tankBody;
		[SerializeField] private Transform bulletSpawnPoint;
		private EnemyController enemyTankController;

		private void FixedUpdate()
		{
			enemyTankController.MoveTankAI();
			enemyTankController.ShootTank();
		}

		public Rigidbody GetRigidbody() => tankRigidbody;

		public Transform GetTankBody() => tankBody;

		public Transform GetBulletSpawnTransform() => bulletSpawnPoint;

		public void SetController(EnemyController _enemyTankController)
		{
			enemyTankController = _enemyTankController;
		}
	}
}