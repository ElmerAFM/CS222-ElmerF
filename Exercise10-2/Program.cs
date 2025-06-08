using System;

namespace Exercise02
{
  class Program
  {
    static void Main()
    {
      string inputPath = "input.xml";
      string outputPath = "protected_output.xml";

      ProtectXML.ProtectXml(inputPath, outputPath);
      Console.WriteLine("XML data protected and saved.");

      ProtectXML.DecryptAndDisplay(outputPath);
    }
  }
}