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
       List<Contacto> lista= _tareaRepository.GetContactos();

       return View(lista);
   }
[HttpGet ("Guardar")]
     public IActionResult Guardar(){
        //METODO SOLO DEVUELVE LA VISTA
        return View();
     }
[HttpPost("Guardar")]
public IActionResult Guardar(GuardarViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    // Mapea el ViewModel al modelo de dominio (Contacto)
    var contacto = new Contacto
    {
        Id = model.Id,
        Nombre = model.Nombre,
        Telefono = model.Telefono,
        Email = model.Email
    };

    bool rpta = _tareaRepository.Guardar(contacto);
    if (rpta)
    {
        return RedirectToAction("Listar");
    }

    return View(model);
}
  [HttpGet]
 public IActionResult Editar(int id)
    {
        Contacto contacto =  _tareaRepository.GetContacto(id);
        if (contacto == null) return NotFound();

        // Convertimos el modelo a ViewModel para mostrar en la vista.
        var model = new GuardarViewModel
        {
            Id = contacto.Id,
            Nombre = contacto.Nombre,
            Telefono = contacto.Telefono,
            Email = contacto.Email
        };
        return View(model);
    }
      [HttpPost]
    public IActionResult Editar(GuardarViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Convertimos el ViewModel a modelo antes de actualizar.
            var contacto = new Contacto
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Email = model.Email
            };
            _tareaRepository.Update(contacto);
            return RedirectToAction("Listar");
        }
        return View(model);
    }
[HttpGet("Eliminar/{id}")]
    public IActionResult Eliminar(int id)
    {
        var contacto =_tareaRepository.GetContacto(id);
        if (contacto == null) return NotFound();

        // No usamos ViewModel porque no se necesitan validaciones en esta acción.
        return View(contacto);
    }

   [HttpPost("Eliminar")]
       public IActionResult ConfirmEliminar(int id)
    {
       _tareaRepository.Delete(id);
        return RedirectToAction("Listar");
    }

// [HttpPost("Eliminar")]
// public IActionResult ConfirmEliminar(GuardarViewModel model)
// {
//     if (!ModelState.IsValid)
//     {
//         return View(model);
//     }

//     bool rpta = _tareaRepository.Delete(model.Id);
//     if (rpta)
//     {
//         return RedirectToAction("Listar");
//     }

//     return View(model);
// }




           
       

}