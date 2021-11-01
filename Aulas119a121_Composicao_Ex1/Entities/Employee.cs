/* >>> CLASSE EMPLOYEE (PASTA ENTITIES) <<< */

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
        public Department Department { get; set; } /* Faz uma Composicao de Objetos diferentes - cria uma propriedade
                                                    * do tipo Department, com nome "Department", para associar o 
                                                    * Employee ao Department - Relacao 1 para 1, pois cada Employee
                                                    * so pode ter um Department
                                                    */
        /* Cria a lista tipo HourContract (para controlar os contratos do colaborador) - Relacao 1 para VARIOS, 
         * pois cada Employee pode ter varios HourContract - Pelo fato de que cada Employee pode ter varios HourContract, devemos criar uma
         * lista de HourContract */
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); /* instancia a lista HourContract,
                                                                                       * para garantir que nao seja nula 
                                                                                       */

        // Construtores
        public Employee() // Construtor vazio (padrao)
        {
        }

        /*  Construtor com argumentos - Via de regra, sempre que houver uma associasao 1 para VARIOS, ela nao devera ser 
         *  incluida ao construtor, portanto, nao incluiremos a Lista "Contracts"- Nao e usual passar uma lista instanciada 
         *  em um construtor de um objeto. Primeiramente, a lista se inicia vazia. Depois e que serao adicionados objetos, 
         *  conforme a necessidade do projeto. */
        public Employee(string name, EmployeeLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        /* IMPLEMENTACAO DOS METODOS - Conforme proposto, devemos implementar tres metodos a essa classe */

        /* Metodo AddContracts - Adiciona contrato ao colaborador - Adiciona "contract" a lista "Contracts" */
        public void AddContract(HourContract contract) /* Metodo "AddContract" - Adiciona,  a partir do parametro de
                                                        * entrada "contract", a lista "Contracts" */
        {
            Contracts.Add(contract); // O metodo "AddContract" adiciona o parametro "contract" a lista "Contracts"
        }

        // Metodo RemoveContracts - Remove contrato do colaborador - Remove "contract" da lista "Contracts"
        public void RemoveContract(HourContract contract) /* Metodo "RemoveContract" - Remove, a partir do parametro
                                                           * de entrada "contract", da lista "Contracts" */
        {
            Contracts.Remove(contract); // O metodo "RemoneContract" remove o parametro "contract" da lista "Contracts"
        }

        /* Metodo Income - Verifica se o mes e ano informados correspondem a contratos existentes e, para cada contratos
         * correspondente, faz a soma dos valores. Ao final, retorna  */
        public double Income(int year, int month) // Operacao Income - ganho em YYYY/MM - argumentos entre parenteses
        {
            double sum = BaseSalary; // Inicia com o valor do salario base informado pelo usuario e atribui a "sum"
            foreach (HourContract contract in Contracts) /* Para cada objeto tipo HourContract "contract" na lista 
                                                          * "Contracts" */
            {
                if (contract.Date.Year == year && contract.Date.Month == month) /* Se o ano e mes informados corresponderem
                                                                                   aos contratos em "Contracts" */
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