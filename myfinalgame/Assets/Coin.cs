using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerMovement player = collision.gameObject.GetComponent<playerMovement>();
            player.score += 5;
            gameObject.SetActive(false);
        }
    }
}
