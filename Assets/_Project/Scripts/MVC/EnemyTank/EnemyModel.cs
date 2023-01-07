using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyModel : TankModel
    {
        public List<Transform> PatrolPoints { get; private set; }

        public EnemyModel(TankScriptableObject _tankSO) : base(_tankSO)
		{
            PatrolPoints = _tankSO.CheckPoints;
		}

    }
}
