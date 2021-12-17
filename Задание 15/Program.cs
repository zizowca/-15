using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_15
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithProgression arith = new ArithProgression();
            GeomProgression geom = new GeomProgression();
            Console.Write("Введите значение первого члена прогрессии x:\t");
            arith.setStart(arith.X = Convert.ToInt32(Console.ReadLine()));
            geom.X = arith.X;
            Console.Write("Введите значение шага арифмитической прогресии d:\t");
            arith.setStart(arith.D = Convert.ToInt32(Console.ReadLine()));
            Console.Write("Введите значение знаменателя геометрической прогресии q:\t");
            geom.setStart(geom.Q = Convert.ToInt32(Console.ReadLine()));
            Console.Write("Какой по счету член арифмитческой прогрессии вы хотите посмотреть (выберите от 1 до 10)");
            arith.AN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Это число {0}", arith.getNext());
            Console.Write("Какой по счету член геометричсекой прогрессии вы хотите посмотреть (выберите от 1 до 10)");
            geom.GN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Это число {0}", geom.getNext());
            Console.ReadKey();
        }
    }
    interface ISeries
    {
        void setStart(int x);
        int getNext();
        void reset();
    }
    class ArithProgression : ISeries
    {
        int x;
        const int n = 10; //длина прогрессии. Я хотела, чтобы значение длины массива указывалось пользователем, но с const нельзя оставить это поле без значение, а без const С# ругается
        int[] arith = new int[n]; // массив для прогрессии
        public int AN { get; set; } //порядковый номер члена прогрессии, который нужно вывести
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int D { get; set; }// шаг прогрессии
        public void setStart(int x)
        {
        }
        public int getNext()
        {
            for (int i = 1; i < 10; i++)
            {
                arith[0] = X;
                arith[i] = arith[i - 1] + D;
            }
            return arith[AN - 1];// AN-1 - чтобы не запутаться с номером члена прогрессии, так как в массиве нумерарация начинается с ноля, а вводить порядковый номер я буду запрашивать начиная с 1
            // еще я не поняла, как здесь вывести просто весь массив, когда пишу в коде return arith[N] или return arith[] у меня выскакивают ошибки.
            // Как понимаю, в этом методе выводится какое-то конкретное значение через return, а чтобы вывесьти весь массив нужно создавать метод void и в нем уже выводить массив, используя Console.WriteLine
        }
        public void reset()
        {
            Console.WriteLine("Первый член прогрессии:{}", X);// Не понимаю. зачем мне это метод, так как первый член прогрессии в моем случае вводится пользователем, не вижу смысла выводить его снова на консоль
        }
    }
    class GeomProgression : ISeries
    {
        int x;
        const int n = 10; //длина прогрессии
        int[] geom = new int[n];//массив для геометрической прогрессии
        public int GN { get; set; } //член прогрессии, который нужно вывести 
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }}
        public int Q { get; set; }
        //я ниже зписала условия, чтобы выводилось сообщение об ошибке при вводе недопустимых значение Q, но C# ругается, а я не понимаю, почему
        //{
        //    set
        //    {
        //        if (Q == 0)
        //        {
        //            Console.WriteLine("недопустимое значение знаменателя прогрессии");
        //        }
        //        else if (Q == 1)
        //        {
        //            Console.WriteLine("недопустимое значение знаменателя прогрессии");
        //        }
        //        else
        //        {
        //            Q = value;
        //        }
        //    }
        //    get
        //    {
        //        return Q;
        //    }
        //}
        public void setStart(int x)
        {
        }
        public int getNext()
        { for (int i = 1; i < 10; i++)
            {
                geom[0] = X;
                geom[i] = geom[i - 1] * Q;

            }
            return geom[GN - 1];// GN-1 - чтобы не запутаться с номером члена прогрессии, так как в массиве нумерарация начинается с ноля, а вводить порядковый номер я буду запрашивать начиная с 1
        }
        public void reset()
        {
            Console.WriteLine("Первый член прогрессии:{}", X);
        }
    }
}
