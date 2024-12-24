public interface ITareasRepository
{
   public bool Guardar(Contacto contacto);
    public Contacto GetContacto(int id);
    public List<Contacto> GetContactos();
    public bool Update(Contacto contacto );
    public bool Delete(int id);
}