using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSliderBody : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}
