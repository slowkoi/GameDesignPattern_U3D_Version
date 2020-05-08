using UnityEngine;

public class CommandMove : Command {

    private Vector3 TransPos;
    private Vector3 beforeTransPos;

    public CommandMove(Vector3 transPos, float time)
    {
        TransPos = transPos;
        _TheTime = time;
        if (transPos.x > 0){
            logInfo = "向右移动";
        }else if (transPos.x < 0){
            logInfo = "向左移动";
        }

        if (transPos.z > 0){
            logInfo = "向上移动";
        }else if (transPos.z < 0){
            logInfo = "向下移动";
        }
    }
    public override void execute(Avatar avatar)
    {
        beforeTransPos = -TransPos;
        avatar.Move(TransPos);
    }
    public override void undo(Avatar avatar)
    {
        avatar.Move(beforeTransPos);
        logInfo = "撤销：" + logInfo;
    }
}
