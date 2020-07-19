using System.Linq;
using System.Collections.Generic;
using WorkerAPI.Entities.Enums;

namespace WorkerAPI.Entities
{
    public class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(){  }
        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }
        public void AddContract(HourContract contract) => Contracts.Add(contract);
        public bool RemoveContract(HourContract contract) => Contracts.Remove(contract);
        public double Income(int year, int month) => Contracts
                                                    .Where(contract => contract.Date.Year.Equals(year)&&contract.Date.Month.Equals(month))
                                                    .Sum(contract => contract.TotalValue()) + BaseSalary;
    }
}