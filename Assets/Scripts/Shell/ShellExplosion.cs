using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;    
	public AudioEvent m_ExplosionAudioEvent;
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
		Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);
		for (int i = 0; i < colliders.Length; i++) {
////			Debug.Log ("ShellExposion: " + colliders.Length);
			Rigidbody targetRigidbody = colliders [i].GetComponent<Rigidbody> ();
			if (targetRigidbody)
				targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);
			float damage = CalculateDamage(colliders[i].transform.position);
			colliders [i].SendMessage ("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		m_ExplosionParticles.transform.parent = null;
		m_ExplosionParticles.Play ();
		m_ExplosionAudioEvent.Play (m_ExplosionAudio);		// m_ExplosionAudio.Play ();
		Destroy (m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
		Destroy (gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
		Vector3 explosionToTarget = targetPosition - transform.position;
		float explosionDistance = explosionToTarget.magnitude;
		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
		float damage = Mathf.Max(0f, relativeDistance * m_MaxDamage);
		return damage;

    }
}