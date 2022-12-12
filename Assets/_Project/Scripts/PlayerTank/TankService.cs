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
			for(int i = 0; i < 5; i++)
			{
				SpawnTank();
			}
		}

		private void SpawnTank()
		{
			tankController = new TankController(new TankModel(40), spawnTank);
		}
	}
}