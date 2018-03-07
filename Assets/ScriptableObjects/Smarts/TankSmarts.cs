using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSmarts : MonoBehaviour {

	public Smarts m_Smartness;

	// Update is called once per frame
	void Update () {
		m_Smartness.Think (this);
	}
}
