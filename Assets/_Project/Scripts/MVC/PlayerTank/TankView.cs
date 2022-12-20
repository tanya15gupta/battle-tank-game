using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
		 private Rigidbody tankRigidbody;

        private TankController tankController;
		//private float inputHorizontal;
		//private float inputVertical;
		public Rigidbody TankRigidbody;
		public Material tankMaterial;
		//private Vector3 tankMovement;

		private void Start()
		{
			tankRigidbody = TankRigidbody;
			tankController.ChangeTankColour();
		}

		/*private void Update()
		{
			inputHorizontal = tankController.joystick.Horizontal;
			inputVertical = tankController.joystick.Vertical;
			tankMovement = new Vector3(inputHorizontal, 0, inputVertical);
		}*/

		private void FixedUpdate()
		{
			/*f(inputHorizontal != 0 || inputVertical != 0)
			{
				tankController.MoveTank();
			}*/
			tankController.MoveTank();

		}

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}