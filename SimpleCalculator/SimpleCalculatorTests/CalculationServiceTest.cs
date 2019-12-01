using NUnit.Framework;
using SimplyCalculator_v2.Calculation;
using SimplyCalculator_v2.MathOperation;
using SimplyCalculator_v2.Priority;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculatorTests
{
    [TestFixture]
    public class CalculationServiceTest
    {
        private ICalculationService _calculationService;
        private IPriorityService _piorityService;

        public static object[] _sourceLists = {new object[] {new List<string> {"2","+","2","*","2"}, "6"},
                                         new object[] {new List<string> { "4", "+", "5", "*", "2" }, "14"} 
                                    };

        [SetUp]
        public void Setup()
        {
            _piorityService = new PriorityService();
            var operationFactory = new OperationFactory();

            _piorityService.AddToPiority(1, operationFactory.CreateOperation(OperationEnum.Multiplication));
            _piorityService.AddToPiority(1, operationFactory.CreateOperation(OperationEnum.Division));

            _piorityService.AddToPiority(2, operationFactory.CreateOperation(OperationEnum.Add));
            _piorityService.AddToPiority(2, operationFactory.CreateOperation(OperationEnum.Subtract));

            _calculationService = new CalculationService();
        }

        [Test, TestCaseSource("_sourceLists")]
        public void Calculate_ShouldReturnCorrectResult(List<string> testList, string result)
        {
            var res = _calculationService.Calculate(testList, _piorityService);

            Assert.AreEqual(new List<string> { result}, res);
        }
    }
}
