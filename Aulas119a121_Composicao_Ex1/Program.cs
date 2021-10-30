/* Composicao - Exercicio 1 - Codigo no link https://github.com/acenelio/composition1-csharp 
 
 Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar
 do usuário um mês e mostrar qual foi o salário do funcionário nesse mês, conforme exemplo:

    Enter department's name: Design
    Enter worker data:
    Name: Alex
    Level (Junior/MidLevel/Senior): MidLevel
    Base salary: 1200.00
    How many contracts to this worker? 3
    Enter #1 contract data:
    Date (DD/MM/YYYY): 20/08/2018
    Value per hour: 50.00
    Duration (hours): 20
    Enter #2 contract data:
    Date (DD/MM/YYYY): 13/06/2018
    Value per hour: 30.00
    Duration (hours): 18
    Enter #3 contract data:
    Date (DD/MM/YYYY): 25/08/2018
    Value per hour: 80.00
    Duration (hours): 10
    Enter month and year to calculate income (MM/YYYY): 08/2018
    Name: Alex
    Department: Design
    Income for 08/2018: 3000.00

 - Criar a pasta "Entities" no programa principal (no caso, em "Aulas119a121_Composicao_Ex1"). Dentro dela, criar
   (criar as pastas das pontas primeiro):
    > Classe Department;
    > Classe HourContract;
    > Classe Employee - ela dependera da pasta "Enums";
    > Criar a pasta "Enums" dentro da pasta "Entities";
        - Dentro da pasta "Enums", criar o Tipo ENUM de nome "EmployeeLevel" (lembrar de alterar de "class"
          para "enum";

 - Criar o programa principar para implementar a interacao com o usuario (interface do usuario).

 */

/* >>> PROGRAMA PRINCIPAL <<< */

using System;
using System.Globalization;
using Aulas119a121_Composicao_Ex1.Entities;
using Aulas119a121_Composicao_Ex1.Entities.Enums;

namespace Aulas119a121_Composicao_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter employee data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior / MidLevel / Senior): ");
            EmployeeLevel level = Enum.Parse<EmployeeLevel>(Console.ReadLine()); /* Converte a string digitada para tipo
                                                                                  * EmployeeLevel, converte para tipo
                                                                                  * ENUM e guarda na variavel  "level", 
                                                                                  * sendo "level" e uma variavel tipo 
                                                                                  * EmployeeLevel */
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); // Instancia o objeto Department
            Employee employee = new Employee(name, level, baseSalary, dept); // Instancia o objeto Employee

            Console.Write("How many contracts for this employee? ");
            int n = int.Parse(Console.ReadLine()); // Entra com o numero de contratos a serem atribuidos ao Employee

            for (int i = 1; i <= n; i++) // Adicionando contratos
            {
                Console.WriteLine($"Enter contract #{i} data:"); // Chama o "i" por Interpolacao
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine()); // Le os dados digitados
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Le os dados
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine()); // Le os dados digitados
                HourContract contract = new HourContract(date, valuePerHour, hours); /* Define uma variavel "contract"
                                                                                      * do tipo "HourContract", e
                                                                                      * instancia com os argumentos
                                                                                      * entre parenteses */
                employee.AddContract(contract); // Adiciona a lista de contratos ao Employee
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine(); // Variavel string para ler o mes e ano no formato MM/YYYY
            // Usar substring para recortar a data digitada
            int month = int.Parse(monthAndYear.Substring(0, 2)); // Recorta dois caracteres da string, a partir da posicao 0
            int year = int.Parse(monthAndYear.Substring(3)); // Recorta os caracteres a partir da posicao 3 da string
            Console.WriteLine("Name: " + employee.Name);
            Console.WriteLine("Department: " + employee.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + employee.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
