public class Challenge : SingletonMono<Challenge>
{
    public static bool IsCompleted;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }
}