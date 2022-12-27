using UnityEngine;
using BattleTank.Bullet;

namespace BattleTank.UI
{
	public class UIService : GenericSingleton<UIService>
	{
		[SerializeField] private FixedJoystick fixedJoystick;
		[SerializeField] private bool isButtonPressed = false;
		public FixedJoystick GetJoystick() => fixedJoystick;
		public void ShootPressed()
		{
			BulletService.instance.ShootTank(TankService.instance.GetBulletTransform());
			//isButtonPressed = true;
		}

		public void IsShootPressed(bool _pressed)
		{
			isButtonPressed = _pressed;
		}
	}
}
