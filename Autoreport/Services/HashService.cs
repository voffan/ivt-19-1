using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoreport.Database;
using Autoreport.Models;
using Autoreport.Services.Classes;

namespace Autoreport.Services
{
    public class HashService
    {
        public int iterations = 10000;
        public int hashSize = 128;
        public int saltSize = 64;
        private string salt;
        BouncyCastleHashing hasher;

        public HashService()
        {
            hasher = new BouncyCastleHashing();
        }

        public string GetSalt()
        {
            if (salt == null || salt == "")
            {
                Init();
            }

            return salt;
        }

        public string GetPasswordHash(string pwd)
        {
            return hasher.PBKDF2_SHA256_GetHash(pwd, GetSalt(), 
                iterations, hashSize);
        }

        public bool ValidatePasswordHash(string password, string hash)
        {
            return hasher.ValidatePassword(password, GetSalt(), iterations, hashSize, hash);
        }

        private void Init()
        {
            using (DataContext db = Connection.Connect())
            {
                List<HashSetting> hashSettingsList = db.HashSettings.ToList();
                HashSetting hashSetting;

                if (hashSettingsList.Count == 0)
                {
                    HashSetting _hashSetting = new HashSetting()
                    {
                        HashSize = hashSize,
                        Iterations = iterations,
                        SaltSize = saltSize,
                        Salt = Convert.ToBase64String(hasher.CreateSalt(saltSize))
                    };
                    salt = _hashSetting.Salt;
                    db.HashSettings.Add(_hashSetting);
                    db.SaveChanges();
                    return;
                } else
                {
                    hashSetting = hashSettingsList[0];
                }

                if (hashSetting.Salt == "")
                {
                    hashSetting.Salt = hasher.CreateSalt(hashSetting.SaltSize).ToString();
                }

                iterations = hashSetting.Iterations;
                hashSize = hashSetting.HashSize;
                salt = hashSetting.Salt;
            }
        }
    }
}
