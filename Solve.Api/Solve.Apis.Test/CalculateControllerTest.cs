using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Solve.Api.Controllers;
using Solve.BM.Calculate;
using Solve.DT.Calculate;

namespace Solve.Apis.Test
{
    public class CalculateControllerTest
    {
        private CalculateController Controller;
        private IBMCalculate ObjBmcalculate;

        [SetUp]
        public void Setup()
        {
            Controller = new CalculateController(ObjBmcalculate);
        }

        public void CalculateTripWhenUserIsnull()
        {
            DTViajeUsuario objreq = new DTViajeUsuario();

            //var result = this.Controller.CalculateTrip(objreq);
        }
    }
}
