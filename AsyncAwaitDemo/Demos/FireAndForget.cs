namespace AsyncAwaitDemo.Demos;

public class FireAndForget
{
    public static async Task Go()
    {
        await Task.Delay(5000);
        Console.WriteLine("Executou a ação???");
    }
    
    public static async Task GoError()
    {
        await Task.Delay(2000);
        throw new ArgumentException("Deu erro???");
    }
    
    public static void GoDispose(Test test)
    {
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(5000);
                test.WriteHello();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
    }
    
    public static void GoSuccess()
    {
        _ = Task.Run(async () =>
        {
            Console.WriteLine("Fire and Forget");
            await Task.Delay(2000);
            
            Console.WriteLine("Error...");
            throw new Exception("Errooooor.....");

        }).ContinueWith(task =>
        {
            if(task.IsFaulted)
                Console.WriteLine(task.Exception?.Message);
        });
    }
}

public class Test : IDisposable
{
    private bool _disposed = false;
    private Hello? _hello = new Hello { Text = "Heloooooo"};
    
    public void WriteHello()
    {
        Console.WriteLine(_hello.Text);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _hello = null; // pra efeito de testes
            Console.WriteLine("Releasing managed resources.");
        }

        Console.WriteLine("Releasing unmanaged resources.");

        _disposed = true;
    }

    ~Test()
    {
        Dispose(false);
    }
}

public class Hello
{
    public string Text { get; set; }
}