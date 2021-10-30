/* >>> CLASSE DEPARTMENT (PASTA ENTITIES) <<< */

namespace Aulas119a121_Composicao_Ex1.Entities
{
    class Department
    {
        public string Name { get; set; }

        public Department() // Construtor padrao da classe Department
        {
        }

        public Department(string name) // Construtor para receber o nome do funcionario
        {
            Name = name;
        }
    }
}
