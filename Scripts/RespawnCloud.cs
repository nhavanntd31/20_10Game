using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCloud : MonoBehaviour
{
    public float respawnX;
    public float respawnY;
    public float respawnDelay;
    [SerializeField] private GameObject Effect;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            StartCoroutine(RespawnPlayerDelayed(other.gameObject));
            
        }
    }

    private IEnumerator RespawnPlayerDelayed(GameObject player)
    {
        // Disable player control and reset velocity
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Respawn();
            playerController.enabled = false;
        }

        // Wait for the specified delay
        yield return new WaitForSeconds(respawnDelay);

        // Create a new position using the specified coordinates
        Vector3 respawnPosition = new Vector3(respawnX, respawnY, 0f);

        // Set the player's position to the respawn position
        player.transform.position = respawnPosition;

        // Enable player control
        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}
