using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TankScriptableObject", order = 2)]
    public class TankScriptableObject : ScriptableObject
    {
        public string tankName = "";
        public TankTypes tankType;
        public float damageDealt;
        public float speed;
        public float health;
        public Color tankColour;
    }
}
