using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck
{

    class Registry : IInterpreter
    {
        private IDictionary<int, int> _data = new Dictionary<int, int>();
        private int _dataPointer = 0;
        private const int MAX_BIT_VALUE = 255;
        private const int MIN_BIT_VALUE = 0;
        private const int STARTING_VALUE = 0;

        private void changeDataCellValue(Action alterBit, Func<int, bool> isInRange, int flowedValue)
        {
            if (!_data.ContainsKey(_dataPointer))
            {
                _data.Add(_dataPointer, STARTING_VALUE);
            }
            alterBit();
            if (isInRange(_data[_dataPointer]))
            {
                _data[_dataPointer] = flowedValue;
            }
        }

        public void DecrementValue()
        {
            // check to see if it exists
            // normalize to between 0 & 255
            // decrease the value,
            Action action = () => _data[_dataPointer]--;
            Func<int, bool> range = x => x < MIN_BIT_VALUE;
            this.changeDataCellValue(action, range, MAX_BIT_VALUE);
        }

        public void IncrementValue()
        {
            // check to see if it exists
            // normalize to between 0 & 255
            // increase the value,
            Action action = () => _data[_dataPointer]++;
            Func<int, bool> range = x => x > MAX_BIT_VALUE;
            this.changeDataCellValue(action, range, MIN_BIT_VALUE);
        }
       


        public override string ToString()
        {
            var rv = String.Empty;
            foreach (var bit in _data)
            {
                rv += $"{bit.Key} : {bit.Value}" + Environment.NewLine;
            }
            rv += $"datapointer : {_dataPointer}";
            return rv;
        }

    }
}
