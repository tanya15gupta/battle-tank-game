using UnityEngine;
using BattleTank.Bullet;
using System;
namespace BattleTank.UI
{
	public class UIService : GenericSingleton<UIService>
	{
		[SerializeField] private FixedJoystick fixedJoystick;
		public float GetJoystickHorizontal() => fixedJoystick.Horizontal;
		public float GetJoystickVertical() => fixedJoystick.Vertical;
		public void ShootPressed()
		{
			BulletService.instance.ShootTank(TankService.instance.GetBulletTransform());
			//isButtonPressed = true;
		}

	}
}
