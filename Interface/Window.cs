class Window
{
    // The Name property represents the name of the window.
    public string Name { get; set; }

    // The BorderColor property represents the color of the window's border.
    public ConsoleColor BorderColor { get; set; }

    // The BackgroundColor property represents the color of the window's background.
    public ConsoleColor BackgroundColor { get; set; }

    // The TabSelectedColor property represents the color of the selected tab.
    public ConsoleColor TabSelectedColor { get; set; }

    // The Width property represents the width of the window.
    public int Width { get; set; }

    // The Height property represents the height of the window.
    public int Height { get; set; }

    // The Left property represents the left position of the window.
    public int Left { get; set; }

    // The Top property represents the top position of the window.
    public int Top { get; set; }

    // The Tabs property represents a list of tabs in the window.
    public List<Tab> Tabs { get; set; }

    // The SelectedTabIndex property represents the index of the currently selected tab.
    public int SelectedTabIndex { get; set; }

    // The ScrollPosition property represents the current scroll position of the tab's contents.
    public int ScrollPosition { get; set; }

    // The constructor initializes the Window object with the provided parameters.
    public Window(string name, int width, int height, int left, int top)
    {
        Name = name;
        BorderColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;
        TabSelectedColor = ConsoleColor.DarkCyan;
        Width = width;
        Height = height;
        Left = left;
        Top = top;
        Tabs = new List<Tab>();
        SelectedTabIndex = 0;
        ScrollPosition = 0;
    }

    // The Draw method is responsible for drawing the window on the console.
    public void Draw()
    {
        // Set the cursor position to the top-left corner of the window.
        Console.SetCursorPosition(Left, Top);

        // Set the background color and border color of the window.
        Console.BackgroundColor = BackgroundColor;
        Console.ForegroundColor = BorderColor;

        // Draw the top border of the window.
        Console.WriteLine("┌" + new string('─', Width - 2) + "┐");

        // Draw the vertical borders and empty spaces inside the window.
        for (int i = 1; i < Height - 1; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            Console.WriteLine("│" + new string(' ', Width - 2) + "│");
        }

        // Draw the bottom border of the window.
        Console.SetCursorPosition(Left, Top + Height - 1);
        Console.WriteLine("└" + new string('─', Width - 2) + "┘");

        // Set the cursor position to the top-left corner of the window's name.
        Console.SetCursorPosition(Left + 1, Top-1);
        Console.ForegroundColor = BorderColor;

        // Write the name of the window, padded to fit the width of the window.
        Console.Write(Name.PadRight(Width - 2));

        // Check if there are any tabs in the window.
        if (Tabs.Count > 0)
        {
            // Calculate the width of each tab based on the number of tabs and the width of the window.
            int tabWidth = (Width - 2) / Tabs.Count;

            // Iterate over each tab and draw it on the console.
            for (int i = 0; i < Tabs.Count; i++)
            {
                Console.SetCursorPosition(Left + 1 + i * tabWidth, Top + 1);

                // Check if the current tab is the selected tab.
                if (i == SelectedTabIndex)
                {
                    // Set the background color and text color for the selected tab.
                    Console.BackgroundColor = TabSelectedColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                // Write the name of the tab, padded to fit the tab width.
                Console.Write(" " + Tabs[i].Name.PadRight(tabWidth - 1) + " ");

                // Reset the console colors.
                Console.ResetColor();
            }

            // Set the cursor position to the content area of the window.
            Console.SetCursorPosition(Left + 2, Top + 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Content: ");

            // Iterate over the contents of the selected tab and draw them on the console.
            for (int i = 0; i < Math.Min(Height - 6, Tabs[SelectedTabIndex].Contents.Count - ScrollPosition); i++)
            {
                Console.SetCursorPosition(Left + 2, Top + 4 + i);
                object content = Tabs[SelectedTabIndex].Contents[i + ScrollPosition];

                // Check if the content is a string and write it on the console.
                if (content is string)
                {
                    Console.Write(((string)content).PadRight(Width - 4));
                }
            }
            foreach (var content in Tabs[SelectedTabIndex].Contents)
            {
                if (content is string)
                {
                    Console.WriteLine((string)content);
                }
                // 
            }
        }
    }

    // The ScrollContent method is responsible for scrolling the contents of the selected tab.
    public void ScrollContent(int scrollAmount)
    {
        // Check if there are any tabs in the window.
        if (Tabs.Count > 0)
        {
            // Calculate the maximum scroll position based on the number of contents in the selected tab.
            int maxScroll = Math.Max(0, Tabs[SelectedTabIndex].Contents.Count - (Height - 6));

            // Update the scroll position based on the scroll amount, ensuring it stays within the valid range.
            ScrollPosition = Math.Max(0, Math.Min(ScrollPosition + scrollAmount, maxScroll));
        }
    }

    // The SwitchTab method is responsible for switching to a new tab.
    public void SwitchTab(int newTabIndex)
    {
        // Check if the new tab index is within the valid range.
        if (newTabIndex >= 0 && newTabIndex < Tabs.Count)
            SelectedTabIndex = newTabIndex;
    }
    public void AddTabToAllTabs(Tab tabToAdd)
    {
        foreach (Tab tab in Tabs)
        {
            // Create a new sub-tab and add it to the Contents of the current tab
            tab.Contents.Add(new Tab(tabToAdd.Name, tabToAdd.Contents));
        }
    }

}
