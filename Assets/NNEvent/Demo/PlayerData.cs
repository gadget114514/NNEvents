using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class PlayerData : NNEvents.NNEventData
	{
		public int AttackValue;
		public bool Dead;
	}

	public class EnemyData : NNEvents.NNEventData
	{
		public int AttackValue;
		public bool Dead;
	}