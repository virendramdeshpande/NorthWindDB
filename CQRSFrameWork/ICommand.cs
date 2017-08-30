using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSFrameWork
{
    // Marker interface to signify a command - all command will implement this
    public interface ICommand
    {
    }

    //// Interface for command handlers - has a type parameters for the command
    //public interface ICommandHandler<in TParameter> where TParameter : ICommand
    //{
    //    Task<CommandResult> Execute(TParameter command);
    //}

    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        /// <summary>
        /// Executes a command handler
        /// </summary>
        /// <param name="command">The command to be used</param>
        void Execute(TParameter command);
    }


    // Simple result class for command handlers to return 
    public class CommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }

    //// Interface for the command dispatcher itself
    //public interface ICommandDispatcher
    //{
    //    Task<CommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    //}

    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        /// <typeparam name="TParameter">Command Type</typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        void Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }

    // Implementation of the command dispatcher - selects and executes the appropriate command 
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IKernel _kernel;

        public CommandDispatcher(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            _kernel = kernel;
        }

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            var handler = _kernel.Get<ICommandHandler<TParameter>>();
            handler.Execute(command);
        }

    }
}
