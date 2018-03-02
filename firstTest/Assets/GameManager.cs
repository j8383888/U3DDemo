public class GameManager
{ 
    //单例
    public static GameManager instance;
    //ui表现
    public UI GUIManager;

    public GameManager()
    {
        GUIManager = new UI();
    }

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }  
}
