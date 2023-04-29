using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reposition : MonoBehaviour
{
    public UnityEvent onMove;


    private void LateUpdate()
    {
        if (transform.position.x > -10)
            return;

        //reuse - �׷� ������ �̵�
        transform.Translate(24, 0, 0, Space.Self);
        onMove.Invoke();
    }
}
