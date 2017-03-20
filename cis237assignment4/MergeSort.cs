using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {

        private static IComparable[] aux;
        private static void Sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(IComparable[] a, int low, int high)
        {
            if (high <= low)
                return;

            int mid = low + (high - low) / 2;
            Sort(a, low, mid);
            Sort(a, mid + 1, high);
            //Merge(a, low, mid, high);
        }

        public static void Merge(IComparable[] a, IComparable[] aux, int low, int mid, int high)
        {
            for (int k = low; k <= high; k++)
            {
                aux[k] = a[k];
            }
        }
        public static void MergeSort(IComparable[] a, IComparable[] aux, int low, int mid, int high)
        {
            
        }

    }
}
