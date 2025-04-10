using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float bottomLimit = -3;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
