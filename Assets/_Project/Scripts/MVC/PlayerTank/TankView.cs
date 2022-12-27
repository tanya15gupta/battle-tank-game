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

		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}