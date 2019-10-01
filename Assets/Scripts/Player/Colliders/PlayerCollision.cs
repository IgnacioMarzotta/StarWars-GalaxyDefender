using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    AudioSource source;
	PlayerController PController;
    PlayerHitbox PHitbox;

	public AudioClip[] DamageSounds;

    private void Awake()
    {
        PController = GetComponent<PlayerController>();
        PHitbox = GetComponent<PlayerHitbox>();        
        source = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
		source.clip = DamageSounds[Random.Range(0,DamageSounds.Length)];
    }

    void OnTriggerEnter(Collider col)
    {

		if (col.gameObject.tag.Equals("Collision"))
		{
			PController.health -= 10;
			source.PlayOneShot(source.clip);
            source.clip = DamageSounds[Random.Range(0, DamageSounds.Length)];
            PHitbox.LastHit = "collision with an object!";
        }

        if (col.gameObject.tag.Equals("ShotDetector"))
        {
            return;
        }

        if (col.gameObject.tag.Equals("Untagged"))
        {
            PController.health -= 10;
            source.PlayOneShot(source.clip);
            source.clip = DamageSounds[Random.Range(0, DamageSounds.Length)];
            PHitbox.LastHit = "collision with an object!";
        }
    }
}
