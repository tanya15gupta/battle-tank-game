using UnityEngine;

namespace BattleTank
{
	public class TankView : MonoBehaviour
	{
		private TankController tankController;
		[SerializeField] private Rigidbody tankRigidbody;
		[SerializeField] private Transform tankBody;
		[SerializeField] private Transform bulletSpawnPoint;

		private void FixedUpdate()
		{
			tankController.MoveTank();
		}

		public Rigidbody GetRigidbody() => tankRigidbody;

		public Transform GetTankBody() => tankBody;

		public Transform GetBulletSpawnPoint() => bulletSpawnPoint;

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}