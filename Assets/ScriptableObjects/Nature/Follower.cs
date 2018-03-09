using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Nature/Follower")]
public class Follower : Nature
{
	public bool m_Fire;
	[Range (15,30)]
	public int m_Force;
	[Range (0.5f, 3f)]
	public float m_FireInterval;
		
	public override void ActUpdate (MonoBehaviour tank)
	{
		if (m_Fire) {
			TankShooting tankShooting = tank.GetComponent<TankShooting> ();
			tankShooting.FireNature (m_Force, m_FireInterval);
		}
	}

	public override void ActFixedUpdate (MonoBehaviour tank)
	{
		TankMovement tankMovement = tank.GetComponent<TankMovement> ();
		tankMovement.NavAgentNature ();

	}

}
