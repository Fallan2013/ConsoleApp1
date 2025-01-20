using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml;


//Меню
//переработать
//подсчет уровня
//частота выпадения цифр на кубиках
//частота сумм бросков
//самая частая цифра и сумма
//  12; 15,16;14,11; 13; 12;
namespace R20
{
    class Program
    {
        #region Method
        public string Gurps_Throw(int skill_value, string statistic)
        {
            int chek_result = new int();
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

            var output_result = string.Join("/", a, b, c, chek_result); ;
            // Console.WriteLine(output_result);
            return output_result;

        }
        #endregion
        /*public string Output(string str)
        {   
            Console.WriteLine();
            return "asdas";
        }*/
        //public int[] processing(int [] statistic)
        //{   

        //    return statistic;
        //}
        static void Main(string[] args)
        {
            int[] num_value = new int[4]; // [0] - количество крит провалов; [1] - количество провалов; [2] - количество успехов;[3] - количество крит успехов;
            string result;
            Program test_throw = new Program();
            Console.WriteLine("Введите количество бросков");
            if (Int32.TryParse(Console.ReadLine(), out int counter))
            {

                Console.WriteLine("Значение эффективного навыка: ");
                int i = 0;
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    string str_method = Console.ReadLine();
                    while (i < counter)
                    {
                        result = (test_throw.Gurps_Throw(input, str_method));
                        char[] chars = result.ToCharArray();
                        int[] int_array = new int[10];

                        for (int n = 0; n < chars.Length; n += 2)
                        {
                            int_array[n / 2] = Convert.ToInt32(char.GetNumericValue(chars[n]));
                            //Console.Write(int_array[n / 2]);
                        }
                        for (int k = -1; k <= 2; k++)
                        {
                            if (int_array[3] == k)
                            {
                                num_value[k + 1] += 1;
                            }
                        }

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


            Console.WriteLine($"Количество критических провалов: {num_value[0]}");
            Console.WriteLine($"Количество провалов : {num_value[1]}");
            Console.WriteLine($"Количество успехов : {num_value[2]}");
            Console.WriteLine($"Количество критических успехов: {num_value[3]}");
            Console.ReadKey();
        }

    }

}