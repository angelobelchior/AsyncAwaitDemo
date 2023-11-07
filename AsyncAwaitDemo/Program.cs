
namespace AsyncAwaitDemo;

public static class Program
{
    public static async Task Main()
    {
        #region StateMachine
        //await Demos.StateMachine.ExecuteBlogService();
        //await Demos.StateMachine.ExecuteBlogServiceStatemachine();
        #endregion StateMachine
        
        #region Deadlock
        //await Demos.DeadLock.Execute();
        #endregion Deadlock
        
        #region FireAndForget
        //_ = Demos.FireAndForget.Go();
        //_ = Demos.FireAndForget.GoError();
        // using (var test = new Demos.Test())
        // {
        //     Demos.FireAndForget.GoDispose(test);
        // }
        //Demos.FireAndForget.GoSuccess();
        #endregion FireAndForget
        
        #region Cancelation Token
        //await Demos.Cancellation.Execute();
        #endregion Cancelation Token
        
        Console.WriteLine("Fimmmmmmmmm");
        Console.ReadLine();
    }
}
