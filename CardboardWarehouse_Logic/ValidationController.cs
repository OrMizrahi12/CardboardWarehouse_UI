using CardboardWarehouse_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_Logic
{
    public class ValidationController
    {
        private int _numberOfValidation;
        private CustomList<string> _customList;
        public ValidationController(int numberOfValidation)
        {
            _numberOfValidation = numberOfValidation;
            _customList = new CustomList<string>();
        }

        public void NumValidation(string input,string filedName, int fromRange = 10, int toRange = 200)
        {
            if(NotNull(input) && NotNull(filedName))
            {
                if (int.TryParse(input, out int result) && result >= fromRange && result <= toRange)
                {
                    if (!_customList.Contain(filedName))
                    {
                        _customList.Add(filedName);
                    }
                }
                else
                {
                    if (_customList.Contain(filedName))
                    {
                        _customList.Remove(filedName);
                    }
                }
            }

        }

        public void StringValidation(string input, int fromRange = 2, int toRange = 10)
        {
            if(input.Length >= fromRange && input.Length <= toRange)
            {
                if (!_customList.Contain(input))
                {
                    _customList.Add(input);
                }
            }
            else
            {
                if (_customList.Contain(input))
                {
                    _customList.Remove(input);
                }
            }
        }
        private static bool NotNull(string input)
        {
            return input != null;
        }

        public bool SuccessValidation()
        {
            return _customList.Count == _numberOfValidation;
        }

        public void ClearValidationList()
        {
            _customList.Clear();
        }
    }
}
