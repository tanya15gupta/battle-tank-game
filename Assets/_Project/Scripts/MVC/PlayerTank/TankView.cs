using UnityEngine;
namespace BattleTank
{
	public class TankView : GenericViewForTanks
	{
		private TankController tankController;

		private void Start()
		{
			TankService.instance.OnPlayerDeath += DestroyTank;
		}

		private void FixedUpdate()
		{
			tankController.MoveTank();
		}

		public override void DestroyTank()
		{
			tankController.PlayerDeath();
		}

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
		private void OnDisable()
		{
			TankService.instance.OnPlayerDeath -= DestroyTank;
		}
	}
}