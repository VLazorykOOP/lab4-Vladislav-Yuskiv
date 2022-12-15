using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabVector
{
    public class VectorLong
    {
        private long[] longArray;
        private uint size;
        private int codeError;
        private static int numVl;

        public uint Size { get => size; }

        public int CodeError { get => codeError; set { codeError = value; } }

        public long this[uint index]
        {
            get
            {
                try
                {
                    codeError = 0;
                    return longArray[index];
                }
                catch
                {
                    codeError = -1;
                    return 0;
                }
            }

            set
            {
                try
                {
                    longArray[index] = value;
                    codeError = 0;
                }
                catch
                {
                    codeError = -1;
                }
            }
        }

        public VectorLong() : this(1, 0) { }

        public VectorLong(uint size) : this(size, 0) { }

        public VectorLong(uint size, long placeholderElement)
        {
            longArray = new long[size];
            for (int i = 0; i < size; i++)
                longArray[i] = placeholderElement;

            this.size = size;
            numVl++;
        }

        ~VectorLong()
        {
            Console.WriteLine("destructor called");
            numVl--;
        }

        public void Input()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"input value for index {i}: ");
                if (long.TryParse(Console.ReadLine(), out long val))
                    longArray[i] = val;
                else
                    throw new FormatException();
            }
        }

        public void Print()
        {
            foreach (long item in longArray)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        public void AssignValueToAll(long value)
        {
            for (int i = 0; i < size; i++)
                longArray[i] = value;
        }

        public static int GetVectorsCount() => numVl;

        public static VectorLong operator ++(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
                vector.longArray[i]++;
            return vector;
        }

        public static VectorLong operator --(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
                vector.longArray[i]--;
            return vector;
        }

        public static bool operator true(VectorLong vector) => vector.size != 0;

        public static bool operator false(VectorLong vector) => vector.size == 0;

        public static bool operator !(VectorLong vector) => vector.size != 0;

        public static VectorLong operator ~(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
                vector.longArray[i] = ~vector.longArray[i];

            return vector;
        }

        public static VectorLong operator +(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] += vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator +(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] += scalar;

            return thisVector;
        }

        public static VectorLong operator -(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] -= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator -(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] -= scalar;

            return thisVector;
        }

        public static VectorLong operator *(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] *= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator *(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] *= scalar;

            return thisVector;
        }

        public static VectorLong operator /(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] /= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator /(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] /= scalar;

            return thisVector;
        }

        public static VectorLong operator %(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] %= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator %(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] %= scalar;

            return thisVector;
        }

        public static VectorLong operator |(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] |= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator |(VectorLong thisVector, int scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] = (int)thisVector.longArray[i] | scalar;

            return thisVector;
        }

        public static VectorLong operator &(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] &= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator &(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] &= scalar;

            return thisVector;
        }

        public static VectorLong operator ^(VectorLong thisVector, VectorLong vector)
        {
            for (int i = 0; i < thisVector.size && i < vector.size; i++)
                thisVector.longArray[i] ^= vector.longArray[i];

            return thisVector;
        }

        public static VectorLong operator ^(VectorLong thisVector, long scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] ^= scalar;

            return thisVector;
        }

        public static VectorLong operator >>(VectorLong thisVector, int scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] >>= scalar;

            return thisVector;
        }

        public static VectorLong operator <<(VectorLong thisVector, int scalar)
        {
            for (int i = 0; i < thisVector.size; i++)
                thisVector.longArray[i] <<= scalar;

            return thisVector;
        }

        public static bool operator ==(VectorLong thisVector, VectorLong comparedVector)
        {
            if (thisVector.size != comparedVector.size)
                return false;

            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] != comparedVector.longArray[i])
                    return false;

            return true;
        }

        public static bool operator !=(VectorLong thisVector, VectorLong comparedVector)
        {
            if (thisVector.size != comparedVector.size)
                return true;

            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] != comparedVector.longArray[i])
                    return true;

            return false;
        }

        public static bool operator >(VectorLong thisVector, VectorLong comparedVector)
        {
            if (thisVector.size > comparedVector.size)
                return true;

            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] <= comparedVector.longArray[i])
                    return false;

            return true;
        }

        public static bool operator <(VectorLong thisVector, VectorLong comparedVector)
        {
            if (thisVector.size < comparedVector.size)
                return true;

            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] >= comparedVector.longArray[i])
                    return false;

            return true;
        }

        public static bool operator >=(VectorLong thisVector, VectorLong comparedVector)
        {
            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] < comparedVector.longArray[i])
                    return false;

            if (thisVector.size >= comparedVector.size)
                return true;

            return true;
        }

        public static bool operator <=(VectorLong thisVector, VectorLong comparedVector)
        {
            for (int i = 0; i < thisVector.size; i++)
                if (thisVector.longArray[i] > comparedVector.longArray[i])
                    return false;

            if (thisVector.size <= comparedVector.size)
                return true;

            return true;
        }
    }
}
