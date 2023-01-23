using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private GameObject ps;
		[SerializeField] private GameObject psSpawn;
        private ParticleSystem psFx;
		private void Start()
		{
			psSpawn = Instantiate(ps);
			psFx = psSpawn.GetComponent<ParticleSystem>();
		}
		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				if (!psFx.isPlaying)
					psFx.Play();
				else
					psFx.Stop();
			}
		}
	}
}
