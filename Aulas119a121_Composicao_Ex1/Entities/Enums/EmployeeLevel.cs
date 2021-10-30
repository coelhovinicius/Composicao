/* >>> ENUM EMPLOYEELEVEL <<< */

namespace Aulas119a121_Composicao_Ex1.Entities.Enums
{
    enum EmployeeLevel : int /* Alterar de "class" para "enum", pois e um objeto tipo ENUM, derivando de um tipo INT
                              * ( : int) */
    {
        Junior = 0, // Atribui strigs a valores tipo int (as strings sao informadas pelo usuario)
        MidLevel = 1,
        Senior = 2
    }
}
