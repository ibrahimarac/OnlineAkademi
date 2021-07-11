using OnlineAkademi.Core.Domain.Common;
using OnlineAkademi.Utils.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Extensions
{
    public static class ControllerExtensions
    {

        public static IActionResult ShowMessage(this IActionResult actionResult, 
            JConfirmMessageType messageType, 
            string title,
            string content)
        {
            IHttpContextAccessor contextAccessor;
            ITempDataDictionaryFactory tempDataFactory;

            contextAccessor = ServiceActivator.GetService<IHttpContextAccessor>();
            tempDataFactory = ServiceActivator.GetService<ITempDataDictionaryFactory>();

            var tempData = tempDataFactory.GetTempData(contextAccessor.HttpContext);

            var items=contextAccessor.HttpContext.Items;

            var tempDataKeyName = Constants.TempData.SuccessKey;

            switch (messageType)
            {
                case JConfirmMessageType.Error:
                    tempDataKeyName = Constants.TempData.ErrorKey;
                    break;
                case JConfirmMessageType.Warning:
                    tempDataKeyName = Constants.TempData.WarningKey;
                    break;
            }

            tempData[tempDataKeyName] = content;
            tempData[Constants.TempData.TitleKey] = title;

            return actionResult;
        }
    }
}
