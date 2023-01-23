using UnityEngine;

namespace BattleTank
{
    public class ShellExplosion : MonoBehaviour
    {
		public ParticleSystem shellExplosion;
		private float psDuration;
		private void Start()
		{
			shellExplosion = gameObject.GetComponent<ParticleSystem>();
			//psDuration = shellExplosion.main.duration;
		}
		private void OnCollisionEnter(Collision collision)
		{
			shellExplosion.Play();
		}

	}
}
