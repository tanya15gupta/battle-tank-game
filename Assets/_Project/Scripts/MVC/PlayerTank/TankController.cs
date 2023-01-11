using UnityEngine;

namespace BattleTank
{
	public class TankController
	{
		private TankModel tankModel;
		private TankView tankView;
		private Vector3 moveDirection;
		private FixedJoystick joystick;
		private Transform tankSpawnPoint;

		public TankController(TankModel _tankModel, TankView _tankView, FixedJoystick _joystick, Transform _spawnPoint)
		{
			tankModel = _tankModel;
			tankSpawnPoint = _spawnPoint;
			tankView = GameObject.Instantiate<TankView>(_tankView, tankSpawnPoint);
			ChangeTankColour();
			joystick = _joystick;
			moveDirection = Vector3.zero;
			tankView.SetController(this);
		}
		public Transform GetTankTransform() => tankView.transform;
		public Transform GetBulletSpawnTransform() => tankView.GetBulletSpawnPoint();
		public void ChangeTankColour()
		{
			for(int i = 0; i < tankView.GetTankBody().childCount; i++)
			{
				tankView.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = tankModel.tankMaterial;
			}
		}

		public bool IsAlive()
		{
			if (tankModel.tankHealth <= 0)
				return false;
			return true;
		}

		public void MoveTank()
		{
			moveDirection.x = joystick.Horizontal;
			moveDirection.z = joystick.Vertical;
			tankView.GetRigidbody().velocity = moveDirection * tankModel.tankSpeed * Time.fixedDeltaTime;
			if(moveDirection != Vector3.zero)
				tankView.transform.forward = (moveDirection);
		}

	}
}