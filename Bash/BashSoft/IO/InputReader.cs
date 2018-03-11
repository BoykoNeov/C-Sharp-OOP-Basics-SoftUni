namespace BashSoft.IO
{
    using System;

    public class InputReader
    {
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            const string EndCommand = "quit";

            //OutputWriter.WriteMessage($"{SessionData.GetCurrentDirectoryPath()}> ");
            //string input = Console.ReadLine();
            //input = input.Trim();

            string input = string.Empty;

            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.GetCurrentDirectoryPath()}> ");
                input = Console.ReadLine();
                input = input.Trim();

                if (input.Equals(EndCommand))
                {
                    break;
                }
                else
                {
                    this.interpreter.InterpredCommand(input);
                }
            }
        }
    }
}