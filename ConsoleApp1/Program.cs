namespace iml_machine
{
    public class MemWord
    {
        private int opCode;
        private int param1;
        private int param2;
        private char sign;

        public MemWord(int opCode, int param1, int param2)
        {
            this.opCode = opCode;
            this.param1 = param1;
            this.param2 = param2;
            this.sign = '+';
        }

        public MemWord(int data)
        {
            SetData(data);
        }

        public int GetData()
        {
            int result = opCode * 10000 + param1 * 100 + param2;
            return (sign == '-') ? -result : result;
        }

        public void SetData(int data)
        {
            if (data < 0)
            {
                sign = '-';
                data = -data;
            }
            else
            {
                sign = '+';
            }
            opCode = data / 10000;
            data = data % 10000;
            param1 = data / 100;
            data = data % 100;
            param2 = data;
        }

        public int GetOpCode()
        {
            return opCode;
        }

        public void SetOpCode(int opCode)
        {
            this.opCode = opCode;
        }

        public int GetParam1()
        {
            return param1;
        }

        public void SetParam1(int param1)
        {
            this.param1 = param1;
        }

        public int GetParam2()
        {
            return param2;
        }

        public void SetParam2(int param2)
        {
            this.param2 = param2;
        }

        public char GetSign()
        {
            return sign;
        }

        public void SetSign(char sign)
        {
            this.sign = sign;
        }

        public override string ToString()
        {
            string result = "";
            result += sign;
            result += opCode.ToString("00");
            result += param1.ToString("00");
            result += param2.ToString("00");
            return result;
        }
    }
}
