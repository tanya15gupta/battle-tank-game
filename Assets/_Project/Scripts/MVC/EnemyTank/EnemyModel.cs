using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyModel : TankModel
    {
        public List<Transform> PatrolPoints { get; private set; }
        public float ChasingRadius { get; private set; }
        public float ShootingDistance { get; private set; }
        public float ShootCoolDown { get; private set; }
        public EnemyModel(TankScriptableObject _tankSO) : base(_tankSO)
		{
            PatrolPoints = _tankSO.CheckPoints;
            ChasingRadius = _tankSO.AIVisibilityRadius;
            ShootingDistance = _tankSO.AIShootingDistance;
            ShootCoolDown = _tankSO.ShootCoolDown;
		}

    }
}
