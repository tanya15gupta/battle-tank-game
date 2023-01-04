using UnityEngine;
namespace BattleTank
{
	public class TankView : GenericViewForTanks
	{
		private TankController tankController;
		
		private void FixedUpdate()
		{
			tankController.MoveTank();
		}

		public void PlayerGotHit()
		{
			tankController.PlayerHit();
		}

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}