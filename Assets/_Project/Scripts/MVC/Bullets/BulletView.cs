using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletView : MonoBehaviour
	{
		private Rigidbody bulletRigidBody;
		private BulletController bulletController;
		private void Awake()
		{
			bulletRigidBody = gameObject.GetComponent<Rigidbody>();
		}
		public Rigidbody GetBulletRigidBody() => bulletRigidBody;

		public void SetBulletController(BulletController _bulletController)
		{
			bulletController = _bulletController;
		}
		public void ToggleActive(bool _isOn)
		{
			gameObject.SetActive(_isOn);
		}
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<GenericViewForTanks>(out GenericViewForTanks component))
			{
				component.TankGotHit();
			}
		}
	}
}
