using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace COMMOM
{
    public class FileExtend
    {
        public static string FormatIconURL(string FilePath)
        {
            string strImage = "";
            string FileExtension = Path.GetExtension(FilePath);
            if (FileExtension == ".pdf")
                strImage = "/Images/icon_file/icon-pdf.png";
            else if (FileExtension == ".docx" || FileExtension == ".doc")
                strImage = "/Images/icon_file/icon-doc.png";
            else if (FileExtension == ".rar" || FileExtension == ".zip")
                strImage = "/Images/icon_file/rar.png";
            else if (FileExtension == ".xls" || FileExtension == ".xlsx")
                strImage = "/Images/icon_file/page_excel.png";
            else if (FileExtension == ".ppt" || FileExtension == ".pptx")
                strImage = "/Images/icon_file/file_ppt.png";
            return strImage;
        }

        public static void WriteFile(string strFileName)
        {
            System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;
            System.IO.Stream objStream = null;

            try
            {
                // Open the file.
                objStream = new System.IO.FileStream(strFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

                WriteStream(objResponse, objStream);
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                objResponse.Write("Error : " + ex.Message);
            }
            finally
            {
                if ((objStream == null) == false)
                {
                    // Close the file.
                    objStream.Close();
                }
            }
        }

        public static string GetContentType(string extension)
        {

            string contentType = null;

            switch (extension.ToLower())
            {
                case "txt":
                    contentType = "text/plain";
                    break;
                case "htm":
                case "html":
                    contentType = "text/html";
                    break;
                case "rtf":
                    contentType = "text/richtext";
                    break;
                case "jpg":
                case "jpeg":
                    contentType = "image/jpeg";
                    break;
                case "gif":
                    contentType = "image/gif";
                    break;
                case "bmp":
                    contentType = "image/bmp";
                    break;
                case "mpg":
                case "mpeg":
                    contentType = "video/mpeg";
                    break;
                case "avi":
                    contentType = "video/avi";
                    break;
                case "pdf":
                    contentType = "application/pdf";
                    break;
                case "doc":
                case "docx":
                case "dot":
                    contentType = "application/msword";
                    break;
                case "csv":
                case "xls":
                case "xlsx":
                case "xlt":
                    contentType = "application/x-msexcel";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            return contentType;

        }

        public static string ExtractFileName(string filename)
        {
            int i = 0;
            int iExtension = 0;
            int iEnd = 0;
            int iStart = 0;
            string s = filename;

            if (!filename.ToLower().StartsWith("http"))
            {
                iExtension = s.LastIndexOf(".");
                iEnd = iExtension - 1;
                i = iEnd;
                while (i > 0 & iStart == 0)
                {
                    if (s.Substring(i, 1) == ".")
                    {
                        iStart = i;
                    }
                    i -= 1;
                }
                if (iStart > 0)
                {
                    s = s.Substring(0, iStart) + s.Substring(iExtension);
                }
            }

            return s;

        }

        public static void DownloadFile(string FileLoc)
        {
            System.IO.FileInfo objFile = new System.IO.FileInfo(FileLoc);
            System.Web.HttpResponse objResponse = System.Web.HttpContext.Current.Response;
            string filename = ExtractFileName(objFile.Name);

            if (HttpContext.Current.Request.UserAgent.IndexOf("; MSIE ") > 0)
            {
                filename = HttpUtility.UrlEncode(filename);
            }
            if (objFile.Exists)
            {
                objResponse.ClearContent();
                objResponse.ClearHeaders();
                objResponse.AppendHeader("content-disposition", "attachment; filename=\"" + filename + "\"");
                objResponse.AppendHeader("Content-Length", objFile.Length.ToString());

                objResponse.ContentType = GetContentType(objFile.Extension.Replace(".", ""));

                WriteFile(objFile.FullName);

                objResponse.Flush();
                objResponse.End();
            }
        }

        private static void WriteStream(HttpResponse objResponse, Stream objStream)
        {
            // Buffer to read 10K bytes in chunk:
            byte[] bytBuffer = new byte[10001];

            // Length of the file:
            int intLength = 0;

            // Total bytes to read:
            long lngDataToRead = 0;

            try
            {
                // Total bytes to read:
                lngDataToRead = objStream.Length;

                //objResponse.ContentType = "application/octet-stream"

                // Read the bytes.
                while (lngDataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (objResponse.IsClientConnected)
                    {
                        // Read the data in buffer
                        intLength = objStream.Read(bytBuffer, 0, 10000);

                        // Write the data to the current output stream.
                        objResponse.OutputStream.Write(bytBuffer, 0, intLength);

                        // Flush the data to the HTML output.
                        objResponse.Flush();

                        bytBuffer = new byte[10001];
                        // Clear the buffer
                        lngDataToRead = lngDataToRead - intLength;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        lngDataToRead = -1;
                    }
                }

            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                objResponse.Write("Error : " + ex.Message);
            }
            finally
            {
                if ((objStream == null) == false)
                {
                    // Close the file.
                    objStream.Close();
                }
            }
        }
    }
}
