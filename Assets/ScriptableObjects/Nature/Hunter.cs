using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Nature/Hunter")]
public class Hunter : Nature
{
	
	public override void ActUpdate (MonoBehaviour tank)
	{
	}

	public override void ActFixedUpdate (MonoBehaviour tank)
	{
		TankMovement tankMovement = tank.GetComponent<TankMovement> ();
		tankMovement.NavAgentNature ();

	}

}
