using rpg;

Console.WriteLine("LOADING...");

Display display = new Display();
new Thread(
    () =>
    {
        while (true)
        {
            display.Render();
            Thread.Sleep(10);
        }
    }
    ).Start();
new Thread(
    () =>
    {
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                display.up();
            if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                display.down();
            if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                display.left();
            if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                display.right();
        }
    }
    ).Start();


