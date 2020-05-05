using UnityEngine;

public class CommandMove : Command {

    private Vector3 TransPos;

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
        avatar.Move(TransPos);
    }
    public override void undo(Avatar avatar)
    {
        avatar.Move(-TransPos);
        logInfo = "撤销：" + logInfo;
    }
}
