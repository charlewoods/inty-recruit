using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IntyRecruit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceManipulator = new RecruitmentServiceManipulator();
            Console.WriteLine("Starting process");
            serviceManipulator.PerformRecruitmentSteps();
            Console.ReadLine();
        }
    }
}
