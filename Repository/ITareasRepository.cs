public interface ITareasRepository
{
   public bool Guardar(Contacto contacto);
    public Contacto getContacto(int id);
    public List<Contacto> getContactos();
    public bool Update(Contacto contacto );
    public bool Delete(int id);
}