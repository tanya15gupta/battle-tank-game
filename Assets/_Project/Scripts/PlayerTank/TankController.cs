using UnityEngine;

namespace BattleTank
{
	public class TankController
	{
		TankModel tankModel;
		TankView tankView;
		public TankController(TankModel _tankModel, TankView _tankView)
		{
			tankModel = _tankModel;
			tankView = GameObject.Instantiate<TankView>(_tankView);
			tankView.SetController(this);
		}
	}
}