using UnityEngine;

namespace BattleTank.Bullet
{
	public class BulletView : MonoBehaviour
	{
		[SerializeField] private float destroyTimer;
		private Rigidbody bulletRigidBody;
		private BulletController bulletController;
		private void Awake()
		{
			destroyTimer = .8f;
			bulletRigidBody = gameObject.GetComponent<Rigidbody>();
		}
		public Rigidbody GetBulletRigidBody() => bulletRigidBody;

		public void SetBulletController(BulletController _bulletController)
		{
			bulletController = _bulletController;
		}
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<TankView>(out TankView component))
			{
				component.PlayerGotHit();
			}
			Destroy(gameObject);
		}

		private void Update()
		{
			destroyTimer -= Time.deltaTime;
			if (destroyTimer <= 0)
				Destroy(gameObject);
		}
	}
}
