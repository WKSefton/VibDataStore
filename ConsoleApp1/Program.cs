using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! 2");
            Task.Run(() => new Client().Run()).GetAwaiter().GetResult();
        }
    }

    public class MHmaxRingBuffer
    {
        int Head { get; set; } = 0;
        int Tail { get; set; } = 0;
        bool Filled = false;
        float[] Buffer { get; set; }
        public MHmaxRingBuffer(int length)
        {
            this.Buffer = new float[length];
        }
        public void Push(float value)
        {
            this.Buffer[this.Head] = value;

            if (++this.Head == this.Buffer.Length)
            {
                this.Filled = true;
                this.Head = 0;
            }

            if (this.Head == this.Tail)
                if (++this.Tail == this.Buffer.Length)
                    this.Tail = 0;

            this.Print();
        }

        public float Pop()
        {
            float ret = float.NaN;

            if (this.Tail + 1 != this.Head)
            {
                ret = this.Buffer[this.Tail];
                this.Buffer[this.Tail] = float.NaN;

                if (++this.Tail == this.Buffer.Length)
                    this.Tail = 0;
            }

            this.Print();
            return ret;
        }

        public float[] Dump()
        {
            float[] ret = new float[this.Buffer.Length];

            //int indexesLeft = this.Buffer.Length - this.Head;
            //int readStart = this.Tail;
            //int currentIndex = this.Head;
            this.Print();

            if (this.Filled)
            {
                Array.Copy(this.Buffer, this.Head, ret, 0, this.Buffer.Length - this.Head);
                Array.Copy(this.Buffer, 0, ret, this.Buffer.Length - this.Head, this.Head);
            }
            else
            {
                Array.Copy(this.Buffer, 0, ret, 0, this.Head);
                Array.Copy(this.Buffer, this.Head, ret, this.Head, this.Buffer.Length - this.Head);
            }
            return ret;


        }

        public void Print()
        {
            Console.WriteLine($"Head: {this.Head} -- Tail: {this.Tail}");
        }
    }


}
