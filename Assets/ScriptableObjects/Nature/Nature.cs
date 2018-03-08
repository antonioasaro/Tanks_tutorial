using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Nature : ScriptableObject {

	public abstract void ActUpdate (MonoBehaviour tank);
	public abstract void ActFixedUpdate (MonoBehaviour tank);

}
