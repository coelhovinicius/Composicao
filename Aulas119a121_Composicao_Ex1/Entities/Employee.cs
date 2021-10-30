/* >>> CLASSE EMPLOYEE <<< */

using System.Collections.Generic; // Namespace da classe LIST
using Aulas119a121_Composicao_Ex1.Entities.Enums; /* Necessario para ter acesso ao namespace da classe ENUM
                                                   * "EmployeeLevel" */

namespace Aulas119a121_Composicao_Ex1.Entities
{
    class Employee
    {
        // Propriedades da classe Employee
        public string Name { get; set; }
        public EmployeeLevel Level { get; set; } /* Propriedade tipo ENUM - Dentro da pasta "Entities, devemos criar 
                                                  * uma pasta de nome "Enums" para receber as entidades tipo ENUM. 
                                                  * No caso, faremos uma entidade tipo ENUM, de nome "EmployeeLevel", 
                                                  * que ira indicar o nivel do colaborador. Este ENUM devera ser 
                                                  * criado dentro da pasta "Entities"
                                                  */
        public double BaseSalary { get; set; }

        //Composicao de objetos - Associacao entre o Employee e o Department
        public Department Department { get; set; } /* Faz uma composicao de objetos diferentes - cria uma propriedade
                                                    * do tipo Department, com nome "Department", para associar o 
                                                    * Employee ao Department - Relacao 1 para 1, pois cada Employee
                                                    * so pode ter um Department
                                                    */
        /* Cria a lista tipo HourContract (para controlar os contratos do colaborador) e instancia essa lista
         * (new List<HourContract>()) para garantir que nao seja nula - Relacao 1 para Varios, pois cada Employee pode
         * ter varios HourContract - Pelo fato de que cada Employee pode ter varios HourContract, devemos criar uma
         * lista de HourContract */
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        // Construtores
        public Employee() // Construtor vazio (padrao)
        {
        }

        /* Construtor com argumentos - Nao e usual passar uma lista instanciada num construtor de um objeto.
         * Primeiramente, a lista se inicia vazia. Depois e que serao adicionados objetos, conforme a 
         * necessidade do projeto. Sempre que houver uma associasao "de 1 para varios", ela nao devera ser
         * incluida ao construtor, portanto, o Construtor nao devera conter a lista "Contracts" */
        public Employee(string name, EmployeeLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        // IMPLEMENTACAO DOS METODOS

        // Metodo para Adicionar o contrato ao colaborador - acessa a Lista Contracts e Adiciona Contracts
        public void AddContract(HourContract contract) // Adiciona a partir do argumento "contract"
        {
            Contracts.Add(contract); // Operacao para adicionar objetos a Contracts
        }

        // Metodo para Remover o contrato ao colaborador - acessa a Lista Contracts e Remove Contracts
        public void RemoveContract(HourContract contract) // Remove a partir do argumento "contract"
        {
            Contracts.Remove(contract); // Operacao para remove objetos de Contracts
        }

        public double Income(int year, int month) // Operacao Income - ganho em YYYY/MM - argumentos entre parenteses
        {
            double sum = BaseSalary; // Inicia com o valor do salario base informado pelo usuario
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue(); /* Soma o salario base ao "TotalValue()", que e o metodo da classe
                                                   * HourContract que retorna o valor obtido pelas horas informadas
                                                   * multiplicadas pelos valores por hora informados */
                }
            }
            return sum; // Employee retorna o resultado da soma do salario base + os contratos incluidos
        }
    }
}
