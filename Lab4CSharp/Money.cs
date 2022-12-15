using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    internal class Money : IFormattable
    {
        private int _nominal;
        private int _amount;

        private int _first;
        private int _second;

        private readonly StringBuilder _stringBuilder;
        private readonly Regex _fromStringRegex;

        public int this[int index]
        {
            get
            {
                if (index == 0)
                    return _first;
                else if (index == 1)
                    return _second;
                else
                    throw new NotImplementedException();
            }
            set
            {
                if (index == 0)
                    _first = value;
                else if (index == 1)
                    _second = value;
                else
                    throw new NotImplementedException();
            }
        }

        public static Money operator ++(Money money)
        {
            money[0]++; // increment _first (index = 0)
            money[1]++; // increment _second (index = 1)
            return money;
        }

        public static Money operator --(Money money)
        {
            money[0]--; // decrement _first (index = 0)
            money[1]--; // decrement _second (index = 1)
            return money;
        }

        public static bool operator !(Money money) => money[1] != 0;

        public static Money operator +(Money money, int scalar)
        {
            // add scalar to _second
            money[1] += scalar;
            return money;
        }

        public int Nominal
        {
            get { return _nominal; }
            set { _nominal = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Sum { get => _nominal * _amount; }

        public Money(int nominal, int amount)
        {
            Nominal = nominal;
            Amount = amount;
            _stringBuilder = new();
        }

        // string view = "/<nominal>/<amount>/<_first>/<_second>/"
        public Money(string moneyString)
        {
            _fromStringRegex = new(@"(?<=\/)(.+?)(?=\/)");

            var matches = _fromStringRegex.Matches(moneyString);
            _nominal = Convert.ToInt32(matches[0].Value);
            _amount = Convert.ToInt32(matches[1].Value);
            _first = Convert.ToInt32(matches[2].Value);
            _second = Convert.ToInt32(matches[3].Value);

            _stringBuilder = new();
        }

        public string GetInfo() => $"Nominal: {_nominal}; amount: {_amount}";

        public bool IsEnoughToBuy(int price) => Sum >= price;

        public int HowManyIsPossibleToBuy(int price) => Sum / price;

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine(GetInfo());
            _stringBuilder.AppendLine($"first: {_first}; second: {_second}");
            _stringBuilder.AppendLine();
            return _stringBuilder.ToString();
        }

        public override string ToString() =>
            ToString(null, null);
    }
}
