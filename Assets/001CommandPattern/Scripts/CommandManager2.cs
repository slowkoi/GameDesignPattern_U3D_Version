using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager2 : MonoBehaviour
{

    public Avatar TheAvatar;

    private Stack<Command> mCommandStack;
    private float mCallBackTime;
    public bool IsRun = true;
    private CommandMove moveUp;
    private CommandMove moveDown;
    private CommandMove moveRight;
    private CommandMove moveLeft;
    private CommandRotate rotateLeft;
    private CommandRotate rotateRight;

    // Use this for initialization
    void Start()
    {
        mCommandStack = new Stack<Command>();
        mCallBackTime = 0;
        moveUp = new CommandMove(new Vector3(0, 0, Time.deltaTime), mCallBackTime);
        moveDown = new CommandMove(new Vector3(0, 0, -Time.deltaTime), mCallBackTime);
        moveRight = new CommandMove(new Vector3(Time.deltaTime, 0, 0), mCallBackTime);
        moveLeft = new CommandMove(new Vector3(-Time.deltaTime, 0, 0), mCallBackTime);
        rotateLeft = new CommandRotate(new Vector3(0, -Time.deltaTime * 50, 0), mCallBackTime);
        rotateRight = new CommandRotate(new Vector3(0, Time.deltaTime * 50, 0), mCallBackTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun)
        {
            Control();
        }
        else
        {
            RunCallBack();
        }

    }

    private void RunCallBack()
    {
        mCallBackTime -= Time.deltaTime;
        if (mCommandStack.Count > 0 )
        {
            Command cmd = mCommandStack.Pop();
            cmd.undo(TheAvatar);
            print(cmd.logInfo);
        }
    }

    private Command InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return moveUp;
        }
        if (Input.GetKey(KeyCode.S))
        {
            return moveDown;
        }
        if (Input.GetKey(KeyCode.A))
        {
            return moveLeft;
        }
        if (Input.GetKey(KeyCode.D))
        {
            return moveRight;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            return rotateLeft;
        }
        if (Input.GetKey(KeyCode.E))
        {
            return rotateRight;
        }
        return null;
    }

    private void Control()
    {
        mCallBackTime += Time.deltaTime;
        Command cmd = InputHandler();
        if (cmd != null)
        {
            mCommandStack.Push(cmd);
            cmd.execute(TheAvatar);
            print(cmd.logInfo);
        }
    }
}
