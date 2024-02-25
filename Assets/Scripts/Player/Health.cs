using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerHP;

    GameManager gameManager;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

    }
    IEnumerator Explode()
    {
        Destroy(gameObject);

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            playerHP -= 1;
            Debug.Log(playerHP);
            
            if (playerHP <= 0) 
            {
                gameManager.lose.Invoke();
                StartCoroutine(Explode());
            }
        }
    }


}