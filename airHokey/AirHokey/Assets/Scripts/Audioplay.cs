using UnityEngine;

public class CollisionSoundPlayer : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip collisionSoundClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D coll){
	    if (collisionSoundClip != null && audioSource != null){
		    audioSource.PlayOneShot(collisionSoundClip);
	    }else if (audioSource != null && audioSource.clip != null){
		    audioSource.Play();
	    }
    }
}
