using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ahorcado
{
    class PlayerStartcs
    {
        public int Healths = 4;
        public char letter;
        public int SaveRandom = 0;
        public string noYes = "";
        public string YesNoTwo = "";
        public bool lose1 = false;
        public bool lose2 = false;
        public bool lose3 = false;
        public bool lose4 = false;
        public string[] formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
        public string[] format4character = new string[]
            {
                "*", "*", "*", "*"
            };
        public string[] format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
        public string[] format8Character = new string[]
        {
                "*", "*", "*", "*", "*", "*", "*", "*"
        };
        public List<string> words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
        public List<int> wordsIds = new List<int>() { 0, 1, 2, 3, 4, 5 };
        public void Start()
        {
            WelcomeFormat();
        }
        public void Verification()
        {
            Random rnd = new Random();
            SaveRandom = rnd.Next(wordsIds[0], wordsIds[3]);
            words[0] = "";
            words[1] = "";
            words[2] = "";
            words[3] = "";
            words[4] = "";
            words[5] = "";
            if (SaveRandom == wordsIds[0])
            {
                for (int i = 0; i < 4; i++)
                {
                    words[0] += "*";
                }
                Format4Character();
            }
            else if (SaveRandom == wordsIds[1])
            {
                for (int i = 0; i < 5; i++)
                {
                    words[1] += "*";
                }
                Format5Character();
            }
            else if (SaveRandom == wordsIds[2])
            {
                for (int i = 0; i < 8; i++)
                {
                    words[2] += "*";
                }
                Format8Character();
            }
            else if (SaveRandom == wordsIds[3])
            {
                for (int i = 0; i < 12; i++)
                {
                    words[3] += "*";
                }
            }
            else if (SaveRandom == wordsIds[4])
            {
                for (int i = 0; i < 6; i++)
                {
                    words[4] += "*";
                }
            }
            else if (SaveRandom == wordsIds[5])
            {
                for (int i = 0; i < 4; i++)
                {
                    words[5] += "*";
                }
            }
        }
        public void WelcomeFormat()
        {
            Console.WriteLine("------------------------------------"
+ "\n|                                  |");
            Console.WriteLine("|       {0}  {1}  {2}  {3}  {4}  {5}  {6}        |", "W", "E", "L", "C", "O", "M", "E");
            Console.WriteLine("|       -  -  -  -  -  -  -        |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n" +
                              "------------------------------------"
                          );
            Console.WriteLine("Presiona la tecla Y para continuar....");
            string yesNo = Console.ReadLine();
            if (yesNo == "Y" || yesNo == "y")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void FailedHealth()
        {
            if (Healths == 3 && lose1 == false)
            {
                lose1 = true;
                formatLose[0] += "|";
                formatLose[1] += "_";
                formatLose[2] += "|";
                formatLose[3] += "_";
                formatLose[4] += "|";
                formatLose[5] += "|";
            }

            if (Healths == 2 && lose2 == false && lose1 == true)
            {
                lose2 = true;
                formatLose[6] += "|";
                formatLose[7] += "_";
                formatLose[8] += "_";
                formatLose[9] += "_";
                formatLose[10] += "|";
                formatLose[11] += "/";
            }
            if (Healths == 1 && lose3 == false && lose2 == true && lose1 == true)
            {
                lose3 = true;
                formatLose[12] += "|";
                formatLose[13] += "\\";
                formatLose[14] += "|";
                formatLose[15] += "|";
                formatLose[16] += "/";
            }
            if (Healths < 1 && lose4 == false && lose2 == true && lose1 == true && lose3 == true)
            {
                lose4 = true;
                formatLose[17] += "\\";
                Failed();
            }
        }
        public void Format4Character()
        {
            FailedHealth();
            Console.WriteLine("La palabra a adivinar es: {0}", words[0]);
            Console.WriteLine("Y contiene {0} letras", words[0].Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------"
+ "\n|                                  ");
            Console.WriteLine("|            {0}  {1}  {2}  {3}       ", format4character[0], format4character[1], format4character[2], format4character[3]);
            Console.WriteLine("|            -  -  -  -               "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}            "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4], 
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9], 
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            Console.WriteLine("Ingrese una letra: ");
            try
            {
                letter = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Solo puedes ingresar una letra");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Format4Character();
            }
            if (letter == 'h' || letter == 'H')
            {
                format4character[0] = "H";
                Console.Clear();
                GameWin();
            }
            else if(letter == 'o' || letter == 'O')
            {
                format4character[1] = "O";
                Console.Clear();
                GameWin();
            }
            else if (letter == 'l' || letter == 'L')
            {
                format4character[2] = "L";
                Console.Clear();
                GameWin();
            }
            else if (letter == 'a' || letter == 'A')
            {
                format4character[3] = "A";
                Console.Clear();
                GameWin();
            }
            else
            {
                Healths--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Letra incorrecta, intentalo de nuevo!   |   ");
                Console.Write("Te quedan");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" {0}", Healths);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" intentos");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Console.Clear();
                Format4Character();
            }
        }
        public void Failed()
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine("Has perdido y te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|            {0}  {1}  {2}  {3}            ", "L", "O", "S", "E");
                Console.WriteLine("|            -  -  -  -           "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18

            string noYes = Console.ReadLine();
            
            if (noYes == "Y" || noYes == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format4character = new string[]
            {
                "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void Format5Character()
        {
            FailedHealth();
            Console.WriteLine("La palabra a adivinar es: {0}", words[1]);
            Console.WriteLine("Y contiene {0} letras", words[1].Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------"
+ "\n|                                  ");
            Console.WriteLine("|         {0}  {1}  {2}  {3}  {4}            ", format5Character[0], format5Character[1], format5Character[2], format5Character[3], format5Character[4]);
            Console.WriteLine("|         -  -  -  -  -               "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}            "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            Console.WriteLine("Ingrese una letra: ");
            try
            {
                letter = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Solo puedes ingresar una letra");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Format5Character();
            }
            if (letter == 'm' || letter == 'M')
            {
                format5Character[0] = "M";
                Console.Clear();
                GameWin2();
            }
            else if (letter == 'u' || letter == 'U')
            {
                format5Character[1] = "U";
                Console.Clear();
                GameWin2();
            }
            else if (letter == 'n' || letter == 'N')
            {
                format5Character[2] = "N";
                Console.Clear();
                GameWin2();
            }
            else if (letter == 'd' || letter == 'D')
            {
                format5Character[3] = "D";
                Console.Clear();
                GameWin2();
            }
            else if (letter == 'o' || letter == 'O')
            {
                format5Character[4] = "O";
                Console.Clear();
                GameWin2();
            }
            else
            {
                Healths--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Letra incorrecta, intentalo de nuevo!   |   ");
                Console.Write("Te quedan");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" {0}", Healths);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" intentos");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Console.Clear();
                Format5Character();
            }
        }
        public void GameWin()
        {
            if (format4character[0] == "H" && format4character[1] ==  "O"
               && format4character[2] == "L" && format4character[3] == "A")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: H O L A");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format4Character();
            }
            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format4character = new string[]
            {
                "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void GameWin2()
        {
            if (format5Character[0] == "M" && format5Character[1] == "U"
&& format5Character[2] == "N" && format5Character[3] == "D" && format5Character[4] == "O")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: M U N D O");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format5Character();
            }

            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void GameWin3()
        {
            if (format8Character[0] == "A" && format8Character[1] == "H"
&& format8Character[2] == "O" && format8Character[3] == "R" && format8Character[4] == "C" && format8Character[5] == "A"
&& format8Character[6] == "D" && format8Character[7] == "O")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: A H O R C A D O");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format8Character();
            }

            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format8Character = new string[]
            {
                "*", "*", "*", "*", "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void GameWin4()
        {
            if (format5Character[0] == "M" && format5Character[1] == "U"
&& format5Character[2] == "N" && format5Character[3] == "D" && format5Character[4] == "O")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: M U N D O");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format5Character();
            }

            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format4character = new string[]
            {
                "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void GameWin5()
        {
            if (format5Character[0] == "M" && format5Character[1] == "U"
&& format5Character[2] == "N" && format5Character[3] == "D" && format5Character[4] == "O")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: M U N D O");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format5Character();
            }

            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format4character = new string[]
            {
                "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void GameWin6()
        {
            if (format5Character[0] == "M" && format5Character[1] == "U"
&& format5Character[2] == "N" && format5Character[3] == "D" && format5Character[4] == "O")
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("La palabra correcta es: M U N D O");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Has ganado y no te has ahorcado!   |  Reiniciar? Y/N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------"
+ "\n|                                  ");
                Console.WriteLine("|           {0}  {1}  {2}  {3} {4}            ", "W", "I", "N", "E", "R");
                Console.WriteLine("|          -  -  -  -  -         "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}          "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            }
            else
            {
                Format5Character();
            }

            YesNoTwo = Console.ReadLine();
            if (YesNoTwo == "Y" || YesNoTwo == "y")
            {
                Healths = 4;
                lose1 = false;
                lose2 = false;
                lose3 = false;
                lose4 = false;
                formatLose = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
            };
                format4character = new string[]
            {
                "*", "*", "*", "*"
            };
                words = new List<string>() { "hola", "mundo", "ahorcado", "programacion", "visual", "vsC#" };
                format5Character = new string[]
            {
                "*", "*", "*", "*", "*"
            };
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading party....");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
        public void Format8Character()
        {

            FailedHealth();
            Console.WriteLine("La palabra a adivinar es: {0}", words[2]);
            Console.WriteLine("Y contiene {0} letras", words[2].Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------"
+ "\n|                                  ");
            Console.WriteLine("|    {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}        ", format8Character[0], format8Character[1], format8Character[2], format8Character[3], format8Character[4], format8Character[5], format8Character[6], format8Character[7]);
            Console.WriteLine("|    -  -  -  -  -  -  -  -               "
                          + "\n|                 {0}                 "
                          + "\n|                {1}{2}{3}            "
                          + "\n|               {4}   {5}             "
                          + "\n|               {6}{7}{8}{9}{10}      "
                          + "\n|                {11}{12}{13}         "
                          + "\n|                 {14}                "
                          + "\n|                 {15}                "
                          + "\n|                {16} {17}            "
                          + "\n" +
                              "------------------------------------"
                          , formatLose[0], formatLose[1], formatLose[2], formatLose[3], formatLose[4],
                          formatLose[5], formatLose[6], formatLose[7], formatLose[8], formatLose[9],
                          formatLose[10], formatLose[11], formatLose[12], formatLose[13], formatLose[14]
                          , formatLose[15], formatLose[16], formatLose[17]); //18
            Console.WriteLine("Ingrese una letra: ");
            try
            {
                letter = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Solo puedes ingresar una letra");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Console.Clear();
                Format8Character();
            }
            if (letter == 'a' || letter == 'A')
            {
                format8Character[0] = "A";
                format8Character[5] = "A";
                Console.Clear();
                GameWin3();
            }
            else if (letter == 'h' || letter == 'H')
            {
                format8Character[1] = "H";
                Console.Clear();
                GameWin3();
            }
            else if (letter == 'o' || letter == 'O')
            {
                format8Character[2] = "O";
                format8Character[7] = "O";
                Console.Clear();
                GameWin3();
            }
            else if (letter == 'r' || letter == 'R')
            {
                format8Character[3] = "R";
                Console.Clear();
                GameWin3();
            }
            else if (letter == 'c' || letter == 'C')
            {
                format8Character[4] = "C";
                Console.Clear();
                GameWin3();
            }
            else if (letter == 'd' || letter == 'D')
            {
                format8Character[6] = "D";
                Console.Clear();
                GameWin3();
            }
            else
            {
                Healths--;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Letra incorrecta, intentalo de nuevo!   |   ");
                Console.Write("Te quedan");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" {0}", Healths);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" intentos");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Console.Clear();
                Format8Character();
            }
        }
        public void Format6Character()
        {
            string[] Format6Character = new string[]
            {
                "", "", "", "", "", "", "", ""
            };

            Console.WriteLine("------------------------------------"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n" +
                              "------------------------------------"
                          );
        }
        public void Format12Character()
        {

            string[] format12Character = new string[]
            {
                "", "", "", "", "", "", "", "", "", "", "", ""
            };

            Console.WriteLine("------------------------------------"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n|                                  |"
                          + "\n" +
                              "------------------------------------"
                          );
        }
    }
}
