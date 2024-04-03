using System;

namespace iml_machine
{
    public class IMLMachine
    {
        private MemWord[] ram;
        private MemWord[] reg;
        private int pc;

        public IMLMachine(System.IO.StreamReader inFile)
        {
            ram = new MemWord[100];
            reg = new MemWord[5];  // Register 0 is unused
            int i = 0;
            while (!inFile.EndOfStream && i < 100)
            {
                ram[i] = new MemWord(int.Parse(inFile.ReadLine()));
                i++;
            }
            for (; i < 100; i++)
                ram[i] = new MemWord(0);
            for (i = 0; i < 5; i++)
                reg[i] = new MemWord(0);
            pc = 0;
        }

        public void Run()
        {
            bool done = false;

            while (true)
            {
                int opCode = ram[pc].GetOpCode();
                int param1 = ram[pc].GetParam1();
                int param2 = ram[pc].GetParam2();
                switch (opCode)
                {
                    case 11: // WRITE                                    
                        Console.WriteLine(ram[param1].GetData());
                        break;
                    case 12: // READ
                        Console.WriteLine("Enter data:");
                        int input = int.Parse(Console.ReadLine());
                        ram[param1].SetData(input);
                        break;
                    case 21: // STORE
                        ram[param2].SetData(reg[param1].GetData());
                        break;
                    case 22: // LOAD
                        reg[param1].SetData(ram[param2].GetData());
                        break;
                    case 31: // ADD
                        reg[param1].SetData(reg[param1].GetData() + reg[param2].GetData());
                        break;
                    case 32: // SUBTRACT
                        reg[param1].SetData(reg[param1].GetData() - reg[param2].GetData());
                        break;
                    case 33: // MULTIPLY
                        reg[param1].SetData(reg[param1].GetData() * reg[param2].GetData());
                        break;
                    case 34: // DIVIDE
                        reg[param1].SetData(reg[param1].GetData() / reg[param2].GetData());
                        break;
                    case 41: // BRANCH
                        pc = param1;
                        break;
                    case 42: // BRANCHZERO
                        if (reg[param2].GetData() == 0)
                            pc = param1;
                        else
                            pc++;
                        break;
                    case 43: // BRANCHPOS
                        if (reg[param2].GetData() > 0)
                            pc = param1;
                        else
                            pc++;
                        break;
                    case 99: // HALT
                        done = true;
                        break;
                }
                if (opCode > 43 || opCode < 41) // Increment PC if this wasn't a branch
                    pc++;
                if (done) break;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < 100; i++)
            {
                result += $"{i:00} {ram[i]}\n";
            }
            return result;
        }
    }
}
