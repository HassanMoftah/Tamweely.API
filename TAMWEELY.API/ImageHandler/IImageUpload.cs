using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAMWEELY.API.ImageHandler
{
    public interface IImageUpload
    {
        bool AddImage(HttpRequest request, int id);
        string GetFileExtention(HttpRequest request);
        void RemoveImage(string imagepath);
    }

}
