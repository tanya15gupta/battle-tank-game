using UnityEngine;
using BattleTank.UI;
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
		private void Start()
		{
			tankController = new TankController(new TankModel(TankRandomizer()), tankPrefab, UIService.instance.GetJoystick(), this.gameObject.transform);
			virtualCamera.Follow = tankController.GetTankTransform();
		}

		public Transform PlayerPosition() => tankController.GetTankTransform();
		public Transform GetBulletTransform() => tankController.GetBulletSpawnTransform();
		private TankScriptableObject TankRandomizer()
		{
			int index = Random.Range(0, tankSoList.list.Count );
			tankSO = tankSoList.list[index];
			return tankSO;
		}
	}
}