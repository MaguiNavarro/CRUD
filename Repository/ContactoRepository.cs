using Microsoft.Data.Sqlite;

public class ContactoRepository: ITareasRepository
{
     private string _cadenaDeConexion;
     public ContactoRepository(string cadenaConexion){  //Constructor que recibe conexion
         _cadenaDeConexion= cadenaConexion;
     }

     public List<Contacto> getContactos(){
        string query = "SELECT * FROM Contacto";
        List<Contacto> contactos= new List<Contacto>();

        using (SqliteConnection conexion= new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
             SqliteCommand command = new SqliteCommand(query, conexion);

             using (SqliteDataReader reader= command.ExecuteReader())
             {
                while (reader.Read())
                {
                      var contacto = new Contacto{

                        Id = Convert.ToInt32(reader["id"]),
                        Nombre= reader["nombre"].ToString(),
                        Telefono= reader["telefono"].ToString(),
                        Email= reader["email"].ToString()
                      };
                      contactos.Add(contacto);

                }
             }
           conexion.Close();
        }
           return contactos;

     }

        public Contacto getContacto(int id){
             string query = "SELECT * FROM Contacto WHERE id= @Id ";
        Contacto contacto= null;

        using (SqliteConnection conexion= new SqliteConnection(_cadenaDeConexion))
        {
            conexion.Open();
             SqliteCommand command = new SqliteCommand(query, conexion);
              command.Parameters.Add(new SqliteParameter("@Id", id));

             using (SqliteDataReader reader= command.ExecuteReader())
             {
                while (reader.Read())
                {
                      var contact = new Contacto{

                        Id = Convert.ToInt32(reader["id"]),
                        Nombre= reader["nombre"].ToString(),
                        Telefono= reader["telefono"].ToString(),
                        Email= reader["email"].ToString()
                      };
                   

                }
             }
           conexion.Close();
        }
           return contacto;
        }
           public bool Update(Contacto contacto ){
             
              bool rpta;
             string query = "UPDATE Contacto SET id= @Id, nombre= @Nombre , email= @Email, telefono= @Telefono  ";
            
             try
             {
                using (SqliteConnection conexion= new SqliteConnection(_cadenaDeConexion))
            {
               conexion.Open();
               SqliteCommand command = new SqliteCommand(query, conexion);
                 command.Parameters.AddWithValue("@Id", contacto.Id);
               command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
               command.Parameters.AddWithValue("@Email", contacto.Email) ;
               command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
               command.ExecuteNonQuery();
               conexion.Close();
             } 
             rpta= true;
             }
             catch (System.Exception)
             {
                
                rpta= false;
             }
             
             return rpta;

         }
   public bool Guardar(Contacto contacto)

    {
        string query = @"INSERT INTO Contacto (nombre, email, telefono) VALUES (@nombre, @email, @telefono);";
        bool rpta;
        try
        {
             using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
         {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", contacto.Nombre);
            command.Parameters.AddWithValue("@email", contacto.Email);
            command.Parameters.AddWithValue("@telefono", contacto.Telefono);
            command.ExecuteNonQuery();
            connection.Close();
          }
          rpta= true;
        }
        catch (System.Exception)
        {
         
           rpta=false;
        }
         return rpta;
    }
          public bool Delete(int id){
             string query = @"DELETE FROM Contacto WHERE id = @Id;";
             bool rpta;
             try
             {
               using (SqliteConnection connection = new SqliteConnection(_cadenaDeConexion))
              {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                connection.Close();
                rpta= true;
               }
              
             }
             catch (System.Exception)
             {
                
                rpta=false;
             }
             return rpta;
          }
       

}