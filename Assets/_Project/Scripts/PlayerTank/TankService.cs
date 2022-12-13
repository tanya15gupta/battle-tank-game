using UnityEngine;

namespace BattleTank
{
	public class TankService : GenericSingleton<TankService>
	{
		[SerializeField] TankView spawnTank;
		TankController tankController;

		protected override void Awake()
		{
			base.Awake();
		}

		private void Start()
		{
			SpawnTank();
		}

		private void SpawnTank()
		{
			tankController = new TankController(new TankModel(40), spawnTank);
		}
	}
}