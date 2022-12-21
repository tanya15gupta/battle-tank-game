using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
		[SerializeField] private Rigidbody tankRigidbody;
		[SerializeField] private Transform tankBody;

		private void FixedUpdate()
		{
			tankController.MoveTank();
		}

		public Rigidbody GetRigidbody() => tankRigidbody;

		public Transform GetTankBody() => tankBody;

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}