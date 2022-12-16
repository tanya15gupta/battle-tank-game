using UnityEngine;

namespace BattleTank
{
	public class TankService : GenericSingleton<TankService>
	{
		[SerializeField] private TankView spawnTank;
		[SerializeField] private int setTankSpeed = 40;
		private TankController tankController;

		private void Start()
		{
			SpawnTank();
		}

		private void SpawnTank()
		{
			tankController = new TankController(spawnTank.tankTypes, new TankModel(spawnTank.tankTypes, setTankSpeed), spawnTank);
		}
	}
}