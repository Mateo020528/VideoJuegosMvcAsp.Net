//Agregamos los datos de la carpeta providers:
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CrudJuegos.Providers
{
    public enum Folders
    {
        Uploads = 0, Images = 1, Documents = 2, Temp = 3
    }

    public class PathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public PathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            //Esto es de manera de decirle al sistema en donde se guardaran los archivos que la persona va a descargar
            string carpeta = "";

            if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Images)
            {
                carpeta = "imagenes";
            }
            else if (folder == Folders.Documents)
            {
                carpeta = "documentos";
            }

            string path = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);

            if (folder == Folders.Temp)
            {
                path = Path.Combine(Path.GetTempPath(), fileName);
            }

            return path;
        }
    }
}