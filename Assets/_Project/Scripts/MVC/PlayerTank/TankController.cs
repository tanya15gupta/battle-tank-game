using System.Collections;
using UnityEngine;
using BattleTank.UI;

namespace BattleTank
{
	public class TankController
	{
		private TankModel tankModel;
		private TankView tankPrefab;
		private Vector3 moveDirection;
		private Transform tankSpawnPoint;

		public TankController(TankModel _tankModel, TankView _tankView, Transform _spawnPoint)
		{
			tankModel = _tankModel;
			tankSpawnPoint = _spawnPoint;
			tankPrefab = GameObject.Instantiate<TankView>(_tankView, tankSpawnPoint);
			ChangeTankColour();
			moveDirection = Vector3.zero;
			tankPrefab.SetController(this);
			TankService.instance.SetVirtualCamera(tankPrefab.transform);
		}
		public Vector3 GetTankTransform()
		{
			if (tankPrefab == null)
				return Vector3.positiveInfinity;
			return tankPrefab.transform.position;
		}
		public Transform GetBulletSpawnTransform() => tankPrefab.GetBulletSpawnPoint();
		private void ChangeTankColour()
		{
			for(int i = 0; i < tankPrefab.GetTankBody().childCount; i++)
			{
				tankPrefab.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = tankModel.tankMaterial;
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
			moveDirection.x = UIService.instance.GetJoystickHorizontal();
			moveDirection.z = UIService.instance.GetJoystickVertical();
			tankPrefab.GetRigidbody().velocity = moveDirection * tankModel.tankSpeed * Time.fixedDeltaTime;
			if(moveDirection != Vector3.zero)
				tankPrefab.transform.forward = (moveDirection);
		}

		public void PlayerDeath()
		{
			Object.Destroy(tankPrefab.gameObject);
		}
	}
}