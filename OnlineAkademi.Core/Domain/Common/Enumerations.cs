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
        Pdf,
        Video,
        Link
    }

    public enum TrainerType
    {
        [Display(Name = "Kurum İçi")]
        Inside =1,
        [Display(Name = "Kurum Dışı")]
        Outside =2
    }
}
