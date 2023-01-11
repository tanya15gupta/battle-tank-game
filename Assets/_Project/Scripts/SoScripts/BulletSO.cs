using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletScriptableObject", order = 4)]
    public class BulletSO : ScriptableObject
    {
        public float speed;
        public float damageDone;
        public int shotsFired;
    }
}
