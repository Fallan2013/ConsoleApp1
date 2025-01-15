using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml;


namespace R20
{
    class Program
    {
        #region Method
        public string Gurps_Throw(int skill_value, string statistic )
        {
            int chek_result = new int();
            /* int[] sucsess_result = new int[throw_counter];
             int[] failure_result = new int[throw_counter];
             int[] critsucsess_result = new int[throw_counter];
             int[] critfalure_result = new int[throw_counter];*/
            var rand = new Random();

            int a = rand.Next(1, 7);
            int b = rand.Next(1, 7);
            int c = rand.Next(1, 7);
            int rand_sum = a + b + c;
            int result = skill_value - rand_sum;


            if ((result >= 0) && (rand_sum < 17))
            {
                if ((rand_sum <= 4 && skill_value >= 14) | (rand_sum <= 5 && skill_value >= 15) | (rand_sum <= 6 && skill_value >= 16))
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
                if ((rand_sum == 18) || (rand_sum == 17 && skill_value <= 15) | (result <= -10 & skill_value < 10))
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
           
            var output_result = string.Join("/",a,b,c,chek_result); ;
            return output_result;

           
        }
        #endregion
        /*public string Output(string str)
        {   
            Console.WriteLine();
            return "asdas";
        }*/
        public string processing(string statistic)
        {
            return statistic ;
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
                    string? str_method = Console.ReadLine(); 
                    while (i < counter)
                    {
                        string result =(test_throw.Gurps_Throw(input, str_method));
                        i++;
                        Console.WriteLine(result);
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


