using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Creational
{
    public class Builder
    {
    }

    public class ComputerPart
    {
        public int Id { get; set; }

        public string Part { get; set; }

        public string UserType { get; set; }

        public string PartCode { get; set; }
    }

    public class Computer
    {
        public IList<ComputerPart> Parts { get; set; }
        public Computer()
        {
            Parts = new List<ComputerPart>();
        }
    }

    public interface IComputerBuilder
    {
        void AddCPU();
        void AddMouse();
        void AddMonitor();
        void AddKeyboard();

        Computer GetComputer();
    }

    public class HomeComputerBuilder : IComputerBuilder
    {
        private Computer _Computer;

        public HomeComputerBuilder()
        {
            _Computer = new Computer();
        }

        public void AddCPU()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "CPU", UserType = "Home" });
        }

        public void AddKeyboard()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Keyboard", UserType = "Home" });
        }

        public void AddMonitor()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Monitor", UserType = "Home" });
        }

        public void AddMouse()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Mouse", UserType = "Home" });
        }

        public Computer GetComputer()
        {
            return _Computer;
        }
    }

    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _Computer;

        public OfficeComputerBuilder()
        {
            _Computer = new Computer();
        }

        public void AddCPU()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "CPU", UserType = "Office" });
        }

        public void AddKeyboard()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Keyboard", UserType = "Office" });
        }

        public void AddMonitor()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Monitor", UserType = "Office" });
        }

        public void AddMouse()
        {
            _Computer.Parts.Add(new ComputerPart() { Id = 1, Part = "Mouse", UserType = "Office" });
        }

        public Computer GetComputer()
        {
            return _Computer;
        }
    }

    /// <summary>
    /// director
    /// </summary>
    public class ComputerAssembler
    {
        private IComputerBuilder _ComputerBuilder;

        public ComputerAssembler(IComputerBuilder computerBuilder)
        {
            _ComputerBuilder = computerBuilder;
        }

        public Computer AssembleComputer()
        {
            _ComputerBuilder.AddCPU();
            _ComputerBuilder.AddKeyboard();
            _ComputerBuilder.AddMonitor();
            _ComputerBuilder.AddMouse();
            return _ComputerBuilder.GetComputer();
        }
    }
        
}