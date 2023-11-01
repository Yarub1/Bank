using System;
using System.Collections.Generic;

// Define an interface for the banking application
interface IBankingApp
{
    void Run(); // Method for running the application
}

// Create the BankingApp class that implements the IBankingApp interface
//In the above code, i define the BankingApp class which implements the IBankingApp interface.
//The Run() method is the entry point for running the application. Inside this method, i set up the console window
//by setting the title, height, width, and encoding.
class BankingApp : IBankingApp
{
    // The entry point for running the application
    public void Run()
    {
        // Set up the console window and title
        Console.Title = "Banking App";
        Console.WindowHeight = 25;
        Console.WindowWidth = 150;
        Console.SetWindowSize(150, 25);
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //In the above code, i enter an infinite loop using while (true) to keep the application running.
        //Inside the loop, i calculate the optimal location for the user interface by determining
        //the window width, height, left position, and top position. Then, i create a Window object named bankWindow with the specified parameters.
        //I also create four Tab objects representing different options for the user interface: "Log in", "Create an account", "Exit", and "Help".
        //These tabs are added to the bankWindow object. Finally, i call the RunApplication() method to display the user interface.
        while (true)
        {
            Console.Clear();

            // Calculate the optimal location for the user interface
            //int windowWidth = 100;
            //int windowHeight = 25;
            //int left = (Console.WindowWidth - windowWidth) / 2;
            //int top = (Console.WindowHeight - windowHeight) / 2;

            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("\r\n\r\n\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2580\u2591\u2588\u2591\u2591\u2591\u2588\u2580\u2580\u2591\u2588\u2580\u2588\u2591\u2588\u2584\u2588\u2591\u2588\u2580\u2580\u2591\u2591\u2591\u2580\u2588\u2580\u2591\u2588\u2580\u2588\u2591\u2591\u2591\u2588\u2580\u2580\u2591\u2588\u2580\u2584\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2580\u2591\u2588\u2580\u2584\u2591\u2588\u2580\u2588\u2591\u2588\u2580\u2584\u2591\u2588\u2580\u2580\u2591\u2591\u2591\u2588\u2580\u2584\u2591\u2588\u2580\u2588\u2591\u2588\u2580\u2588\u2591\u2588\u2591\u2588\r\n\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2588\u2584\u2588\u2591\u2588\u2580\u2580\u2591\u2588\u2591\u2591\u2591\u2588\u2591\u2591\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2580\u2591\u2591\u2591\u2591\u2588\u2591\u2591\u2588\u2591\u2588\u2591\u2591\u2591\u2588\u2580\u2580\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2584\u2591\u2588\u2580\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2580\u2591\u2591\u2591\u2588\u2580\u2584\u2591\u2588\u2580\u2588\u2591\u2588\u2591\u2588\u2591\u2588\u2580\u2584\r\n\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2591\u2580\u2591\u2580\u2591\u2580\u2580\u2580\u2591\u2580\u2580\u2580\u2591\u2580\u2580\u2580\u2591\u2580\u2580\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2580\u2580\u2591\u2591\u2591\u2591\u2580\u2591\u2591\u2580\u2580\u2580\u2591\u2591\u2591\u2580\u2580\u2580\u2591\u2580\u2580\u2591\u2591\u2580\u2580\u2580\u2591\u2580\u2580\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2580\u2591\u2591\u2580\u2580\u2580\u2591\u2591\u2591\u2580\u2580\u2591\u2591\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2591\u2580\u2591\u2580\r\n\r\n");
            Console.ReadKey();

            Window bankWindow = new Window("Banking App", 85, 20, 19, 5);

            // Create tabs for the window

            Tab loginTab = new Tab("Log in", new List<object>());

            Tab createAccountTab = new Tab("Create an account", new List<object>());
            Tab helpTab = new Tab("        Exit", new List<object>());
            Tab exitTab = new Tab("        Help", new List<object>());


            // Add the tabs to the window
            bankWindow.Tabs.Add(loginTab);

            bankWindow.Tabs.Add(createAccountTab);
            bankWindow.Tabs.Add(exitTab);
            bankWindow.Tabs.Add(helpTab);

            // Display the user interface using the RunApplication method

            RunApplication(bankWindow);

        }
    }

    // Method to run the application logic for the user interface
    static void RunApplication(Window window)
    {
        //In the above code, i define the RunApplication() method which handles the application logic for the user interface.
        //Inside this method, i enter another loop to keep the user interface running.
        //i clear the console, draw the window, and adjust the content starting position.
        //Then, i read the user's key input and perform different actions based on the key pressed.
        //For example, if the right arrow key is pressed, i switch to the next tab.
        //If the enter key is pressed, i handle the selected tab accordingly.
        //For the "Log in" tab, i call the RunWithOtherUI() method to switch to a different user interface.
        //For the "Create an account" tab, i display a message indicating that the functionality is under construction.
        //For the "Exit" tab, i display a goodbye message and exit the application.
        //For the "Help" tab, i display a message indicating that the functionality is under construction.
        bool running = true;

        while (running)
        {
            Console.Clear();
            window.Draw();

            // Adjust the content starting position
            int contentTop = window.Top + 4;

            Console.SetCursorPosition(window.Left + 2, contentTop-1);
            Console.WriteLine("Welcome to Edugrade Bank");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    window.SwitchTab(window.SelectedTabIndex + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    window.SwitchTab(window.SelectedTabIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    window.ScrollContent(1);
                    break;
                case ConsoleKey.UpArrow:
                    window.ScrollContent(-1);
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
                case ConsoleKey.Enter:
                    switch (window.SelectedTabIndex)
                    {
                        case 0:
                            // Handle the "Log in" tab
                            UserAccountManager userManager = new UserAccountManager();
                            userManager.RunLogin();
                            RunWithOtherUI(); // Call a different user interface
                            continue; // Continue the loop
                        case 1:
                            // Handle the "Create an account" tab
                            Console.SetCursorPosition(window.Left + 2, contentTop + 2);
                            Console.WriteLine("Account creation functionality is under construction.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        case 2:
                            // Handle the "Exit" tab
                            Console.SetCursorPosition(window.Left + 2, contentTop + 2);
                            Console.WriteLine("Thank you for using the Banking App. Goodbye!");
                            Environment.Exit(0);
                            break;
                        case 3:
                            // Handle the "Help" tab
                            Console.SetCursorPosition(window.Left + 2, contentTop + 2);
                            Console.WriteLine("Help functionality is under construction.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                    }
                    break;
            }
        }
    }

    // Method to run a different user interface
    public static void RunWithOtherUI()
    {
        Window window = new Window("Banking System", 116, 20, 1, 5);

        // Add tabs to the different user interface
        window.Tabs.Add(new Tab("Accounts", new List<object>
        {
            "Account 1: $1000",
            "Account 2: $2500",
            "Account 3: $500"
        }));
        // Create a tab to add to existing tabs
        Tab additionalTab = new Tab("Additional Tab", new List<object>());

        // Add the additional tab to all existing tabs
        window.AddTabToAllTabs(additionalTab);

        window.Tabs.Add(new Tab("Transactions", new List<object>
        {
            "Transaction 1: Deposit $500 into Account 1",
            "Transaction 2: Withdraw $200 from Account 2"
        }));

        window.Tabs.Add(new Tab("Reports", new List<object>
        {
            "Account Summary Report",
            "Transaction History Report"
        }));

        RunApplication(window); // Run the application logic for the different UI
        bool running = true;
    }
}
