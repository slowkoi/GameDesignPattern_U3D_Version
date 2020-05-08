function commandRotate(rotation, time)
    local rotationBefore
    local execute = function(avatar)
        rotationBefore = -rotation
        avatar.Rotate(rotation);
    end
    
    local undo = function(avatar)
        avatar.Rotate(rotationBefore);
    end
    return {execute = execute, undo = undo}
end

function update()
    mCallBackTime += Time.deltaTime;
    local cmd = InputHandler();
    if (cmd != null)
    {
        mCommandStack.Push(cmd);
        cmd.execute(TheAvatar);
    }
end

function InputHandler()
{
    if (Input.GetKey(KeyCode.W))
    {
        return  commandMove(new Vector3(0, 0, Time.deltaTime), mCallBackTime);
    }
    if (Input.GetKey(KeyCode.S))
    {
        return  commandMove(new Vector3(0, 0, -Time.deltaTime), mCallBackTime);
    }
    if (Input.GetKey(KeyCode.A))
    {
        return  commandMove(new Vector3(-Time.deltaTime, 0, 0), mCallBackTime);
    }
    if (Input.GetKey(KeyCode.D))
    {
        return  commandMove(new Vector3(Time.deltaTime, 0, 0), mCallBackTime);
    }
    if (Input.GetKey(KeyCode.Q))
    {
        return  commandRotate(new Vector3(0, -Time.deltaTime * 50, 0), mCallBackTime);
    }
    if (Input.GetKey(KeyCode.E))
    {
        return  commandRotate(new Vector3(0, Time.deltaTime * 50, 0), mCallBackTime);
    }
    return null;
}