using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Direction
{
    NONE,
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class InputManager : MonoBehaviour
{
    public Direction curDirection;
    void OnUp()
    {
        curDirection = Direction.UP;
    }

    void OnDown()
    {
        curDirection = Direction.DOWN;
    }

    void OnLeft()
    {
        curDirection = Direction.LEFT;
    }

    void OnRight()
    {
        curDirection = Direction.RIGHT;
    }

    void LateUpdate()
    {
        //if (curDirection != Direction.NONE)
        //    print(curDirection);

        curDirection = Direction.NONE;
    }
}
