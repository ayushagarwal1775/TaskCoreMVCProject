using DTOLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlLayer.Interface
{
    public interface ITask
    {
        List<Productdetail> Product();
        bool ProductOperation(string CommandName, int id = 0, string Product = "", int Price = 0);
    }
}
