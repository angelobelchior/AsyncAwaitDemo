namespace AsyncAwaitDemo.Demos;

public class Cancellation
{
    public static async Task Execute()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(5000);

        Console.WriteLine("Para cancelar pressione Enter/Return...");

        var task = Task.Run(() =>
        {
            for (var i = 0; i < 10; i++)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Operação cancelada.");
                    return;
                }

                // Simula alguma operação demorada
                Thread.Sleep(1000);
                Console.WriteLine($"Iteração {i + 1}");
            }

            Console.WriteLine("Operação concluída com êxito.");
        }, cancellationTokenSource.Token);

        Console.ReadLine();

        cancellationTokenSource.Cancel();

        await task;

        Console.ReadLine();
    }
}