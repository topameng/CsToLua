using System;
using System.Collections;

public struct ToLua_System_Enum
{
    public static bool operator == (ToLua_System_Enum lhs, ToLua_System_Enum rhs)
    {
        return false;
    }

    public static bool operator !=(ToLua_System_Enum lhs, ToLua_System_Enum rhs)
    {
        return false;
    }

    public override bool Equals(object other)
    {
        return false;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
