using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel;
using System.Data;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace HTTP
{
    class EnlaceHTTP
    {
        public static string POST = "POST";

        public Stream Transferir(
            string vars,
            string method,
            string domainName,
            string path
            )
        {
            return this.Transferir(vars, method, domainName, path, "ISO-8859-1", "application/x-www-form-urlencoded");
        }

        public Stream Transferir(
            string vars, 
            string method, 
            string domainName,
            string path,
            string charset, 
            string contentType)
        {
            if (method == POST)
            {
                HttpWebResponse webResp;
                Stream stream;
                HttpWebRequest webReq;
                byte[] buffer;
            
                buffer = Encoding.ASCII.GetBytes( vars );
            
                webReq = (HttpWebRequest)WebRequest.Create(String.Format("http://{0}/{1}", domainName, path));
                webReq.Method           = method;
                webReq.ContentType      = contentType;
                webReq.ContentLength    = buffer.Length;

                stream = webReq.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                webResp = (HttpWebResponse)webReq.GetResponse();
                return webResp.GetResponseStream();
            }
            else { // GET
            }
            return null;
        }
    }

    class Cifrado {

        private MD5 md5;

        public string MD5(string text) {
            Byte[] bytes;
            Byte[] hashedBytes;
            string hashed;

            md5 = new MD5CryptoServiceProvider();
            bytes = ASCIIEncoding.Default.GetBytes(text);
            hashedBytes = md5.ComputeHash(bytes);
            hashed = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashed;
        }

    }

}
