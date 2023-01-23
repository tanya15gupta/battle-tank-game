using System;
using UnityEngine;
using Cinemachine;
namespace BattleTank
{
	public class TankService : GenericSingleton<TankService>
	{
		[SerializeField] private TankView tankPrefab;
		[SerializeField] private TankObjectsList tankSoList;
		[SerializeField] private CinemachineVirtualCamera virtualCamera;
		private TankScriptableObject tankSO;
		private TankController tankController;
		public Action OnPlayerDeath;
		private void Start()
		{
			tankController = new TankController(new TankModel(TankRandomizer()), tankPrefab, this.gameObject.transform);
		}
		public void SetVirtualCamera(Transform _follow)
		{
			virtualCamera.Follow = _follow;
		}
		public Vector3 PlayerPosition() => tankController.GetTankTransform();
		public Transform GetBulletTransform() => tankController.GetBulletSpawnTransform();
		private TankScriptableObject TankRandomizer()
		{
			int index = UnityEngine.Random.Range(0, tankSoList.list.Count );
			tankSO = tankSoList.list[index];
			return tankSO;
		}
	}
}