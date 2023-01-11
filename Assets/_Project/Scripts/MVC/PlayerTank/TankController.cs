using System.Collections;
using UnityEngine;
using BattleTank.UI;

namespace BattleTank
{
	public class TankController
	{
		private TankModel tankModel;
		private TankView tankView;
		private Vector3 moveDirection;
		private Transform tankSpawnPoint;

		public TankController(TankModel _tankModel, TankView _tankView, Transform _spawnPoint)
		{
			tankModel = _tankModel;
			tankSpawnPoint = _spawnPoint;
			tankView = GameObject.Instantiate<TankView>(_tankView, tankSpawnPoint);
			ChangeTankColour();
			moveDirection = Vector3.zero;
			tankView.SetController(this);
		}
		public Vector3 GetTankTransform() => tankView.transform.position;
		public Transform GetBulletSpawnTransform() => tankView.GetBulletSpawnPoint();
		private void ChangeTankColour()
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
			moveDirection.x = UIService.instance.GetJoystickHorizontal();
			moveDirection.z = UIService.instance.GetJoystickVertical();
			tankView.GetRigidbody().velocity = moveDirection * tankModel.tankSpeed * Time.fixedDeltaTime;
			if(moveDirection != Vector3.zero)
				tankView.transform.forward = (moveDirection);
		}

		public void PlayerHit()
		{
			DestroyScene.instance.SceneDestruction(tankView.gameObject);
			//Object.Destroy(tankView.gameObject);
		}
	}
}