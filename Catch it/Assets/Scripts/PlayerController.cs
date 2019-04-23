using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5, 18)]
    [SerializeField] float moveSpeed = 9f;

    private float xMin;
    private float xMax;
    private const float PADDING = 0.1f;

    private void Start()
    {
        SetCameraBoundToPlayer();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float deltaX = Input.GetAxis( "Horizontal" ) * ( moveSpeed * Time.deltaTime );
        var newPositionX = Mathf.Clamp( transform.position.x + deltaX, xMin, xMax );

        transform.position = new Vector2( newPositionX, transform.position.y );
    }

    private void SetCameraBoundToPlayer()
    {
        Camera camera = Camera.main;

        xMin = camera.ViewportToWorldPoint( new Vector3( 0, 0, 0 ) ).x + PADDING;
        xMax = camera.ViewportToWorldPoint( new Vector3( 1, 0, 0 ) ).x - PADDING;
    }
}
