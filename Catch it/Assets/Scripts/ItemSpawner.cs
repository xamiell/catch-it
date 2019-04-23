using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Range(0.1f, 3f)]
    [SerializeField] float gravity = 0.5f;

    [Range(0.1f, 6f)]
    [SerializeField] float spawnFactorTime = 3f;

    [Range(0, 100)]
    [SerializeField] int maxFrameCount = 105;

    [SerializeField] GameObject itemObject;

    private int _frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        _frameCounter = default;
    }

    // Update is called once per frame
    void Update()
    {
        if (_frameCounter >= maxFrameCount)
        {
            InstantiateItem();
        }

        _frameCounter++;
    }

    private void InstantiateItem()
    {
        // This line need to be more specific for the actual screen size
        var itemPosition = new Vector2(Random.Range(-2.30f, 2.30f), transform.position.y);

        var item = Instantiate(itemObject, itemPosition, Quaternion.identity) as GameObject;
        item.GetComponent<Rigidbody2D>().gravityScale = gravity;

        _frameCounter = default;
    }
}
