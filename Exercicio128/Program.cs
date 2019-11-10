using System;
using System.Collections.Generic;
using System.IO;
using Exercicio128.Entities;
using System.Globalization;
using System.Linq;


namespace Exercicio128
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o caminho do arquivo: ");
            string path = Console.ReadLine();
            if (path == "")
            {
                path = "c:\\temp\\file2.txt";
            }
            Console.Write("Digite um valor de salário: ");
            double salarybase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employee = new List<Employee>();

            using( StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] linha = sr.ReadLine().Split(',');
                    string name = linha[0];
                    string email = linha[1];
                    double salary = double.Parse(linha[2], CultureInfo.InvariantCulture);

                    employee.Add(new Employee(name, email, salary));

                }
            }

            var result1 = employee.Where(x => x.Salary > salarybase).OrderBy(x => x.Email).Select(x => x.Email);
            var result2 = employee.Where(x => x.Name[0] == 'M').Sum(x => x.Salary);

            // resultados
            Console.WriteLine("Email em ordem alfabética cujo salário maior que " + salarybase.ToString("F2"));
            Console.WriteLine();

            foreach(string obj in result1)
            {
                Console.WriteLine(obj);
            }

            Console.Write("Soma dos salarios dos funcionários cujo nome começa com a letra M: ");
            Console.WriteLine(result2.ToString("F2"));



        }
    }
}
