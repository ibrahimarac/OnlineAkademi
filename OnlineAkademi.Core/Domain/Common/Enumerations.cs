using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineAkademi.Core.Domain.Common
{
    public enum RequestType
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }

    public enum JsonResponseStatus
    {
        Ok = 1,
        Error = 2
    }

    public enum JConfirmMessageType
    {
        Success,
        Error,
        Warning
    }

    public enum Gender
    {
        [Display(Name = "Erkek")]
        Male =1,
        [Display(Name = "Kadın")]
        Female =2
    }

    public enum MaterialType
    {
        [Display(Name = "Pdf Dosyası")]
        Pdf,
        [Display(Name ="Zip Dosyası")]
        Zip,
        [Display(Name ="Word Dosyası (doc)")]
        Doc,
        [Display(Name = "Word Dosyası (docx)")]
        Docx,
        [Display(Name = "Word Dosyası (xls)")]
        Xls,
        [Display(Name = "Word Dosyası (xlsx)")]
        Xlsx,
        [Display(Name = "Word Dosyası (ppt)")]
        Ppt,
        [Display(Name = "Word Dosyası (pptx)")]
        Pptx,
        [Display(Name = "Png Dosyası")]
        Png,
        [Display(Name = "Gif Dosyası")]
        Gif,
        [Display(Name = "Jpg Dosyası")]
        Jpg,
        [Display(Name = "Mp3 Dosyası")]
        Mp3,
        [Display(Name = "Mp4 Dosyası")]
        Mp4,
        [Display(Name = "Avi Dosyası")]
        Avi,
        [Display(Name = "Bağlantı Adresi")]
        Link,
        [Display(Name = "Metin Dosyası (txt)")]
        Text
    }

    public enum TrainerType
    {
        [Display(Name = "Kurum İçi")]
        Inside =1,
        [Display(Name = "Kurum Dışı")]
        Outside =2
    }
}
