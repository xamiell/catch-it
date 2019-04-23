using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField] GameJudge gameJudge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            gameJudge.DisminOpportunity();
        }

        Destroy( collision.gameObject );
    }
}
