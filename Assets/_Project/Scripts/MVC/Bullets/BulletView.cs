using System.Collections;
using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletView : MonoBehaviour
	{
		private Rigidbody bulletRigidBody;
		private BulletController bulletController;
		private Coroutine bulletRoutine;
		public GameObject shellExplosion;
		public Rigidbody GetBulletRigidBody() => bulletRigidBody;
		private void Awake()
		{
			bulletRigidBody = gameObject.GetComponent<Rigidbody>();
		}
		private void OnCollisionEnter(Collision collision)
		{
			bulletRoutine = StartCoroutine(bulletController.ReturnBulletRoutine());
			if (collision.gameObject.TryGetComponent<BaseTankView>(out BaseTankView component))
			{
				component.DestroyTank();
			}
		}
		private void OnDisable()
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