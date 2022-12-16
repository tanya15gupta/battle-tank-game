using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
		public TankTypes tankTypes;
		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}