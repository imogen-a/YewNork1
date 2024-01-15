using UnityEngine;

public class YewNorkController : MonoBehaviour
{
    public AudioClip[] yewNorkSounds; // Array to hold footstep sound clips
    public float minTimeBetweenYewNorks = 1.5f; // Minimum time between footstep sounds
    public float maxTimeBetweenYewNorks = 1.5f; // Maximum time between footstep sounds

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isYewNorking = false; // Flag to track if the player is walking
    private float timeSinceLastYewNork; // Time since the last footstep sound
    private AudioClip yewNorkSound;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        // Check if the player is walking
        if (isYewNorking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastYewNork >= Random.Range(minTimeBetweenYewNorks, maxTimeBetweenYewNorks))
            {
                // Play a random footstep sound from the array
                yewNorkSound = yewNorkSounds[Random.Range(0, yewNorkSounds.Length)];
                audioSource.PlayOneShot(yewNorkSound);

                timeSinceLastYewNork = Time.time; // Update the time since the last footstep sound
            }
        }
    }

    // Call this method when the player starts walking
    public void StartYewNorking()
    {
        isYewNorking = true;
    }

    // Call this method when the player stops walking
    public void StopYewNorking()
    {
        isYewNorking = false;
    }
}