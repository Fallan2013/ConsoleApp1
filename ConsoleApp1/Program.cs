using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R20
{
    class Program
    {
        public int Gurps_Throw(int skill_value, int throw_counter)
        {
            int chek_result = new int();


            var rand = new Random();

            int a = rand.Next(1, 7);
            int b = rand.Next(1, 7);
            int c = rand.Next(1, 7);
            int Sum = a + b + c;
            int result = skill_value - Sum;



            if ((result >= 0) && (Sum < 17))
            {
                if ((Sum <= 4 && skill_value >= 14) | (Sum <= 5 && skill_value >= 15) | (Sum <= 6 && skill_value >= 16))
                {
                    //Console.WriteLine($"Критический успех!");
                    chek_result = 2;
                }
                else
                {
                    //Console.WriteLine($"Успех!");
                    chek_result = 1;
                }
            }
            else
            {
                if ((Sum == 18) || (Sum == 17 && skill_value <= 15))
                {
                    //Console.WriteLine($"Критический провал!");
                    chek_result = -1;
                }
                else
                {
                    //Console.WriteLine($"Провал");
                    chek_result = 0;
                }

            }
            Console.WriteLine($"Результат броска: {skill_value}-({a},{b},{c})/");
            throw_counter--;

            return chek_result;
        }




        static void Main(string[] args)
        {
            Program test_throw = new Program();
            //int Skill_current_level = new int();
            Console.WriteLine("Введите количество бросков");
            if (Int32.TryParse(Console.ReadLine(), out int counter))
            {
                Console.WriteLine("Значение эффективного навыка: ");
                int i = 0;


                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    while (i < counter)
                    {
                        Console.Write(test_throw.Gurps_Throw(input, counter));

                        i++;

                    }
                }
                else
                {
                    Console.WriteLine("Введите целочисленное число.");
                }


            }
            else
            {
                Console.WriteLine("Введите целочисленное число");
            }
            Console.ReadKey();
            


        }

    }

}