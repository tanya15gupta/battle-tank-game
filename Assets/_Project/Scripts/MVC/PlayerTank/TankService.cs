using UnityEngine;

namespace BattleTank
{
	public class TankService : GenericSingleton<TankService>
	{
		[SerializeField] private TankView tankPrefab;
		[SerializeField] private FixedJoystick fixedJoystick;
		[SerializeField] private TankObjectsList tankSoList;
		private TankScriptableObject tankSO;
		private TankController tankController, tankController2, tankController3;
		
		private void Start()
		{
			tankController = new TankController(new TankModel(TankRandomizer()), tankPrefab, fixedJoystick);
			//tankController2 = new TankController(new TankModel(TankRandomizer()), tankPrefab, fixedJoystick);
			//tankController3 = new TankController(new TankModel(TankRandomizer()), tankPrefab, fixedJoystick);
		}
		private TankScriptableObject TankRandomizer()
		{
			int index = Random.Range(0, tankSoList.list.Count - 1);
			tankSO = tankSoList.list[index];
			Debug.Log("Index: " + index);
			return tankSO;
		}
	}
}