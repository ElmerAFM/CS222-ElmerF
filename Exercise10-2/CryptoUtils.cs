using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Exercise02
{
  public static class CryptoUtils
  {
    public static byte[]? AesKey { get; private set; }
    public static byte[]? AesIV { get; private set; }

    public static string Encrypt(string plainText)
    {
      using Aes aes = Aes.Create();
      aes.GenerateKey();
      aes.GenerateIV();
      AesKey = aes.Key;
      AesIV = aes.IV;

      ICryptoTransform encryptor = aes.CreateEncryptor(AesKey, AesIV);
      using MemoryStream ms = new();
      using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
      using StreamWriter sw = new(cs);
      sw.Write(plainText);
      sw.Close();
      return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
      if (AesKey == null || AesIV == null)
        throw new InvalidOperationException("AES key/IV not initialized.");

      byte[] bytes = Convert.FromBase64String(cipherText);
      using Aes aes = Aes.Create();
      ICryptoTransform decryptor = aes.CreateDecryptor(AesKey, AesIV);
      using MemoryStream ms = new(bytes);
      using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
      using StreamReader sr = new(cs);
      return sr.ReadToEnd();
    }


    public static string GenerateSalt()
    {
      byte[] saltBytes = new byte[16];
      using var rng = RandomNumberGenerator.Create();
      rng.GetBytes(saltBytes);
      return Convert.ToBase64String(saltBytes);
    }

    public static string HashWithSalt(string input, string salt)
    {
      byte[] combined = Encoding.UTF8.GetBytes(salt + input);
      using SHA256 sha = SHA256.Create();
      return Convert.ToBase64String(sha.ComputeHash(combined));
    }
  }
}
