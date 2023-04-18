using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace 框架
{
    public static class 加密解密
    {
        public static string 加密(string 文本, string 密钥)
        {
            if (文本.Length == 0) return string.Empty;
            if (密钥.Length != 8) throw new Exception("密钥长度必须为8位");

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(文本);

            des.Key = ASCIIEncoding.ASCII.GetBytes(密钥);
            des.IV = ASCIIEncoding.ASCII.GetBytes(密钥);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


        public static string 解密(string 文本, string 密钥)
        {
            if (文本.Length == 0) return string.Empty;
            if (密钥.Length != 8) throw new Exception("密钥长度必须为8位");
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[文本.Length / 2];
                for (int x = 0; x < 文本.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(文本.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(密钥);
                des.IV = ASCIIEncoding.ASCII.GetBytes(密钥);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }
    }
}
