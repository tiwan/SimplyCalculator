using SimplyCalculator_v2.Calculation;
using SimplyCalculator_v2.InputParser;
using SimplyCalculator_v2.MathOperation;
using SimplyCalculator_v2.MathOperationService;
using SimplyCalculator_v2.Priority;
using SimplyCalculator_v2.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplyCalculator_v2
{
    class Program
    {

        static void Main(string[] args)
        {
            var container = new Container();

            SetupDI(container);

            var uiservice = new UIService(container);

            Console.WriteLine("Hello Calculator!");

            uiservice.MainLoop();
          
        }

        private static void SetupDI(Container container)
        {
            container.Register<IInputParserService, InputParserService>();
            container.Register<IOperationFactory, OperationFactory>();
            container.Register<IPriorityService, PriorityService>();
            container.Register<ICalculationService, CalculationService>();
            
        }

    }
}
