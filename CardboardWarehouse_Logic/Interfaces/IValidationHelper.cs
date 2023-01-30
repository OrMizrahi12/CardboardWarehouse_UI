using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Logic.Interfaces
{
    public interface IValidationHelper
    {
        public void NumValidation(string input, string filedName, int fromRange = 10, int toRange = 200);
        public void StringValidation(string input, int fromRange = 2, int toRange = 10);
        public bool SuccessValidation();
        public bool NotNull(object input);
    }
}
