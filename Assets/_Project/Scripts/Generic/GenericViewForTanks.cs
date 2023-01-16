using UnityEngine;

namespace BattleTank
{
	[RequireComponent(typeof(Rigidbody))]
    public abstract class GenericViewForTanks : MonoBehaviour
    {
		[SerializeField] protected Rigidbody tankRigidbody;
		[SerializeField] protected Transform tankBody;
		[SerializeField] protected Transform bulletSpawnPoint;

		public Rigidbody GetRigidbody() => tankRigidbody;
		public Transform GetBulletSpawnPoint() => bulletSpawnPoint;
		public Transform GetTankBody() => tankBody;
		public virtual void TankGotHit() { }
	}
}
