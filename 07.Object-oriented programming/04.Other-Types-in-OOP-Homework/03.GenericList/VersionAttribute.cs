using System;

[AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class |
    AttributeTargets.Interface |
    AttributeTargets.Enum |
    AttributeTargets.Method,
    AllowMultiple = true)]
class VersionAttribute : System.Attribute
{
    public VersionAttribute(double version)
    {
        this.Version = string.Format("{0:F2}", version);
    }
    public string Version { get; private set; }
}

