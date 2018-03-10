using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Nature/Scanner")]
public class Scanner : Nature
{
	public bool m_Fire;
	[Range (15,30)]
	public int m_Force;
	[Range (0.5f, 3f)]
	public float m_FireInterval;
	[Range (0.0f, 0.25f)]
	public float m_TurnInputValue;
	[Range (10f, 100f)]
	public float m_FwdDistance;
		
	public override void ActUpdate (MonoBehaviour tank)
	{
		if (m_Fire) {
			TankMovement tankMovement = tank.GetComponent<TankMovement> ();
			if (tankMovement.LockedOnTarget) {
				TankShooting tankShooting = tank.GetComponent<TankShooting> ();
				tankShooting.FireNature (m_Force, m_FireInterval);
			}
		}
	}

	public override void ActFixedUpdate (MonoBehaviour tank)
	{
		TankMovement tankMovement = tank.GetComponent<TankMovement> ();
		tankMovement.ScanNature (m_TurnInputValue, m_FwdDistance);
	}

}
