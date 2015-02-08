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
        string url;
        string prvsUrl;

        public void  connect(string newUrl)
        {
            prvsUrl = newUrl;
            url = newUrl;
            FtpWebRequest request = createRequest(url);
            getDirList(request);
            getResponse(request);
 
        }

        public void getResponse(FtpWebRequest  request)
        {
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());
        }

        public FtpWebRequest createRequest(string url)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential ("anonymous","kkaweler@gmail.com");
            return request;
        }

        public void getDirList(FtpWebRequest request)
        {
            Console.WriteLine("Folder and files in " + url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

        }
        public void moveToDir(string newUrl)
        {
            prvsUrl = url;
            url+= newUrl;
            FtpWebRequest request = createRequest(url);
            getDirList(request);
            getResponse(request);
        }

        public void moveBack()
        {
            url = prvsUrl;
            FtpWebRequest request = createRequest(url);
            getDirList(request);
            getResponse(request);
 
        }

        public void dowloadFile(string fileName)
        {
            FtpWebRequest request = createRequest(url+fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream file = File.Create(fileName);
            byte[] buffer = new byte[512 * 1024];
            int read;
            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                file.Write(buffer, 0, read);
            }
            file.Close();
            responseStream.Close();
            response.Close();
            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
        }
    }
}
