using UnityEngine;

namespace BattleTank
{
    public class TankModel 
    {
        public int tankSpeed { get; private set; }
        public TankTypes tankTypes { get; private set; }
        public TankModel(TankTypes _tankTypes, int _tankSpeed)
		{
            tankSpeed = _tankSpeed;
            tankTypes = _tankTypes;
		}
    }
}