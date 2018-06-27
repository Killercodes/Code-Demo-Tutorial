using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace HashingDemo
{
    class Program
    {
        const string FOLDER_PATH = @"C:\DemoTemp\HashingDemo\";
        const string FILE_PATH = FOLDER_PATH + "FileToHash.txt";

        static void Main(string[] args)
        {
            /*
             * Nonkeyed hashing algorithms
             * ===========================
             * MD5
             * RIPEMD160
             * SHA 1, 256, 384, 512
             * 
             * Keyed hashing algorithms
             * ========================
             * HMACSHA1
             * MACTripleDES
             */

            // Deleta any existing demo folder and create a new empty one
            if (Directory.Exists(FOLDER_PATH))
                Directory.Delete(FOLDER_PATH, true);
            Directory.CreateDirectory(FOLDER_PATH);

            // Create the file to hash/sign
            File.WriteAllText(FILE_PATH, "Hash me...");

            //DoNonKeyedHash();
            //DoKeyedHash();
            //DoDigitalsignature();
        }

        static void DoNonKeyedHash()
        {
            // Get the file to hash
            FileStream fs = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            
            // Create the hashing algorithm to use
            MD5 alg = new MD5CryptoServiceProvider();

            // Get the hash based on the content of the file
            alg.ComputeHash(fs);

            // Display the hash
            Console.WriteLine("Hash:{0}", Convert.ToBase64String(alg.Hash));

            fs.Close();
        }

        static void DoKeyedHash()
        {
            // Get the file to hash
            FileStream fs = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);

            // Password to generate the secret key from
            string password = "SecretPassword";

            // Generate a salt
            byte[] salt = Encoding.ASCII.GetBytes("SecretSalt");

            HMACSHA1 o = new HMACSHA1();

            // Create the key based on the secret and the salt
            byte[] key = new Rfc2898DeriveBytes(password, salt).GetBytes(16);
            
            // Create the hashing algorithm to use
            HMACSHA1 alg = new HMACSHA1(key);

            // Get the hash based on the content of the file
            alg.ComputeHash(fs);

            // Display the hash
            Console.WriteLine("Hash:{0}", Convert.ToBase64String(alg.Hash));

            fs.Close();
        }

        static void DoDigitalsignature()
        {
            // Get the file to sign
            FileStream fs = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);

            // Create the signer
            DSACryptoServiceProvider signer = new DSACryptoServiceProvider();
            byte[] signature = signer.SignData(fs);

            // Get the (auto generated) public key of the signer
            string publicKey = signer.ToXmlString(false);

            // Display the hash
            Console.WriteLine("Signature:{0}", Convert.ToBase64String(signature));

            fs.Close();

            // Create the verifier
            DSACryptoServiceProvider verifier = new DSACryptoServiceProvider();

            // Import the public key of the signer
            verifier.FromXmlString(publicKey);

            // Get the file to verify (must be read into a byte array)
            FileStream fs2 = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            byte[] inData2 = new BinaryReader(fs2).ReadBytes((int)fs2.Length);

            // Check so that the hash of the data mathes the signature
            // (after it has been decrypted using the signers public key)
            if (verifier.VerifyData(inData2, signature))
                Console.WriteLine("Signature verified");
            else
                Console.WriteLine("Signature NOT verified");

            fs2.Close();
        }
    }
}
