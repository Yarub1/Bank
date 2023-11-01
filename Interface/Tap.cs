public class Tab
{
    // The Name property represents the name of the tab.
    public string Name { get; set; }

    // The Contents property represents the contents of the tab.
    // It is a list of objects, allowing for flexibility in the type of content.
    public List<object> Contents { get; set; }

    // The constructor initializes the Name and Contents properties of the Tab class.
    // It takes two parameters: name (string) and contents (List<object>).
    public Tab(string name, List<object> contents)
    {
        // The 'this' keyword refers to the current instance of the class.
        // It is used here to assign the value of the 'name' parameter to the Name property.
        this.Name = name;

        // Similarly, the 'this' keyword is used to assign the value of the 'contents' parameter to the Contents property.
        this.Contents = contents;
    }
}