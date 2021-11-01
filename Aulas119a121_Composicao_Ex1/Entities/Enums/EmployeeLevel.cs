/* >>> ENUM EMPLOYEELEVEL (DENTRO DA PASTA ENUMS) <<< */

namespace Aulas119a121_Composicao_Ex1.Entities.Enums // Podemos mudar o nome do Namespace sem alterar o caminho das pastas
{
    enum EmployeeLevel : int /* Alterar de "class" para "enum", pois e um objeto tipo ENUM, derivando do tipo INT
                              * ( : int) */
    {
        Junior = 0, // Atribui strigs a valores tipo int (as strings sao informadas pelo usuario)
        MidLevel = 1,
        Senior = 2
    }
}
