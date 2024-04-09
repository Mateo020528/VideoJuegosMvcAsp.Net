//Agregamos los datos de la carpeta Helpers:
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudJuegos.Providers;  //Conexión de ambos archivos
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CrudJuegos.Helpers
{
    public class HelperUploadFiles
    {
        private PathProvider pathProvider;

        public HelperUploadFiles(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
        }

        public async Task<String> UploadFilesAsync(IFormFile formFile, string nombreImagen, Folders folder)
        {
            string path = this.pathProvider.MapPath(nombreImagen, folder);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return path;
        }
    }
}