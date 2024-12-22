
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers;

[Controller]
[Route("api/contacto")]
public class ContactoController : Controller
{
     private readonly ILogger<ContactoController> _logger;
    private readonly ITareasRepository _tareaRepository;

    public ContactoController(ILogger<ContactoController> logger, ITareasRepository tareaRepository)
    {
        _logger = logger;
        _tareaRepository = tareaRepository;
    }
  
[HttpGet("Listar")]
   public IActionResult Listar(){
       List<Contacto> lista= _tareaRepository.getContactos();

       return View(lista);
   }
[HttpGet ("Guardar")]
     public IActionResult Guardar(){
        //METODO SOLO DEVUELVE LA VISTA
        return View();
     }

 [HttpPost ("Guardar")]
    public IActionResult Guardar(Contacto contacto ){
        //METODO RECIBE EL OBJETO PARA GUARDARLO BD
        if (!ModelState.IsValid)
        {
            return View();
        }
         bool rpta= _tareaRepository.Guardar(contacto);
         if (rpta)
         {
           return RedirectToAction("Listar");
         }else
         {
             return View();
         }
       
     }
      [HttpGet ("Editar")]
       public IActionResult Editar(int Idcontacto ){
        //METODO SOLO DEVUELVE LA VISTA
             Contacto cont= _tareaRepository.getContacto(Idcontacto);
             return View(cont);
       }

        [HttpPost ("Editar")]
          public IActionResult Editar(Contacto oContacto ){
            if (!ModelState.IsValid)
            {
                return View();
            }
              
               bool rpta= _tareaRepository.Update(oContacto);
         if (rpta)
         {
           return RedirectToAction("Listar");
         }else
         {
             return View();
         }
           
       }

             [HttpGet ("Eliminar")]
       public IActionResult Eliminar(int Idcontacto ){
        //METODO SOLO DEVUELVE LA VISTA
             Contacto cont= _tareaRepository.getContacto(Idcontacto);
             return View(cont);
       }

        [HttpPost ("Eliminar")]
          public IActionResult Eliminar(Contacto oContacto ){
            if (!ModelState.IsValid)
            {
                return View();
            }
              
               bool rpta= _tareaRepository.Delete(oContacto.Id);
         if (rpta)
         {
           return RedirectToAction("Listar");
         }else
         {
             return View();
         }
           
       }

}
