using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Nature/Confused")]
public class Confused : Nature
{
	public bool m_FireEnable;
	[Range (15,30)]
	public int m_Force;
	[Range (0.5f, 3f)]
	public float m_FireInterval;

	public bool m_MoveEnable;
	[Range (0.0f, 0.25f)]
	public float m_MoveInputValue;
	[Range (0.0f, 0.25f)]
	public float m_TurnInputValue;
	[Range (0.5f, 2f)]
	public float m_TurnInterval;

	public override void ActUpdate (MonoBehaviour tank)
	{
		if (m_FireEnable) {
			TankShooting tankShooting = tank.GetComponent<TankShooting> ();
			tankShooting.FireNature (m_Force, m_FireInterval);
		}
	}

	public override void ActFixedUpdate (MonoBehaviour tank)
	{
		if (m_MoveEnable) {
			TankMovement tankMovement = tank.GetComponent<TankMovement> ();
			tankMovement.MoveNature (m_MoveInputValue);
			tankMovement.TurnNature (m_TurnInputValue, m_TurnInterval);
		}
	}

}
