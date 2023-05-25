using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnhQuoc_OOP_C5_B2
{
    class Utilities
    {
        public static void ClearfReceipt()
        {
            XmlProvider.Open(Constants.fReceipts);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fReceiptDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataReceipts);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataReceiptDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }

        public static void ClearfInvoice()
        {
            XmlProvider.Open(Constants.fInvoices);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fInvoiceDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataInvoices);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataInvoiceDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }
        public static void ClearfProductInvoice()
        {
            XmlProvider.Open(Constants.fProductInvoices);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataProductInvoices);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }
        public static void ClearfProductInvoiceOrder()
        {
            XmlProvider.Open(Constants.fDataProductInvoicesOrder);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }

        public static void ClearfInventory()
        {
            XmlProvider.Open(Constants.fInventory);
            RemoveAllChilds(XmlProvider.nodeRoot.FirstChild);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataInventory);
            RemoveAllChilds(XmlProvider.nodeRoot.FirstChild);
            XmlProvider.Close();
        }
        public static void ClearfProductInventory()
        {
            XmlProvider.Open(Constants.fProductInventorys);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataProductInventorys);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }
        public static void ClearfProductInventoryStatus()
        {
            XmlProvider.Open(Constants.fProductInventorysStatus);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataProductInventorysStatus);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }

        public static void ClearfProductImportInventory()
        {
            XmlProvider.Open(Constants.fDataImportInventory);
            RemoveAllChilds(XmlProvider.nodeRoot.FirstChild);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataProductImportInventorysStatus);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }

        public static void ClearfOrder()
        {
            XmlProvider.Open(Constants.fOrders);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fOrderDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataOrders);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataOrderDetails);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }
        public static void ClearfCustomer()
        {
            XmlProvider.Open(Constants.fDataCustomers);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();

            XmlProvider.Open(Constants.fDataGuests);
            RemoveAllChilds(XmlProvider.nodeRoot);
            XmlProvider.Close();
        }

        public static void ClearAllFile()
        {
            ClearfReceipt();

            ClearfInvoice();
            ClearfProductInvoice();
            ClearfProductInvoiceOrder();

            ClearfInventory();
            ClearfProductInventory();
            ClearfProductInventoryStatus();

            ClearfProductImportInventory();

            ClearfOrder();
            ClearfCustomer();
        }

        public static void Stop(ConsoleKey keyContinue)
        {
            while (Console.ReadKey(true).Key != keyContinue) ;
        }
        public static List<ProductInventory> CopyProductInvens(List<ProductInventory> source)
        {
            List<ProductInventory> dest = new List<ProductInventory>();

            foreach (ProductInventory item in source)
            {
                ProductInventory newItem = new ProductInventory();
                newItem.Product.Id = item.Product.Id;
                newItem.Product.Name = item.Product.Name;
                newItem.Product.Category = item.Product.Category;
                newItem.Product.Producer = item.Product.Producer;
                newItem.Product.Price.In = item.Product.Price.In;
                newItem.Product.Price.Out = item.Product.Price.Out;

                if (item.Product is Electronic)
                {
                    newItem.Product.ElectricPower = item.Product.ElectricPower;
                    newItem.Product.Warranty = item.Product.Warranty;
                }
                if (item.Product is Porcelain)
                {
                    newItem.Product.Material = item.Product.Material;
                }
                if (item.Product is Food)
                {
                    newItem.Product.MfgDate = item.Product.MfgDate;
                    newItem.Product.ExpDate = item.Product.ExpDate;
                }

                newItem.Quantity = item.Quantity;

                newItem.Price.In = item.Price.In;
                newItem.Price.Out = item.Price.Out;

                dest.Add(newItem);
            }
            return dest;
        }
        public static void RemoveAllChilds(XmlNode parentNode)
        {
            XmlNodeList lstChild = parentNode.ChildNodes;
            while (lstChild.Count > 0)
            {
                parentNode.RemoveChild(lstChild[0]);
            }
        }
        public static int ConvertToInt(string number)
        {
            number = number.Replace(".", "");
            return int.Parse(number);
        }
        public static string GetIsExistMessage(bool isExist, string item)
        {
            string result = string.Empty;
            if (isExist)
                result = string.Format("This {0} already exists in the list", item);
            else
                result = string.Format("This {0} is currently not in the list", item);
            return result;
        }
        public static void NotifyAvailable(string item, string lstName, bool isClearScreen, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            WriteLine($"There are no {item} in the {lstName}.", color);
            if (isClearScreen)
            {
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        public static string ErrorStr(string errorDescription)
        {
            return "Error {0} Can not continue this operation";
        }
        private static string GetLowerString(string value)
        {
            return char.ToLower(value[0]).ToString() + value.Substring(1);
        }
        public static bool ConfirmationView(string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.Write("\n" + message);
            return GetYNOptionKey();
        }
        public static void GoTo(List<int> lengths, int index)
        {
            for (int i = 0; i < index; i++)
            {
                try {
                    Console.CursorLeft += lengths[i] + 3;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                    return;
                }
            }
        }
        public static List<int> GetFixLengths(List<int> lengths, int cdX)
        {
            List<int> result = new List<int>();
            int newValue = cdX;
            newValue += 2;
            foreach (int len in lengths)
            {
                result.Add(newValue);
                newValue += len + 3;
            }
            result.Add(newValue);
            return result;
        }
        public static void InsertRange(List<string> source, int index, List<string> collection)
        {
            foreach (var item in collection)
            {
                source.Insert(index, item);
                index++;
            }
        }
        public static void InsertRange<T>(List<T> source, int index, List<T> collection)
        {
            foreach (var item in collection)
            {
                source.Insert(index, item);
                index++;
            }
        }
        public static void AppendRange<T>(List<T> source, List<T> collection)
        {
            foreach (var item in collection)
            {
                source.Add(item);
            }
        }
        public static void InsertRange(List<int> source, int index, List<int> collection)
        {
            foreach (var item in collection)
            {
                source.Insert(index, item);
                index++;
            }
        }
        public static void InsertRange(List<object> source, int index, List<object> collection)
        {
            foreach (var item in collection)
            {
                source.Insert(index, item);
                index++;
            }
        }
        public static Coord GetCurrentCursorPosition()
        {
            return new Coord(Console.CursorLeft, Console.CursorTop);
        }

        public static void ClearToRight(int length)
        {
            DrawToRight(length, ' ');
        }
        public static void ClearToRight()
        {
            ClearToRight(Console.BufferWidth - Console.CursorLeft);
        }

        public static void ClearToLeft(int length)
        {
            DrawToLeft(length, ' ');
        }
        public static void ClearToLeft()
        {
            ClearToLeft(Console.CursorLeft);
        }

        public static void ClearLine()
        {
            ClearToRight();
            ClearToLeft();
        }

        public static void DrawToRight(int length, char c_draw)
        {
            Coord cd = GetCurrentCursorPosition();
            Console.Write(string.Empty.PadLeft(length, c_draw));
            Console.SetCursorPosition(cd.X, cd.Y);
        }
        public static void DrawToLeft(int length, char c_draw)
        {
            Coord cd = GetCurrentCursorPosition();

            Console.CursorLeft = 0;

            Console.Write(string.Empty.PadLeft(length, c_draw));
            Console.SetCursorPosition(cd.X, cd.Y);
        }
        public static void DrawToTop(int length, char c_draw)
        {
            Coord cd = GetCurrentCursorPosition();
            int tempCdY = cd.Y;
            Write(c_draw.ToString());
            for (int idx = 1; idx < length; idx++)
            {
                try
                {
                    Console.CursorLeft = cd.X;
                    Console.CursorTop = --tempCdY;
                }
                catch { return; }
                Write(c_draw.ToString());
            }
            Console.SetCursorPosition(cd.X, cd.Y);
        }
        public static void DrawToBottom(int length, char c_draw)
        {
            Coord cd = GetCurrentCursorPosition();
            int tempCdY = cd.Y;
            Write(c_draw.ToString());
            for (int idx = 1; idx < length; idx++)
            {
                try
                {
                    Console.CursorLeft = cd.X;
                    Console.CursorTop = ++tempCdY;
                }
                catch { return; }
                Write(c_draw.ToString());
            }
            Console.SetCursorPosition(cd.X, cd.Y);
        }

        public static void DrawRectangle(int width, int height, char rowChar, char colChar)
        {
            Coord currentPos = GetCurrentCursorPosition();
            DrawToRight(width, rowChar);
            try { Console.CursorTop += (height - 1); }
            catch { return; }
            DrawToRight(width, rowChar);

            DrawToTop(height, colChar);
            try { Console.CursorLeft += (width - 1); }
            catch { return; }
            DrawToTop(height, colChar);
            Console.SetCursorPosition(currentPos.X, currentPos.Y);
        }

        public static void ClearLines(int numberOfLines)
        {
            for (int index = 0; index < numberOfLines; index++)
            {
                ClearLine();
                try { Console.CursorTop--; }
                catch { }
            }
        }

        public static void ClearInvalidInput(Coord cd)
        {
            ClearInvalidInput(string.Empty, cd);
        }
        public static void ClearInvalidInput(string message, Coord cd)
        {
            if (message != string.Empty)
            {
                Write(message, ConsoleColor.DarkYellow);
                Console.ReadKey(true);
                Console.Write('\r');
                ClearToRight();
            }
            Console.SetCursorPosition(cd.X, cd.Y);
            ClearToRight();
        }

        private static bool IsCheckCompare(int value, string compareType, int min, int max)
        {
            switch (compareType)
            {
                case ">":
                    return (value > min);
                case "<":
                    return (value < max);
                case "> && <":
                    return (value > min) && (value < max);

                case ">=":
                    return (value >= min);
                case "<=":
                    return (value <= max);

                case ">= && <=":
                    return (value >= min) && (value <= max);
                case "> && <=":
                    return (value > min) && (value <= max);
                case ">= && <":
                    return (value >= min) && (value < max);

                case "":
                    return true;
                default:
                    Write("Error formatting!", ConsoleColor.DarkRed);
                    return false;
            }
        }
        private static bool IsCheckCompare(double value, string compareType, double min, double max)
        {
            switch (compareType)
            {
                case ">":
                    return (value > min);
                case "<":
                    return (value < max);
                case "> && <":
                    return (value > min) && (value < max);

                case ">=":
                    return (value >= min);
                case "<=":
                    return (value <= max);

                case ">= && <=":
                    return (value >= min) && (value <= max);
                case "> && <=":
                    return (value > min) && (value <= max);
                case ">= && <":
                    return (value >= min) && (value < max);

                case "":
                    return true;
                default:
                    Write("Error formatting!", ConsoleColor.DarkRed);
                    return false;
            }
        }
        public static void ReadLine(out int value, string compareType, int min, int max)
        {
            bool isValidInput = false;
            bool checkCompare = false;
            Coord cd = GetCurrentCursorPosition();
            value = 0;
            do
            {
                string str = Console.ReadLine();
                isValidInput = int.TryParse(str, out value);
                if (isValidInput)
                {
                    checkCompare = IsCheckCompare(value, compareType, min, max);
                    if (!checkCompare)
                        ClearInvalidInput(cd);
                }
                else
                {
                    ClearInvalidInput(cd);
                }
            }
            while ((!isValidInput) || (!checkCompare));
        }
        public static void ReadLine(out double value, string compareType, double min = -1, double max = -1)
        {
            bool isValidInput = false;
            bool checkCompare = false;
            Coord cd = GetCurrentCursorPosition();
            value = 0;
            do
            {
                isValidInput = double.TryParse(Console.ReadLine(), out value);
                if (isValidInput)
                {
                    checkCompare = IsCheckCompare(value, compareType, min, max);
                    if (!checkCompare)
                        ClearInvalidInput(cd);
                }
            }
            while ((!isValidInput) || (!checkCompare));
        }
        public static void ReadLine(out string value)
        {
            Coord cd = GetCurrentCursorPosition();
            ReadLine:
            {
                value = Console.ReadLine();
            }
            if (IsEmpty(value))
            {
                Console.SetCursorPosition(cd.X, cd.Y);
                goto ReadLine;
            }
        }
        public static void ReadLine(out DateTime value)
        {
            int[] data = new int[3] { 0, 0, 0 };
            string[] texts = new string[3] { "Day", "Month", "Year" };

            ReadLine:
            {
                for (int index = 0; index < 3; index++)
                {
                    Console.Write(texts[index] + ": ");
                    ReadLine(out data[index], string.Empty, -1, -1);
                }
            }
            try
            {
                value = new DateTime(data[2], data[1], data[0]);
            }
            catch (Exception ex)
            {
                ClearInvalidInput(ex.Message, GetCurrentCursorPosition());
                ClearLines(4);
                Console.WriteLine();
                goto ReadLine;
            }
        }
        public static int InputInt(string compareType, int min = -1, int max = -1)
        {
            int value;
            ReadLine(out value, compareType, min, max);
            return value;
        }
        public static double InputDouble(string compareType, double min = -1, double max = -1)
        {
            double value;
            ReadLine(out value, compareType, min, max);
            return value;
        }
        public static string InputStr()
        {
            string value;
            ReadLine(out value);
            return value;
        }
        public static DateTime InputDate()
        {
            DateTime dateInput;
            ReadLine(out dateInput);
            return dateInput;
        }
        public static DateTime InputDate(List<DateTime> lst, string message)
        {
            DateTime dateInput;
            ReadLine:
            {
                ReadLine(out dateInput);
            }
            if (!IsExist(lst, dateInput))
            {
                ClearInvalidInput(message, GetCurrentCursorPosition());
                ClearLines(4);
                goto ReadLine;
            }
            return dateInput;
        }
        public static bool IsExist(List<DateTime> source, DateTime value)
        {
            foreach (var item in source)
            {
                if (item.Date == value.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsExist(List<string> source, string value)
        {
            foreach (var item in source)
            {
                if (item == value)
                    return true;
            }
            return false;
        }
        public static bool IsEmpty(string str)
        {
            return string.IsNullOrEmpty(str)
                || string.IsNullOrWhiteSpace(str);
        }
        public static bool GetYNOptionKey()
        {
            Console.Write(" (Y/N): ");
            char c;
            do
            {
                c = Console.ReadKey(true).KeyChar;
                c = char.ToUpper(c); // Cho phép nhập kí tự in hoa, in thường.
            }
            while ((c != 'Y') && (c != 'N'));

            Console.WriteLine(c);
            return (c == 'Y');
        }

        public static void Write(string str)
        {
            Console.Write(str);
        }
        public static void Write(string str, ConsoleColor textColor)
        {
            ConsoleColor temp = Console.ForegroundColor;

            Console.ForegroundColor = textColor;
            Console.Write(str);

            Console.ForegroundColor = temp;
        }
        public static void WriteAt(string str, int cdX)
        {
            try
            {
                Console.CursorLeft = cdX;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message, ConsoleColor.DarkYellow);
            }
            Write(str);
        }
        public static void WriteAt(string str, ConsoleColor textColor, int cdX)
        {
            try
            {
                Console.CursorLeft = cdX;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message, ConsoleColor.DarkYellow);
            }
            Write(str, textColor);
        }

        public static void Write(object str)
        {
            Write(str.ToString());
        }
        public static void Write(object str, ConsoleColor textColor)
        {
            Write(str.ToString(), textColor);
        }
        public static void WriteAt(object str, int cdX)
        {
            WriteAt(str.ToString(), cdX);
        }
        public static void WriteAt(object str, ConsoleColor textColor, int cdX)
        {
            WriteAt(str.ToString(), textColor, cdX);
        }

        public static void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
        public static void WriteLine(string str, ConsoleColor textColor)
        {
            Write(str + "\n", textColor);
        }
        public static void WriteLineAt(string str, int cdX)
        {
            try {
                Console.CursorLeft = cdX;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message, ConsoleColor.DarkYellow);
            }
            WriteLine(str);
        }
        public static void WriteLineAt(string str, ConsoleColor textColor, int cdX)
        {
            try
            {
                Console.CursorLeft = cdX;
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message, ConsoleColor.DarkYellow);
            }
            WriteLine(str, textColor);
        }

        public static void WriteLine(object str)
        {
            WriteLine(str.ToString());
        }
        public static void WriteLine(object str, ConsoleColor textColor)
        {
            WriteLine(str.ToString(), textColor);
        }
        public static void WriteLineAt(object str, int cdX)
        {
            WriteLineAt(str.ToString(), cdX);
        }
        public static void WriteLineAt(object str, ConsoleColor textColor, int cdX)
        {
            WriteLineAt(str.ToString(), textColor, cdX);
        }
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void Output<T>(string format, IEnumerable<T> source)
        {
            int index = 0;
            int Y = Console.CursorTop;
            int X = Console.CursorLeft;
            foreach (var item in source)
            {
                int tempNumber = 6;
                if (index == tempNumber)
                {
                    Console.CursorTop = Y;
                    X = 60;
                }
                if (format.Contains("{1}"))
                    WriteLineAt(string.Format(format, index + 1, item), X);
                else
                    WriteLineAt(string.Format(format, item), X);
                ++index;
            }
        }
        public static void Output<T>(string format, IEnumerable<T> source, ref int index)
        {
            int Y = Console.CursorTop;
            int X = Console.CursorLeft;
            foreach (var item in source)
            {
                if (format.Contains("{1}"))
                    WriteLineAt(string.Format(format, index + 1, item), X);
                else
                    WriteLineAt(string.Format(format, item), X);
                ++index;
            }
        }

        public static void Output(object[] arg, List<int> lengths)
        {
            // Update code
            Console.Write("| ");

            int number = Console.CursorLeft;
            int index = 0;

            foreach (var item in arg)
            {
                WriteAt(item, number);

                // Update code
                try {
                    number += lengths[index];
                    Console.CursorLeft = number;
                    index++;
                }
                catch { }
                Console.Write(" | ");
                number += 3;
            }
            Console.WriteLine();
        }
        public static void OutputLine(object[] arg, List<string> fields, int distance)
        {
            int index = 0;
            int cdX = Console.CursorLeft;
            foreach (object item in arg)
            {
                WriteAt(fields[index++], cdX);
                WriteLineAt(item.ToString(), cdX + distance);
            }
        }
    }
}