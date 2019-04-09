using Domain.Entities;
using Domain.Interfaces;
using NUnit.Framework;
using Service.Services;
using Service.Validators;
using NSubstitute;

namespace Tests
{
    public class UtService
    {
        /// <summary>
        /// Testes de integracao entre as camadas de servico, domain, data
        /// </summary>
        //BaseService<Usuario> servico;
        IService<Usuario> mock;
        IService<Usuario> servico;
        Usuario objetoUsuario;


        [SetUp]
        public void Setup()
        {
            //mock = Substitute.For<IService<Usuario>>();
            //servico = new BaseService<Usuario>();
            //objetoUsuario = new Usuario { Login = "Teste", Id = 1 };            
        }
                

        [Test]
        public void Usuario()
        {
            //Validacao de inclusao

           // var objetoMockRetorno = mock.Post<UsuarioValidator>(objetoUsuario).Returns(new Usuario { Id = 1, Login = "teste" }) ;
            //Assert.AreEqual(1, (Usuario)objetoMockRetorno.Id);


           // var objetoRetorno = servico.Post<UsuarioValidator>(objetoUsuario);
            //Assert.AreNotEqual(0, objetoRetorno.Id );

            ////Validacao de alteracao
            //objetoUsuario.Login = "NovoTeste";
            //objetoRetorno = servico.Put<UsuarioValidator>(objetoUsuario);

            //Assert.AreEqual(objetoUsuario.Login, objetoRetorno.Login);

            ////Validacao de retorno
            //var listaUsuario = servico.Get();

            //Assert.AreNotEqual(0, listaUsuario.Count);

            //objetoRetorno = servico.GetId(objetoUsuario.Id);

            //Assert.AreEqual(objetoUsuario.Id, objetoRetorno.Id);

            ////Validacao exclusao
            //servico.Remove(objetoRetorno.Id);
            //objetoRetorno = servico.GetId(objetoUsuario.Id);

            //Assert.AreEqual(null, objetoRetorno);

        }
    }
}