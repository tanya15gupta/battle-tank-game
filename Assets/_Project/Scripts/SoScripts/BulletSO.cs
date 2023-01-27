using UnityEngine;

namespace BattleTank
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletScriptableObject", order = 4)]
	public class BulletSO : ScriptableObject
	{
		[SerializeField] private float speed;
		[SerializeField] private float damageDone;
		[SerializeField] private float lifeTime;
		[SerializeField] private int shotsFired;
		[SerializeField] private GameObject explosionParticalsEffect;
		public float Speed { get => speed; set => speed = value; }
		public float DamageDone { get => damageDone; set => damageDone = value; }
		public int ShotsFired { get => shotsFired; set => shotsFired = value; }
		public float BulletLifeTime { get => lifeTime; set => lifeTime = value; }
		public GameObject ExplosionParticalsEffect { get => explosionParticalsEffect; set => explosionParticalsEffect = value; }
	}
}