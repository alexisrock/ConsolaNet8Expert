using AutoMapper;
using Core.Interface;
using DataAccess.Interface;
using Domain.DataAccess;
using Domain.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class Service : IService
    {
        private readonly IStoreProcedureRepository storeProcedureRepository;
        private readonly IMapper mapper;
        private readonly ILogger<Service> logger;

        public Service(IStoreProcedureRepository _storeProcedureRepositor, IMapper mapper, ILogger<Service> logger)
        {
            this.storeProcedureRepository = _storeProcedureRepositor;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task AddInsertarUsuario(UsuarioIn usuarioIn)
        {
            try
            {
                var usuarioDB = mapper.Map<Usuario>(usuarioIn);
                await this.storeProcedureRepository.AddInsertarUsuario(usuarioDB);
            }
            catch (Exception  ex)
            {

                logger.LogError("Error: ", ex.Message);   
            }            
        }

        public async Task<List<UsuarioDBIn>> GetUsuarioCreados()
        {
            var listUsuarioIn = new List<UsuarioDBIn>();
            try
            {
                var listUsuario = await this.storeProcedureRepository.GetUsuarioCreados();
            listUsuario.ForEach(x => { 
             var usuarioInm = mapper.Map<UsuarioDBIn>(x);
                listUsuarioIn.Add(usuarioInm);

            });
            }
            catch (Exception ex)
            {
                logger.LogError("Error: ", ex.Message); throw;
            }


            return listUsuarioIn;
        }

        public async Task<List<UsuarioDBIn>> GetUsuariosPorEdad(int edad)
        {
            var listUsuarioIn = new List<UsuarioDBIn>();
            try
            {

                var listUsuario = await this.storeProcedureRepository.GetUsuariosPorEdad(edad);
                listUsuario.ForEach(x => {
                    var usuarioInm = mapper.Map<UsuarioDBIn>(x);
                    listUsuarioIn.Add(usuarioInm);

                });
            }
            catch (Exception ex)
            {
                logger.LogError("Error: ", ex.Message); throw;
            }
          

            return listUsuarioIn;
        }

        public async Task Run()
        {
            var usuario = new UsuarioIn()
            {
                Nombre = "Alexis ",
                Apellido = "Bueno",
                Edad = 36,
                Correo = "alexisrock20@gmmail.com",
                Hobbies = "Estudiar-HacerEjercicio-leer"
            };


            var usuarioDos = new UsuarioIn()
            {
                Nombre = "maria ",
                Apellido = "castro",
                Edad = 26,
                Correo = "mcastro@gmmail.com",
                Hobbies = "Trabajar-correr-leer"
            };


            logger.LogInformation("Usuario a Nombre" + usuario);
            


            await AddInsertarUsuario(usuario);
            logger.LogInformation("Usuario a insertar" + usuarioDos);
            await AddInsertarUsuario(usuarioDos);



            var list = await GetUsuarioCreados();
            logger.LogInformation("lista usuarios");
            list.ForEach(x =>
            {
                logger.LogInformation("Usuario a Nombre" + x.Nombre);
                logger.LogInformation("Usuario a Apellido" + x.Apellido);
                logger.LogInformation("Usuario a Edad" + x.Edad);
                logger.LogInformation("Usuario a Correo" + x.Correo);
                logger.LogInformation("Usuario a Hobbies" + x.Hobbies);
                logger.LogInformation("Usuario a Activo" + x.Activo);
                logger.LogInformation("Usuario a FechaInsercion" + x.FechaInsercion);
                logger.LogInformation("\n");



            });

            var listEdad = await GetUsuariosPorEdad(35);
            logger.LogInformation("lista usuarios por edad");
            listEdad.ForEach(x =>
            {
                logger.LogInformation("Usuario a Nombre" + x.Nombre);
                logger.LogInformation("Usuario a Apellido" + x.Apellido);
                logger.LogInformation("Usuario a Edad" + x.Edad);
                logger.LogInformation("Usuario a Correo" + x.Correo);
                logger.LogInformation("Usuario a Hobbies" + x.Hobbies);
                logger.LogInformation("Usuario a Activo" + x.Activo);
                logger.LogInformation("Usuario a FechaInsercion" + x.FechaInsercion);
                logger.LogInformation("\n");
            });
        }
    }
}
