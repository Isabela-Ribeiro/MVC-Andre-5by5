using Model;
using System.Collections.Generic;


namespace Data
{

    public interface IPizzaDB
    {
        //fica o crud 
        bool Insert(Pizza pizza);
        bool Update(Pizza pizza);
        bool Delete(int id);
        Pizza SelectById(int id);
        List<Pizza> Select();
    }

}
