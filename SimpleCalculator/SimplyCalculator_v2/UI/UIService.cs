using SimplyCalculator_v2.Calculation;
using SimplyCalculator_v2.InputParser;
using SimplyCalculator_v2.MathOperation;
using SimplyCalculator_v2.MathOperationService;
using SimplyCalculator_v2.Priority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplyCalculator_v2.UI
{

    public class UIService
    {
        private Container _container;


        public UIService(Container container)
        {
            _container = container;
        }

        public void MainLoop()
        {
            var inputParser = _container.Resolve<IInputParserService>();
            var priorityService = _container.Resolve<IPriorityService>();
            var operationFactory = _container.Resolve<IOperationFactory>();
            var calculationService = _container.Resolve<ICalculationService>();

            
            /// Setup avaible arithmetic  operations for input parser
            SetupInputParser(inputParser);

            /// Setup custom priority for avaible operations
            SetupPriority(priorityService, operationFactory);

            while (true)
            {
                try
                {
                    Console.WriteLine("Input arithmetic equalision or exit");

                    var userInput = Console.ReadLine();

                    if (userInput == "exit")
                        ExitAction();

                    var charArray = inputParser.ParseToList(userInput);

                    var result = calculationService.Calculate(charArray.ToList(), priorityService);

                    Console.WriteLine("Result: " + result.First());
                }
                catch (Exception exc)
                {
                    Logger.Log(exc);
                }
            }
        }

        private void SetupInputParser(IInputParserService inputParser)
        {
            char[] operatorArray = new char[] { '+', '-', '*', '/'};
            inputParser.SetOperatorsToSeperate(operatorArray);
        }

        private void SetupPriority(IPriorityService piorityService, IOperationFactory operationFactory)
        {
            piorityService.AddToPiority(1, operationFactory.CreateOperation(OperationEnum.Multiplication));
            piorityService.AddToPiority(1, operationFactory.CreateOperation(OperationEnum.Division));

            piorityService.AddToPiority(2, operationFactory.CreateOperation(OperationEnum.Add));
            piorityService.AddToPiority(2, operationFactory.CreateOperation(OperationEnum.Subtract));
        }

        private void ExitAction()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
