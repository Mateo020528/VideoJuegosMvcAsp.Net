using System.Reflection;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudJuegos.Data;
using CrudJuegos.Models;
using CrudJuegos.Providers;
using CrudJuegos.Helpers;

namespace CrudJuegos.Controllers{
    public class VideoJuegosController : Controller{
        //en este espacio agregamos la carpeta Data
        public readonly VideoJuegosContext _context;
        //Agregamos la función de la carpeta HelperUploadFiles
        private readonly HelperUploadFiles helperUploadFiles;

        public VideoJuegosController(VideoJuegosContext context, HelperUploadFiles helperUpload){
            _context = context;
            //Agregamos el helperUploadFiles
            this.helperUploadFiles = helperUpload;
        }
        // En este espacio agrego las vistas.
        public async Task<IActionResult> Index(){
            return View(await _context.VideoJuegos.ToListAsync());
        }
        //Apartado para editar 
        public async Task<IActionResult> Details (int ?id){
            return View(await _context.VideoJuegos.FirstOrDefaultAsync(m => m.Id == id));
        }
        //Apartado para editar 
        public async Task<IActionResult> Edit (int? id){
            return View(await _context.VideoJuegos.FirstOrDefaultAsync(m => m.Id == id));
        }
        //Agregamos a la base de datos
        [HttpPost]
        public  IActionResult Edit(int id, VideoJuego videojuego){
            _context.VideoJuegos.Update(videojuego);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Apartado para eliminar 
        public async Task<IActionResult> Delete(int id){
            var videoJuego = await _context.VideoJuegos.FindAsync(id);
            _context.VideoJuegos.Remove(videoJuego);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Apartado para crear 
        public  IActionResult Create(){
            return View();
        }
        //Agregamos a la base de gatos
        [HttpPost]
        //Para crear archivos agregamos los parametros FormFile una variable archivo y un tipo de dato entero con una variable llamada ubicacion
        public async Task<IActionResult> Create(VideoJuego v, IFormFile archivo, int ubicacion){

            //Inicializamos variales
            string NombreArchivo = archivo.FileName; //Este variable me agarra el nombre del objeto en este caso el archivo.
            string path =""; 

            //Agregamos la lógica para guardar en su lugar correspondiente el archivo ingresado.
            switch (ubicacion){
                // case 0:
                // path = await this.helperUploadFiles.UploadFilesAsync(archivo,NombreArchivo,Folders.Uploads);
                // break;
                case 1:
                path = await this.helperUploadFiles.UploadFilesAsync(archivo,NombreArchivo,Folders.Images);
                break;
                case 2:
                path = await this.helperUploadFiles.UploadFilesAsync(archivo,NombreArchivo,Folders.Documents); 
                break;
                // case 3:
                // path = await this.helperUploadFiles.UploadFilesAsync(archivo,NombreArchivo,Folders.Temp);
                // break;
            }

            
            v.Logo = NombreArchivo;

            _context.VideoJuegos.Add(v);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        

    }
}

