using System;

namespace CyberCopy
{
    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    //[Flags]
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}