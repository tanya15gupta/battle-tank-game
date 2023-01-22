using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletView : MonoBehaviour
	{
		private Rigidbody bulletRigidBody;
		private BulletController bulletController;
		private Coroutine bulletRoutine;
		
		public Rigidbody GetBulletRigidBody() => bulletRigidBody;
		private void Awake()
		{
			bulletRigidBody = gameObject.GetComponent<Rigidbody>();
		}

		private void Update()
		{
 			bulletRoutine = StartCoroutine(bulletController.ReturnBulletRoutine());
		}
		private void OnCollisionEnter(Collision collision)
		{
 			bulletRoutine = StartCoroutine(bulletController.ReturnBulletRoutine());
			bulletController.SetObjectInteractable(false);
			if (collision.gameObject.TryGetComponent<GenericViewForTanks>(out GenericViewForTanks component))
			{
				component.DestroyTank();
			}
			//bulletController.ReturnBulletToPool();
		}
		private void OnDestroy()
		{
			StopCoroutine(bulletRoutine);
		}

		public void ToggleActive(bool _isOn)
		{
			gameObject.SetActive(_isOn);
		}
		public void SetController(BulletController _bulletController)
		{
			bulletController = _bulletController;
		}
	}
}
