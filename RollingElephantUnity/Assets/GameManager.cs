using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { LEFT, RIGHT }
public class GameManager : Singleton<GameManager>
{
    public int baseTileCount;
    public Transform  elephantTransform;
    public LevelFrame leftFrame;
    public LevelFrame rightFrame;

    public void MoveFrame(GameObject triggeringFrame, GameObject targetFrame, DIRECTION direction)
    {
        float negative = (-Mathf.Pow(-1, ((float)((int)direction))));
        targetFrame.transform.position = triggeringFrame.transform.position + new Vector3(baseTileCount * negative, 0);
    }
}
