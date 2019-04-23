using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameJudge gameJudge;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gameJudge.AddScore();
            DestroyGameObject(collision.gameObject);
        }
    }

    private void DestroyGameObject(GameObject gameObject) => Destroy(gameObject);
}
