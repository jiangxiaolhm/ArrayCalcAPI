using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayCalcAPI.Services
{
    public class ArrayCalcService
    {
        public Task<T[]> Reverse<T>(T[] arr)
        {
            T temp;
            for (var i = 0; i < arr.Length / 2; i++)
            {
                temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }

            return Task.FromResult(arr);
        }

        public Task<T[]> DeletePart<T>(int positionToRemove, T[] arr)
        {
            T[] result = new T[arr.Length - 1];

            var resultIndex = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (i != positionToRemove - 1)
                {
                    result[resultIndex] = arr[i];
                    resultIndex++;
                }
            }
            
            return Task.FromResult(result);
        }
    }
}
