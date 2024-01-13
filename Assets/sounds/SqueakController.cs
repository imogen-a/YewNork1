using UnityEngine;

public class SqueakController : MonoBehaviour
{
    public AudioClip[] squeakSounds; // Array to hold footstep sound clips
    public float minTimeBetweenSqueaks = 0.15f; // Minimum time between footstep sounds
    public float maxTimeBetweenSqueaks = 0.3f; // Maximum time between footstep sounds

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isSqueaking = false; // Flag to track if the player is walking
    private float timeSinceLastSqueak; // Time since the last footstep sound

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        // Check if the player is walking
        if (isSqueaking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastSqueak >= Random.Range(minTimeBetweenSqueaks, maxTimeBetweenSqueaks))
            {
                // Play a random footstep sound from the array
                AudioClip squeakSound = squeakSounds[Random.Range(0, squeakSounds.Length)];
                audioSource.PlayOneShot(squeakSound);

                timeSinceLastSqueak = Time.time; // Update the time since the last footstep sound
            }
        }
    }

    // Call this method when the player starts walking
    public void StartSqueaking()
    {
        isSqueaking = true;
    }

    // Call this method when the player stops walking
    public void StopSqueaking()
    {
        isSqueaking = false;
    }
}