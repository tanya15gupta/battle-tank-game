using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TankList", order = 1)]
	public class TankObjectsList : ScriptableObject
	{
		public List<TankScriptableObject> list = new List<TankScriptableObject>();
	}
}
