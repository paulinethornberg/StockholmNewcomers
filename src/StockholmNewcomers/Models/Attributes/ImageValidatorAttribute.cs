using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockholmNewcomers.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
     AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ImageValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = (IFormFile)value;

            bool result = true;

            if (file == null)
            {
                return result;
            }
            else
            {
                if ((file.ContentType.ToLower() != "image/jpg" &&
                        file.ContentType.ToLower() != "image/jpeg" &&
                        file.ContentType.ToLower() != "image/pjpeg" &&
                        file.ContentType.ToLower() != "image/gif" &&
                        file.ContentType.ToLower() != "image/x-png" &&
                        file.ContentType.ToLower() != "image/png")
                        && (
                            Path.GetExtension(file.FileName).ToLower() != ".jpg" &&
                            Path.GetExtension(file.FileName).ToLower() != ".png" &&
                            Path.GetExtension(file.FileName).ToLower() != ".gif" &&
                            Path.GetExtension(file.FileName).ToLower() != ".jpeg")
                   )
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }



        public override string FormatErrorMessage(string name)
        {
            return "The file must be uploaded in the right format";
        }
    }
}