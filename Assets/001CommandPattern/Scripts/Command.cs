public abstract class Command {

    protected float _TheTime;
    public string logInfo;
    public float TheTime
    {
        get { return _TheTime; }
    }
    public virtual void execute(Avatar avatar) { }
    public virtual void undo(Avatar avatar) { }
}
