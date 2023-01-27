using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletsList", order = 3)]
	public class BulletList : ScriptableObject
	{
		public List<BulletSO> bulletsList = new List<BulletSO>();
	}
}
