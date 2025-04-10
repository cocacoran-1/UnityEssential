using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speed = 10.0f;
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
        transform.localScale = new Vector3(2,2,2);
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 0.4f, 0.1f, 0.2f);
        material.renderQueue = 3000;

    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, 0.0f);
    }
}
