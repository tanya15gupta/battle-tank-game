using UnityEngine;

namespace BattleTank
{
    public class GenericViewForTanks : MonoBehaviour
    {
		[SerializeField] protected Rigidbody tankRigidbody;
		[SerializeField] protected Transform tankBody;
		[SerializeField] protected Transform bulletSpawnPoint;

		public Rigidbody GetRigidbody() => tankRigidbody;
		public Transform GetBulletSpawnPoint() => bulletSpawnPoint;
		public Transform GetTankBody() => tankBody;
	}
}
