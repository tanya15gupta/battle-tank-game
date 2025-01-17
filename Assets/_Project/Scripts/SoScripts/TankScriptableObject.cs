using UnityEngine;
using System.Collections.Generic;

namespace BattleTank
{
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TankScriptableObject", order = 2)]
	public class TankScriptableObject : ScriptableObject
	{
		[SerializeField] private string tankName;
		[SerializeField] private float damageDealt;
		[SerializeField] private float speed;
		[SerializeField] private float health;
		[SerializeField] private Material tankMaterial;
		[SerializeField] private TankTypes tankType;
		[SerializeField] private float aIShootingDistance;
		[SerializeField] private float aIVisibilityRadius;
		[SerializeField] private List<Transform> checkPoints = new List<Transform>();
		[SerializeField] private float shootCoolDown;
		public string TankName { get => tankName; set => tankName = value; }
		public float DamageDealt { get => damageDealt; set => damageDealt = value; }
		public float Speed { get => speed; set => speed = value; }
		public float Health { get => health; set => health = value; }
		public float AIShootingDistance { get => aIShootingDistance; set => aIShootingDistance = value; }
		public float AIVisibilityRadius { get => aIVisibilityRadius; set => aIVisibilityRadius = value; }
		public Material TankMaterial { get => tankMaterial; set => tankMaterial = value; }
		public TankTypes TankType { get => tankType; set => tankType = value; }
		public List<Transform> CheckPoints { get => checkPoints; set => checkPoints = value; }
		public float ShootCoolDown { get => shootCoolDown; set => shootCoolDown = value; }

	}
}