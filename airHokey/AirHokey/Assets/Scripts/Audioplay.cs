using UnityEngine;

public class Audioplay : MonoBehaviour
{
public AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D coll){
	    source.Play();
    }

    void Update()
    {
        
    }
}
