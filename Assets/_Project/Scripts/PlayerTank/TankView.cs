using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        TankController tankController;
		public void SetController(TankController _tankController)
		{
			tankController = _tankController;
		}
	}
}