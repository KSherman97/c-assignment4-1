// Kyle Sherman
// Assignment 4
// Due 3/20/17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {

        private static IComparable<Droid>[] aux;

        public static void Sort(IComparable<Droid>[] a)
        {
            aux = new IComparable<Droid>[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(IComparable<Droid>[] a, int low, int high)
        {
            if (high <= low)
                return;

            int mid = low + (high - low) / 2;
            Sort(a, low, mid);
            Sort(a, mid + 1, high);
            Merge(a, low, mid, high);
        }

        //private static void Sort(IComparable<T>[] a, int low, int high)

        public static void Merge(IComparable<Droid>[] a, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;
            for (int k = low; k <= high; k++)
            {
                aux[k] = a[k];
            }
            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                { 
                    a[k] = aux[j++]; 
                }
                else
                {
                    if (j > high)
                    { 
                        a[k] = aux[i++]; 
                    }
                    else
                    {
                        if (aux[j].CompareTo((Droid)aux[i]) < 0)
                        { 
                            a[k] = aux[j++]; 
                        }
                        else
                            a[k] = aux[i++];
                    }
                }
            }
        }
    }
}
