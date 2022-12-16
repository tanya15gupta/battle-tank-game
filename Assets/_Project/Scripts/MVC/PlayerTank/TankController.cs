using UnityEngine;

namespace BattleTank
{
	public class TankController
	{
		private TankModel tankModel;
		private TankView tankView;
		public TankController(TankTypes _tankTypes, TankModel _tankModel, TankView _tankView)
		{
			tankModel = _tankModel;
			tankView = GameObject.Instantiate<TankView>(_tankView);
			tankView.SetController(this);
		}
	}
}