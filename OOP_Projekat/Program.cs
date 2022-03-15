using System.Diagnostics;

namespace OOP_Projekat
{
    class GeneralizovanaLista
    {
        private const int DefaultSize = 100;
        private object[] data;
        private int numElements = 0;

        public object[] Data
        {
            get { return data; }
        }

        public int Length
        {
            get { return numElements; }
        }

        public GeneralizovanaLista()
        {
            this.data = new object[DefaultSize];
        }

        public GeneralizovanaLista(int size)
        {
            if (size > 0)
                this.data = new object[size];
            else
                throw new ArgumentOutOfRangeException("size", "Must be greater than zero");
        }

        public void Add(object item)
        {
            if (this.numElements == this.data.Length)
                throw new Exception("List is full");
            this.data[numElements] = item;
            numElements++;
        }

        public void RemoveAt(int position)
        {
            for (int i = position; i < numElements - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.data[numElements - 1] = null;
            numElements--;
        }
    }

    class GenerickaLista<T>
    {
        private const int DefaultSize = 100;
        private T[] data;
        private int numElements = 0;

        public T[] Data
        {
            get { return data; }
        }

        public int Length
        {
            get { return numElements; }
        }

        public GenerickaLista()
        {
            this.data = new T[DefaultSize];
        }

        public GenerickaLista(int size)
        {
            if (size > 0)
                this.data = new T[size];
            else
                throw new ArgumentOutOfRangeException("size", "Must be greater than zero");
        }

        public void Add(T item)
        {
            if (this.numElements == this.data.Length)
                throw new Exception("List is full");
            this.data[numElements] = item;
            numElements++;
        }

        public void RemoveAt(int position)
        {
            for (int i = position; i < numElements - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.data[numElements - 1] = default(T);
            numElements--;
        }
    }

    class Tacka
    {
        public int x { get; set; }
        public int y { get; set; }

        public Tacka(int x1, int y1)
        {
            x = x1;
            y = y1;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            GeneralizovanaLista lista = new GeneralizovanaLista(4);
            lista.Add(new Tacka(1, 2));
            lista.Add(new Tacka(2, 3));
            lista.Add(new Tacka(3, 4));
            lista.Add(new Tacka(4, 5));
            lista.RemoveAt(2);
            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine((Tacka)lista.Data[i]);
            }
            st.Stop();
            TimeSpan ts = st.Elapsed;
            Console.WriteLine(ts);
            //---------------------------------------
            Stopwatch st1 = new Stopwatch();
            st1.Start();
            GenerickaLista<Tacka> lista1 = new GenerickaLista<Tacka>(4);
            lista1.Add(new Tacka(1, 2));
            lista1.Add(new Tacka(2, 3));
            lista1.Add(new Tacka(3, 4));
            lista1.Add(new Tacka(4, 5));
            lista1.RemoveAt(2);
            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine(lista.Data[i]);
            }
            st1.Stop();
            TimeSpan ts1 = st1.Elapsed;
            Console.WriteLine(ts1);
        }
    }
}