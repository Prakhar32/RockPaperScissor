public enum Result
{
    WIN, LOSE, DRAW, INVALID
}

public class ResultContainer
{ 
    public Result Result;
    public string Message;

    private static ResultContainer instance;

    private ResultContainer() { }

    public static ResultContainer getInstance() { 
        if(instance == null)
            instance = new ResultContainer();
        return instance;
    }
}