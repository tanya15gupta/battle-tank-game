using UnityEngine;

namespace BattleTank
{
	public class TankService : GenericSingleton<TankService>
	{
		[SerializeField] private TankView tankPrefab;
		[SerializeField] private FixedJoystick fixedJoystick;
		[SerializeField] private TankObjectsList tankSoList;
		private TankScriptableObject tankSO;
		private TankController tankController;
		
		private void Start()
		{
			tankController = new TankController(new TankModel(TankRandomizer()), tankPrefab, fixedJoystick);
		}
		private TankScriptableObject TankRandomizer()
		{
			int index = Random.Range(0, tankSoList.list.Count );
			tankSO = tankSoList.list[index];
			Debug.Log("Index: " + index);
			return tankSO;
		}
	}
}