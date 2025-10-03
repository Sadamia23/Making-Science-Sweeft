namespace Task_9
{
    public class MatrixConsole
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private static bool isPrinting = true;
        private static readonly Random random = new Random();

        public static async Task Run()
        {
            Task printTask = PrintBinaryNumbers();
            Task messageTask = ShowPeriodicMessage();

            await Task.WhenAll(printTask, messageTask);
        }

        private static async Task PrintBinaryNumbers()
        {
            while (true)
            {
                await semaphore.WaitAsync();
                
                try
                {
                    if (isPrinting)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(random.Next(0, 2));
                        Console.ResetColor();
                    }
                }
                finally
                {
                    semaphore.Release();
                }

                await Task.Delay(10);
            }
        }

        private static async Task ShowPeriodicMessage()
        {
            const string message = "Neo, you are the chosen one";
            
            while (true)
            {
                await Task.Delay(5000);

                await semaphore.WaitAsync();
                
                try
                {
                    isPrinting = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    foreach (char c in message)
                    {
                        Console.Write(c);
                        await Task.Delay(50);
                    }
                    
                    Console.ResetColor();
                }
                finally
                {
                    semaphore.Release();
                }

                await Task.Delay(5000);

                await semaphore.WaitAsync();
                
                try
                {
                    isPrinting = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                }
                finally
                {
                    semaphore.Release();
                }
            }
        }
    }
}