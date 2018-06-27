using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CryptographyDemo
{
    class Program
    {
        const string FOLDER_PATH = @"C:\DemoTemp\CryptographyDemo\";

        static void Main(string[] args)
        {
            /*
             * Symmetric (secret key) algorithms:
             * ==================================
             * RijindaelManaged
             * AesManaged
             * DES
             * Triple DES
             * RC2
             * 
             * Asymmetric (public key) algotithms
             * ==================================
             * RSA
             * DSA (digital signatures)
             */

            // Deleta any existing demo folder and create a new empty one
            if (Directory.Exists(FOLDER_PATH))
                Directory.Delete(FOLDER_PATH, true);
            Directory.CreateDirectory(FOLDER_PATH);

            // ======================
            // Symmetric cryptography
            // ======================
            GenerateSummetricKey();
            DoSymmetricEncryption();
            DoSymmetricDecryption();

            // =======================
            // Asymmetric cryptography
            // =======================
            GenerateAsummetricKey();
            DoAsymmetricEncryption();
            DoAsymmetricDecryption();
        }

        static SymmetricAlgorithm GenerateSummetricKey()
        {
            // Password to generate the secret key from
            string password = "SecretPassword";

            // Generate a salt
            byte[] salt = Encoding.ASCII.GetBytes("SecretSalt");

            // Create the key based on the secret and the salt
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);

            // The symmetric key algorithm to use
            SymmetricAlgorithm alg = new RijndaelManaged();
            
            // Set the key
            // * Must be set in bits instead of bytes
            // * Must be based on the algorithms key size
            alg.Key = key.GetBytes(alg.KeySize / 8);

            // Set the initialization vector
            // * Must be set in bits instead of bytes
            // * Must be based on the algorithms key size
            alg.IV = key.GetBytes(alg.BlockSize / 8);

            /*
             * The following must be shared by both the encryptor and decryptor:
             * The key
             * The IV (often derived from the key derived from the password and the salt)
             */

            return alg;
        }

        static void DoSymmetricEncryption()
        {
            string inPath = FOLDER_PATH + "OrgText.txt";
            string outPath = FOLDER_PATH + "Encrypted.enc";

            // Create the file to encrypt
            File.WriteAllText(inPath, "Encrypt me...");

            // Create in and out file
            FileStream inStream = new FileStream(inPath, FileMode.Open, FileAccess.Read);
            FileStream outStream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Read the original data
            byte[] inData = new byte[inStream.Length];
            inStream.Read(inData, 0, inData.Length);

            // Get the symmetric key algorithm to use (loaded with the secret key, salt and IV)
            SymmetricAlgorithm alg = GenerateSummetricKey();

            // Create the crypto stream
            CryptoStream cryptoStream =
                new CryptoStream(outStream, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write encrypted data using the crypto stream
            cryptoStream.Write(inData, 0, inData.Length);

            // close streams
            cryptoStream.Close();
            outStream.Close();
            inStream.Close();

            Console.WriteLine("File encrypted...");
        }

        static void DoSymmetricDecryption()
        {
            string inPath = FOLDER_PATH + "Encrypted.enc";
            string outPath = FOLDER_PATH + "Decrypted.txt";

            // Create in and out file
            FileStream inStream = new FileStream(inPath, FileMode.Open, FileAccess.Read);
            FileStream outStream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Read the encrypted data
            byte[] inData = new byte[inStream.Length];
            inStream.Read(inData, 0, inData.Length);

            // Get the symmetric key algorithm to use (loaded with the secret key, salt and IV)
            SymmetricAlgorithm alg = GenerateSummetricKey();

            // Create the crypto stream
            CryptoStream cryptoStream =
                new CryptoStream(outStream, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write decrypted data using the crypto stream
            cryptoStream.Write(inData, 0, inData.Length);

            // close streams
            cryptoStream.Close();
            outStream.Close();
            inStream.Close();

            Console.WriteLine("File decrypted: '{0}'", File.ReadAllText(outPath));
        }

        static void GenerateAsummetricKey()
        {
            // Create an empty key
            CspParameters persistantKey = new CspParameters();
            
            // specify the name
            persistantKey.KeyContainerName = "MyKeyPair";

            // Create a rsa service provider
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(persistantKey);
            
            // Save the key in the cryptoraphic service provider
            rsa.PersistKeyInCsp = true;

            // Get the key (not used here)
            RSAParameters key = rsa.ExportParameters(true);
        }

        static void DoAsymmetricEncryption()
        {
            string inPath = FOLDER_PATH + "OrgText.txt";
            string outPath = FOLDER_PATH + "Encrypted.enc";

            // Create the file to encrypt
            File.WriteAllText(inPath, "Encrypt me...");

            // Create in and out file
            FileStream inStream = new FileStream(inPath, FileMode.Open, FileAccess.Read);
            FileStream outStream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Read the original data
            byte[] inData = new byte[inStream.Length];
            inStream.Read(inData, 0, inData.Length);

            // Get the stored keys
            CspParameters persistantCsp = new CspParameters();
            persistantCsp.KeyContainerName = "MyKeyPair";

            // Encrypt data
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(persistantCsp);
            byte[] encryptedData = rsa.Encrypt(inData, false);

            // Write encrypted data to disk
            outStream.Write(encryptedData, 0, encryptedData.Length);

            // close streams
            outStream.Close();
            inStream.Close();

            Console.WriteLine("File encrypted...");
        }

        static void DoAsymmetricDecryption()
        {
            string inPath = FOLDER_PATH + "Encrypted.enc";
            string outPath = FOLDER_PATH + "Decrypted.txt";

            // Create in and out file
            FileStream inStream = new FileStream(inPath, FileMode.Open, FileAccess.Read);
            FileStream outStream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Read the encrypted data
            byte[] inData = new byte[inStream.Length];
            inStream.Read(inData, 0, inData.Length);

            // Get the stored keys
            CspParameters persistantCsp = new CspParameters();
            persistantCsp.KeyContainerName = "MyKeyPair";

            // Decrypt data
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(persistantCsp);
            byte[] decryptedData = rsa.Decrypt(inData, false);

            // Write decrypted data to disk
            outStream.Write(decryptedData, 0, decryptedData.Length);

            // close streams
            outStream.Close();
            inStream.Close();

            Console.WriteLine("File decrypted: '{0}'", File.ReadAllText(outPath));

        }
    }
}
