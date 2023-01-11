using UnityEngine;
using BattleTank.Bullet;
using System;
namespace BattleTank.UI
{
	public class UIService : GenericSingleton<UIService>
	{
		[SerializeField] private FixedJoystick fixedJoystick;
		private int bulletCount = 0;
		public float GetJoystickHorizontal() => fixedJoystick.Horizontal;
		public float GetJoystickVertical() => fixedJoystick.Vertical;
		public void ShootPressed()
		{
			bulletCount++;
			BulletService.instance.OnBulletFired?.Invoke(bulletCount);
			BulletService.instance.ShootTank(TankService.instance.GetBulletTransform());
			//isButtonPressed = true;
		}
	}
}
