using System;
class HTML_Dispatcher
{
    static void Main()
    {
        ElementBuilder div = new ElementBuilder("div");
        div.CloseTag(true);
        div.AddAttribute("id", "page");
        div.AddAttribute("class", "big");
        div.AddContent("<p>Hello</p>");
        Console.WriteLine(div * 3);
       
        Console.WriteLine(HTMLDispatcher.CreateImage("imageS.jpg", "test s", "selfi"));
        Console.WriteLine(HTMLDispatcher.CreateInput("submit", "Submit", "text"));
        Console.WriteLine(HTMLDispatcher.CreateURL("https://softuni.bg/", "www.softuni.bg", "softuni.bg"));
    }
}

