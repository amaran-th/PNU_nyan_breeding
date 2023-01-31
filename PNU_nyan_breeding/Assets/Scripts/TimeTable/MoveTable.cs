using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTable : MonoBehaviour
{
    private float speed = 0.1f;
    Vector3 target = new Vector3(400.26f, 800, 0);
    public GameObject obj;
    private RectTransform trans;
    private float y;
    public FinishButton finishButton;

    public void Update()
    {   
        if (finishButton.flag) {
            transform.position = Vector3.MoveTowards(transform.position, target, 2f);
        }
    }
}
