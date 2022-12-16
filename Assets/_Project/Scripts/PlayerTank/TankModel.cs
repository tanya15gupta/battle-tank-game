using UnityEngine;

namespace BattleTank
{
    public class TankModel 
    {
        public int tankSpeed { get; private set; }
        public TankModel(int _tankSpeed)
		{
            tankSpeed = _tankSpeed;
		}
    }
}