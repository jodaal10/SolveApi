using System;
using System.Collections.Generic;
using System.Text;
using Solve.BM.Calculate;
using Solve.DT.Calculate;
using NUnit.Framework;
using Solve.Api.Controllers;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Solve.Api.Tests
{
    public class CalculateControllerTests
    {
        private CalculateController Controller;
        private IBMCalculate objBmCalculate;

        [SetUp]
        public void Setup()
        {
            objBmCalculate = Substitute.For<IBMCalculate>();
            Controller = new CalculateController(objBmCalculate);
        }

        [Test]
        public void CalculateTripWhenInfoIsNull() {
            DTViajeUsuario objreq = new DTViajeUsuario();
            objreq.usuario = null;
            objreq.info = null;

            var result = this.Controller.CalculateTrip(objreq);
            
            Assert.IsTrue(result.Value.Resultado == false);
        }
        

        [Test]
        public void CalculateTripWhenInfoMayo500()
        {
            DTViajeUsuario objreq = new DTViajeUsuario();
            objreq.usuario = null;
            objreq.info = "500\n4\n30\n30\n1\n1\n3\n20\n20\n20\n11\n1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n11\n6\n9\n19\n29\n39\n49\n59\n10\n32\n56\n76\n8\n44\n60\n47\n85\n71\n91\n";

            var result = new CalculateController(objBmCalculate).CalculateTrip(objreq);

            Assert.IsTrue(result.Value.Resultado == false);
        }

    }
}
