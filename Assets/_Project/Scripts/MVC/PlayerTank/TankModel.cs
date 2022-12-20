using UnityEngine;

namespace BattleTank
{
    public class TankModel 
    {
        //public TankScriptableObject _tankSO;
        public float tankSpeed { get; private set; }
        public float tankHealth { get; private set; }
        public float damageDealt { get; private set; }
        public Color tankColour { get; private set; }
        public TankTypes tankTypes { get; private set; }
        public TankModel(TankScriptableObject _tankSO)
		{
			tankSpeed = _tankSO.speed;
			tankTypes = _tankSO.tankType;
			tankHealth = _tankSO.health;
			damageDealt = _tankSO.damageDealt;
            tankColour = _tankSO.tankColour;
		}
        
    }
}