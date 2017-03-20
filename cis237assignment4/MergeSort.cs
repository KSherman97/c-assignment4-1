using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    static class MergeSort<T>
    {

        private static IComparable<T>[] aux;

        public static void Sort(IComparable<T>[] a)
        {
            aux = new IComparable<T>[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(IComparable<T>[] a, int low, int high)
        {
            if (high <= low)
                return;

            int mid = low + (high - low) / 2;
            Sort(a, low, mid);
            Sort(a, mid + 1, high);
            Merge(a, low, mid, high);
        }

        //private static void Sort(IComparable<T>[] a, int low, int high)

        public static void Merge(IComparable<T>[] a, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;
            for (int k = low; k <= high; k++)
            {
                aux[k] = a[k];
            }
            for(int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else
                {
                    if (aux[j].CompareTo((T)aux[i]) < 0)
                    { a[k] = aux[j++]; }
                    else
                        a[k] = aux[i++];
                }
            }
        }
    }
}
