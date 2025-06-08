using System;
using System.Xml;

namespace Exercise02
{
  public static class ProtectXML
  {
    public static void ProtectXml(string inputPath, string outputPath)
    {
      XmlDocument doc = new();
      doc.Load(inputPath);

      foreach (XmlNode customer in doc.SelectNodes("//customer"))
      {
        var ccNode = customer["creditcard"];
        var pwNode = customer["password"];

        if (ccNode != null && pwNode != null)
        {
          string cc = ccNode.InnerText;
          ccNode.InnerText = CryptoUtils.Encrypt(cc);

          string pw = pwNode.InnerText;
          string salt = CryptoUtils.GenerateSalt();
          string hashed = CryptoUtils.HashWithSalt(pw, salt);
          pwNode.InnerText = $"{salt}:{hashed}";
        }
      }

      doc.Save(outputPath);
    }

    public static void DecryptAndDisplay(string xmlPath)
    {
      XmlDocument doc = new();
      doc.Load(xmlPath);

      foreach (XmlNode customer in doc.SelectNodes("//customer"))
      {
        var nameNode = customer["name"];
        var ccNode = customer["creditcard"];

        if (nameNode != null && ccNode != null)
        {
          string name = nameNode.InnerText;
          string encryptedCC = ccNode.InnerText;
          string decryptedCC = CryptoUtils.Decrypt(encryptedCC);

          Console.WriteLine($"Name: {name}");
          Console.WriteLine($"Decrypted Credit Card: {decryptedCC}");
          Console.WriteLine();
        }
      }
    }
  }
}
