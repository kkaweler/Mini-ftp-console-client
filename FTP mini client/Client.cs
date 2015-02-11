using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FTP_mini_client
{
    class Client
    {
        protected string url;
        protected Stack prvsUrl = new Stack();

        public void  Connect(string newUrl)
        {
            url = newUrl;
            FtpWebRequest request = CreateRequest(url);
            GetDirList(request);
            GetResponse(request);
 
        }

        public void GetResponse(FtpWebRequest  request)
        {
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());
        }

        public FtpWebRequest CreateRequest(string url)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential ("anonymous","anonymous@gmail.com");
            return request;
        }

        public void GetDirList(FtpWebRequest request)
        {
            Console.WriteLine("Folder and files in " + url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

        }
        public void MoveToDir(string newUrl)
        {
            prvsUrl.Push(url);
            url+= newUrl;
            FtpWebRequest request = CreateRequest(url);
            GetDirList(request);
            GetResponse(request);
        }

        public void MoveBack()
        {
            url = prvsUrl.Pop;
            FtpWebRequest request = CreateRequest(url);
            GetDirList(request);
            GetResponse(request);
 
        }

        public void dowloadFile(string fileName)
        {
            FtpWebRequest request = CreateRequest(url+fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            /*FileStream file = File.Create(fileName);
            byte[] buffer = new byte[512 * 1024];
            int read;
            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                file.Write(buffer, 0, read);
            }*/
            using (FileStream file = new FileStream(name, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(reader.ReadToEnd());
                file.Write(array, 0, array.Length);
            }
            file.Close();
            responseStream.Close();
            response.Close();
            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
        }
    }
}
