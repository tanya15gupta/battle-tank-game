using UnityEngine;

namespace BattleTank
{
	public class TankController
	{
		private TankModel tankModel;
		private TankView tankView;
		private Vector3 moveDirection;
		public FixedJoystick joystick { get; private set; }
		public TankController(TankModel _tankModel, TankView _tankView, FixedJoystick _joystick)
		{
			tankModel = _tankModel;
			tankView = GameObject.Instantiate<TankView>(_tankView);
			joystick = _joystick;
			moveDirection = Vector3.zero;
			tankView.SetController(this);
		}

		public void ChangeTankColour()
		{
			tankView.tankMaterial.color = tankModel.tankColour;
		}

		public void MoveTank()
		{
			moveDirection.x = joystick.Horizontal;
			moveDirection.z = joystick.Vertical;
			tankView.TankRigidbody.velocity = moveDirection * tankModel.tankSpeed * Time.fixedDeltaTime;
			if(moveDirection != Vector3.zero)
				tankView.transform.forward = (moveDirection);
		}
	}
}