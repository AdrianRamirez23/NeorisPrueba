using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace API.Neoris.Services.Contracts
{
    public class UsuarioSrvs: IUsuarioSrvs
    {
       
        protected NeorisContext Context { get; set; }
        public UsuarioSrvs( NeorisContext context) 
        {
           Context= context;
        }

        public Persona UsuarioById(string id)
        {
            try
            {
                return Context.Personas.Where(a => a.Identificacion == id).Include(b => b.Cliente).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Persona> ListarUsuarios()
        {
            try
            {
                return Context.Personas.Include(b => b.Cliente).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Persona CrearUsuario(Persona persona)
        {
            try
            {
                var personasData = Context.Personas.ToList();
                if (!personasData.Exists(a => a.Identificacion == persona.Identificacion))
                {
                    Context.Personas.Add(persona);
                    Context.SaveChanges();
                    var personaCreada = Context.Personas.FirstOrDefault(a => a.Identificacion == persona.Identificacion);
                    return personaCreada;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
               
            }
           
        }
        public List<Persona> CrearListaUsuario(List<Persona> personas)
        {
            try
            {
                List<Persona> result = null;

                if (personas != null) result = new List<Persona>();


                foreach(var persona in personas) 
                {
                    var personasData = Context.Personas.ToList();
                    if (!personasData.Exists(a => a.Identificacion == persona.Identificacion))
                    {
                        Context.Personas.Add(persona);
                        Context.SaveChanges();
                        var personaCreada = Context.Personas.FirstOrDefault(a => a.Identificacion == persona.Identificacion);
                        result.Add(personaCreada);
                    }
                }

               
                return result;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public Persona EditarUsuario(Persona persona)
        {
            try
            {
                var personasData = Context.Personas.AsNoTrackingWithIdentityResolution().ToList();
                var personaEditada = personasData.FirstOrDefault(a => a.Identificacion == persona.Identificacion);
                if (personasData.Exists(a => a.Identificacion == persona.Identificacion))
                {
                    personaEditada.Nombre = persona.Nombre;
                    personaEditada.Edad = persona.Edad;
                    personaEditada.Direccion = persona.Direccion;
                    personaEditada.Telefono = persona.Telefono;
                    if(persona.Cliente != null) 
                    {
                        var cliente = Context.Clientes.Where(a => a.ClienteId == personaEditada.PersonaId).AsNoTrackingWithIdentityResolution().FirstOrDefault();
                        cliente.Estado = persona.Cliente.Estado;
                        cliente.Contrasena = persona.Cliente.Contrasena;
                        Context.Clientes.Update(cliente);
                    }
                    Context.Personas.Update(personaEditada);
                    Context.SaveChanges();
                    
                    return personaEditada;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

    }
}
