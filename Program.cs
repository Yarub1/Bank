using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Set the console window size and buffer size
        Console.WindowWidth = 120;
        Console.WindowHeight = 30;
        Console.BufferWidth = 120;
        Console.BufferHeight = 30;

        // Create an instance of the BankingApp class
        IBankingApp bankingApp = new BankingApp();

        // Run the banking app
        bankingApp.Run();

        // Set the running flag to true
        bool running = true;

        // Call the RunWithOtherUI method
        RunWithOtherUI();
    }

    static void RunApplication(Window window)
    {
        // Set the running flag to true
        bool running = true;

        // Run the application loop
        while (running)
        {
            // Clear the console
            Console.Clear();

            // Draw the window
            window.Draw();

            // Read a key from the console
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Handle the key press
            switch (keyInfo.Key)
            {
                // If the right arrow key is pressed, switch to the next tab
                case ConsoleKey.RightArrow:
                    window.SwitchTab(window.SelectedTabIndex + 1);
                    break;

                // If the left arrow key is pressed, switch to the previous tab
                case ConsoleKey.LeftArrow:
                    window.SwitchTab(window.SelectedTabIndex - 1);
                    break;

                // If the down arrow key is pressed, scroll the content down
                case ConsoleKey.DownArrow:
                    window.ScrollContent(1);
                    break;

                // If the up arrow key is pressed, scroll the content up
                case ConsoleKey.UpArrow:
                    window.ScrollContent(-1);
                    break;

                // If the escape key is pressed, exit the application loop
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }
    }

    public static void RunWithOtherUI()
    {


        // Create a new window with the title "Banking System" and dimensions 116x20
        Window window = new Window("Banking System", 116, 20, 1, 5);


        // Add a tab named "Accounts" with a list of account information
        window.Tabs.Add(new Tab("Accounts", new List<object>
        {
            "Account 1: $1000",
            "Account 2: $2500",
            "Account 3: $500"
        }));
        

        // Add a tab named "Transactions" with a list of transaction information
        window.Tabs.Add(new Tab("Transactions", new List<object>
        {
            "Transaction 1: Deposit $500 into Account 1",
            "Transaction 2: Withdraw $200 from Account 2"
        }));

        // Add a tab named "Reports" with a list of report names
        window.Tabs.Add(new Tab("Reports", new List<object>
        {
            "Account Summary Report",
            "Transaction History Report"
        }));

        // Run the application loop with the created window
        RunApplication(window);

        // Set the running flag to true
        bool running = true;
    }
}
