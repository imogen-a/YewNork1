using UnityEngine;

public class AttackController : MonoBehaviour
{
    public AudioClip[] attackSounds; // Array to hold footstep sound clips
    public float minTimeBetweenAttacks = 0.33f; // Minimum time between footstep sounds
    public float maxTimeBetweenAttacks = 0.33f; // Maximum time between footstep sounds

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isAttacking = false; // Flag to track if the player is walking
    private float timeSinceLastAttack; // Time since the last footstep sound

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        // Check if the player is walking
        if (isAttacking)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastAttack >= Random.Range(minTimeBetweenAttacks, maxTimeBetweenAttacks))
            {
                // Play a random footstep sound from the array
                AudioClip attackSound = attackSounds[Random.Range(0, attackSounds.Length)];
                audioSource.PlayOneShot(attackSound);

                timeSinceLastAttack = Time.time; // Update the time since the last footstep sound
            }
        }
    }

    // Call this method when the player starts walking
    public void StartAttacking()
    {
        isAttacking = true;
    }

    // Call this method when the player stops walking
    public void StopAttacking()
    {
        isAttacking = false;
    }
}