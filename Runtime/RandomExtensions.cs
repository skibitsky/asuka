
using System;

namespace Skibitsky.Asuka
{
    public static class RandomExtensions
    {
        private static uint _boolBits;
        
        // https://stackoverflow.com/a/56777093
        public static bool NextBool(this Random source)
        {
            _boolBits >>= 1;
            if (_boolBits <= 1) _boolBits = (uint) ~source.Next();
            return (_boolBits & 1) == 0;
        }
    }
}