using System;
using System.Collections.Generic;
public class ElementBuilder
{
    private string element;
    private string content;
    private Dictionary<string, string> attributes = new Dictionary<string, string>();
    private bool endTag = false;
    public ElementBuilder(string element)
    {
        this.element = element;
    }

    public void AddAttribute(string name, string value)
    {
        this.attributes.Add(name, value);
    }

    public void AddContent(string textContent)
    {
        this.content = textContent;
    }
    public static String operator *(ElementBuilder element, int n)
    {
        string result = "";
        for (int i = 0; i < n; i++)
        {
            result += element.ToString();
        }
        return result;
    }
    public void CloseTag(bool endTag)
    {
        this.endTag = endTag;
    }
    public override string ToString()
    {
        string allAtributes = "";

        foreach (var attribute in this.attributes)
        {
            allAtributes += " " + attribute.Key + "=\"" + attribute.Value + "\"";
        }
        string result;
        if (this.endTag)
        {
            result = String.Format("<{0}{1}/>", this.element, allAtributes);
        }
        else
        {
            result = String.Format("<{0}{1}>{2}</{0}>", this.element, allAtributes, this.content);
        }
        return result;
    }
}

