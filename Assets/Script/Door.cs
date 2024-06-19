using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform targetPosition; // The target position to teleport the player to

    public bool playerInRange = false;
    public GameObject interactButton; // Reference to the interact button icon

    private void Start()
    {
        if (interactButton != null)
        {
            interactButton.SetActive(false); // Ensure the interact button is hidden at the start
        }
    }

    private void Update()
    {
        // Check if the player is in range and presses the "F" key
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactButton != null)
            {
                interactButton.SetActive(true); // Show the interact button
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactButton != null)
            {
                interactButton.SetActive(false); // Hide the interact button
            }
        }
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && targetPosition != null)
        {
            player.transform.position = targetPosition.position;
        }
    }
}
