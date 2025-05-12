using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine("Type  Bytes  Min                             Max");

        WriteLine("sbyte  " + sizeof(sbyte) + "     " + sbyte.MinValue + "                          " + sbyte.MaxValue);
        WriteLine("byte   " + sizeof(byte) + "     " + byte.MinValue + "                             " + byte.MaxValue);
        WriteLine("short  " + sizeof(short) + "     " + short.MinValue + "                        " + short.MaxValue);
        WriteLine("ushort " + sizeof(ushort) + "     " + ushort.MinValue + "                             " + ushort.MaxValue);
        WriteLine("int    " + sizeof(int) + "     " + int.MinValue + "                 " + int.MaxValue);
        WriteLine("uint   " + sizeof(uint) + "     " + uint.MinValue + "                             " + uint.MaxValue);
        WriteLine("long   " + sizeof(long) + "     " + long.MinValue + "     " + long.MaxValue);
        WriteLine("ulong  " + sizeof(ulong) + "     " + ulong.MinValue + "                             " + ulong.MaxValue);
        WriteLine("float  " + sizeof(float) + "     " + float.MinValue + "                 " + float.MaxValue);
        WriteLine("double " + sizeof(double) + "     " + double.MinValue + "     " + double.MaxValue);
        WriteLine("decimal " + System.Runtime.InteropServices.Marshal.SizeOf(typeof(decimal)) + "     " + decimal.MinValue + "     " + decimal.MaxValue);
    }
}
