using UnityEngine;

public class SprayController : MonoBehaviour
{
    public AudioClip[] spraySounds; // Array to hold footstep sound clips
    public float minTimeBetweenSprays = 0.15f; // Minimum time between footstep sounds
    public float maxTimeBetweenSprays = 0.3f; // Maximum time between footstep sounds

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isSpraying = false; // Flag to track if the player is walking
    private float timeSinceLastSpray; // Time since the last footstep sound

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        // Check if the player is walking
        if (isSpraying)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastSpray >= Random.Range(minTimeBetweenSprays, maxTimeBetweenSprays))
            {
                // Play a random footstep sound from the array
                AudioClip spraySound = spraySounds[Random.Range(0, spraySounds.Length)];
                audioSource.PlayOneShot(spraySound);

                timeSinceLastSpray = Time.time; // Update the time since the last footstep sound
            }
        }
    }

    // Call this method when the player starts walking
    public void StartSpraying()
    {
        isSpraying = true;
    }

    // Call this method when the player stops walking
    public void StopSpraying()
    {
        isSpraying = false;
    }
}