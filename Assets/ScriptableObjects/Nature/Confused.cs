using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Nature/Confused")]
public class Confused : Nature
{
	[Range (15,30)]
	public int m_Force;
	public bool m_FireEnable;
	public bool m_MoveEnable;

	public override void Act (MonoBehaviour tank)
	{
		if (m_FireEnable) {
			TankShooting tankShooting = tank.GetComponent<TankShooting> ();
			tankShooting.FireSmart (m_Force);
		}
		if (m_MoveEnable) {
		}
	}
}
