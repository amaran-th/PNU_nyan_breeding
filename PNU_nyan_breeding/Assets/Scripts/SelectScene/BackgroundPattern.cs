using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPattern : MonoBehaviour
{
    private new Renderer renderer;
    private float offsetX;
    private float offsetY;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        offsetX=0;
        offsetY=0;
        speed=0.01f;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetX = Time.time*(speed/2);
        offsetY = Time.time*speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetX,-offsetY));
    }
}
