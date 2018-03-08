using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankNature : MonoBehaviour {

	public Nature m_Nature;

	// Update is called once per frame
	void Update () {
		m_Nature.ActUpdate (this);
	}

	void FixedUpdate () {
		m_Nature.ActFixedUpdate (this);
	}

}
