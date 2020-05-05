using UnityEngine;

public class CommandRotate : Command {

    private Vector3 Rotation;

    public CommandRotate(Vector3 rotation, float time)
    {
        Rotation = rotation;
        _TheTime = time;
        if (rotation.y > 0){
            logInfo = "向右旋转";
        }else if (rotation.y < 0){
            logInfo = "向左旋转";
        }
    }
    public override void execute(Avatar avatar)
    {
        avatar.Rotate(Rotation);
    }
    public override void undo(Avatar avatar)
    {
        avatar.Rotate(-Rotation);
        logInfo = "撤销：" + logInfo;
    }
}
