using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // Start is called before the first frame update
    public int count;
    public float speedRate;

    void Start()
    {
        count = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedRate * Time.deltaTime * -1f, 0,0);
        
    }
}
