using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
		private Rigidbody tankRigidbody;

        private TankController tankController;
		public Rigidbody TankRigidbody;
		public Material tankMaterial;

		private void Start()
		{
			tankRigidbody = TankRigidbody;
			tankController.ChangeTankColour();
		}
		private void FixedUpdate()
		{
			tankController.MoveTank();
		}

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}