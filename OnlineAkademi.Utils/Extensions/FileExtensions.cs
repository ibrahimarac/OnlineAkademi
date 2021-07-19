using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineAkademi.Utils.Extensions
{
    public static class FileExtensions
    {
        public static string GetContentTypeFromFileName(this MaterialType type)
        {
            if (type == MaterialType.Pdf)
                return "application/pdf";
            else if (type==MaterialType.Zip)
            {
                return "application/zip";
            }
            else if (type == MaterialType.Doc)
            {
                return "application/msword";
            }
            else if (type==MaterialType.Docx)
            {
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            else if (type == MaterialType.Ppt)
            {
                return "application/vnd.ms-powerpoint";
            }
            else if (type == MaterialType.Pptx)
            {
                return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            }
            else if (type == MaterialType.Xls)
            {
                return "application/vnd.ms-excel";
            }
            else if (type == MaterialType.Xlsx)
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
            else if (type == MaterialType.Png)
            {
                return "image/png";
            }
            else if (type == MaterialType.Gif)
            {
                return "image/gif";
            }
            else if (type == MaterialType.Jpg)
            {
                return "image/jpeg";
            }
            else if (type == MaterialType.Mp3)
            {
                return "audio/mpeg";
            }
            else if (type == MaterialType.Mp4)
            {
                return "video/mp4";
            }
            else if (type == MaterialType.Avi)
            {
                return "video/x-msvideo";
            }
            else if(type==MaterialType.Text)
                return "text/plain";

            return "";
        }
    }
}
