// <copyright file="RegistrarEmpresarioTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Casos de prueba para el handler RegistrarEmpresario.
    /// </summary>
    [TestFixture]
    public class RegistrarEmpresarioTest
    {
       /// <summary>
       /// SetUp de los casos de prueba.
       /// </summary>
        [SetUp]
        public void Setup()
        {
            ListaEmpresa lista1 = new ListaEmpresa();
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
        }

        /// <summary>
        /// En este test verificamos que, cuando la invitación es válida, el id del usuario se añade correctamente a
        ///  la lista de ids de la empresa.
        /// </summary>
        [Test]
        public void InvitacionValidaTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Ingrese su código de invitación: ", "ValidToken");
            diccionario.Add("Ingrese nombre: ", "Pepe");
            Mensaje mensaje = new Mensaje(1001, "/empresario");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Empresa empresa1 = new Empresa("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            List<string> lista = Singleton<ListaInvitaciones>.Instance.Invitaciones;
            lista.Add("ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Input = lector;
            registrarEmpresario.SetNext(new NullHandler());
            registrarEmpresario.Handle(mensaje);
            ListaEmpresa lista32 = new ListaEmpresa();
            bool result = lista32.Verificar(1001);
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Este test verifica que no es posible el registro con una invitacion invalida.
        /// </summary>
        [Test]
        public void InvitacionInvalidaTest()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
            diccionario.Add("Ingrese su código de invitación: ", "InvalidToken");
            diccionario.Add("Ingrese nombre: ", "Pepe");
            ListaEmpresa lista1 = new ListaEmpresa();
            Mensaje mensaje = new Mensaje(1002, "/empresario");
            RegistrarEmpresarioHandler registrarEmpresario = new RegistrarEmpresarioHandler();
            Administrador admin = new Administrador(456, "admin");
            Administrador.CrearInvitacion("ResgistrarEmpresaTest", "Montevideo", "textil", "ValidToken");
            LectorTest lector = new LectorTest(diccionario);
            registrarEmpresario.Input = lector;
            registrarEmpresario.SetNext(new NullHandler());
            registrarEmpresario.Handle(mensaje);

            bool resultado = Singleton<ListaEmpresa>.Instance.Verificar(1002);
            Assert.AreEqual(resultado, false);
        }
    }
}