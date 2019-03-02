using Domain.Entities;
using NUnit.Framework;
using Service.Services;
using Service.Validators;

namespace Tests
{
    public class UtService
    {
        /// <summary>
        /// Testes de integracao entre as camadas de servico, domain, data
        /// </summary>
        BaseService<Usuario> servico;
        Usuario objetoUsuario;

        [SetUp]
        public void Setup()
        {
            servico = new BaseService<Usuario>();
            objetoUsuario = new Usuario { Login = "Teste" };
        }
                

        [Test]
        public void Usuario()
        {
            //Validacao de inclusao
            var objetoRetorno = servico.Post<UsuarioValidator>(objetoUsuario);

            Assert.AreNotEqual(0, objetoRetorno.Id );

            //Validacao de alteracao
            objetoUsuario.Login = "NovoTeste";
            objetoRetorno = servico.Put<UsuarioValidator>(objetoUsuario);

            Assert.AreEqual(objetoUsuario.Login, objetoRetorno.Login);

            //Validacao de retorno
            var listaUsuario = servico.Get();

            Assert.AreNotEqual(0, listaUsuario.Count);

            objetoRetorno = servico.GetId(objetoUsuario.Id);

            Assert.AreEqual(objetoUsuario.Id, objetoRetorno.Id);

            //Validacao exclusao
            servico.Remove(objetoRetorno.Id);
            objetoRetorno = servico.GetId(objetoUsuario.Id);

            Assert.AreEqual(null, objetoRetorno);

        }
    }
}