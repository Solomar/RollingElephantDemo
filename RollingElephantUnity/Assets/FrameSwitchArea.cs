using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchArea : MonoBehaviour
{
    public DIRECTION direction;
    public GameObject targetFrame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.MoveFrame(gameObject, targetFrame, direction);
    }
}
