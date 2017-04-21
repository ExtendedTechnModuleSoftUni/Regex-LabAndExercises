namespace _07ME.Chain
{
    using System;
    using System.IO;
    using System.Text;

    public class Chain
    {
        public static void Main()
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var htmlText = Console.ReadLine();
            var startTag = "<p>";
            var endTag = "</p>";
            var startIndex = htmlText.ToString().IndexOf(startTag);
            var endIndex = htmlText.ToString().IndexOf(endTag);
            var currentString = "";
            var sb = new StringBuilder();

            while (startIndex != -1)
            {
                currentString = htmlText.ToString().Substring(startIndex + 3, (endIndex - startIndex) - 3);

                AppendString(currentString, sb);

                startIndex = htmlText.IndexOf(startTag, startIndex + 3);

                if (startIndex < 0)
                {
                    continue;
                }

                endIndex = htmlText.IndexOf(endTag, startIndex + 3);
            }

            Console.WriteLine(sb.ToString());
        }

        static void AppendString(string currentString, StringBuilder sb)
        {
            var spaceCounter = 0;

            for (int i = 0; i < currentString.Length; i++)
            {
                if (currentString[i] >= 97 && currentString[i] < 123)
                {
                    spaceCounter = 0;

                    GetLetters(currentString, sb, i);
                }
                else if (currentString[i] >= 48 && currentString[i] < 58)
                {
                    spaceCounter = 0;

                    sb.Append(currentString[i]);
                }
                else
                {
                    spaceCounter++;

                    if (spaceCounter < 2)
                    {
                        sb.Append(' ');
                    }
                }
            }
        }

        static void GetLetters(string currentString, StringBuilder sb, int i)
        {
            switch (currentString[i])
            {
                case 'a':
                    sb.Append('n');
                    break;
                case 'b':
                    sb.Append('o');
                    break;
                case 'c':
                    sb.Append('p');
                    break;
                case 'd':
                    sb.Append('q');
                    break;
                case 'e':
                    sb.Append('r');
                    break;
                case 'f':
                    sb.Append('s');
                    break;
                case 'g':
                    sb.Append('t');
                    break;
                case 'h':
                    sb.Append('u');
                    break;
                case 'i':
                    sb.Append('v');
                    break;
                case 'j':
                    sb.Append('w');
                    break;
                case 'k':
                    sb.Append('x');
                    break;
                case 'l':
                    sb.Append('y');
                    break;
                case 'm':
                    sb.Append('z');
                    break;
                case 'n':
                    sb.Append('a');
                    break;
                case 'o':
                    sb.Append('b');
                    break;
                case 'p':
                    sb.Append('c');
                    break;
                case 'q':
                    sb.Append('d');
                    break;
                case 'r':
                    sb.Append('e');
                    break;
                case 's':
                    sb.Append('f');
                    break;
                case 't':
                    sb.Append('g');
                    break;
                case 'u':
                    sb.Append('h');
                    break;
                case 'v':
                    sb.Append('i');
                    break;
                case 'w':
                    sb.Append('j');
                    break;
                case 'x':
                    sb.Append('k');
                    break;
                case 'y':
                    sb.Append('l');
                    break;
                case 'z':
                    sb.Append('m');
                    break;
            }
        }
    }
}
