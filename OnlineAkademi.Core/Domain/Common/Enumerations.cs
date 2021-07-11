using System;
using System.Collections.Generic;
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
        Male,
        Female
    }

    public enum MaterialType
    {
        Pdf,
        Video,
        Link
    }

    public enum TrainerType
    {
        Inside,
        Outside
    }
}
