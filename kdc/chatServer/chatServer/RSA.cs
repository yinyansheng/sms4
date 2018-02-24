using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chatServer
{
    /// <summary>
    /// RSA加解密类
    /// </summary>
    class RSA
    {
        //RSA参数变量申明；
        private string p = "788452793787847346126219254833955453272163607923488809146819795082249307301";   //初始化值

        public string P
        {
            get { return p; }
            set { p = value; }
        }
        private string q = "83346520147868299584979019230225516357803424619107941000333729982224293168149";   //初始化值

        public string Q
        {
            get { return q; }
            set { q = value; }
        }
        private string n = "";

        public string N
        {
            get { return n; }
            set { n = value; }
        }
        private string e = "65537";   //初始化值

        public string E
        {
            get { return e; }
            set { e = value; }
        }
        private string d = "";

        public string D
        {
            get { return d; }
            set { d = value; }
        }
        private string faiN = "";

        public string FaiN
        {
            get { return faiN; }
            set { faiN = value; }
        }

        private string plaintext = "";

        public string Plaintext
        {
            get { return plaintext; }
            set { plaintext = value; }
        }
        private string ciphertext = "";

        public string Ciphertext
        {
            get { return ciphertext; }
            set { ciphertext = value; }
        }




        //随机种子，和大数运算实例化
        private Random rand = new Random();
        BigIntegerOperation bio = new BigIntegerOperation();
        //幂模类实例字段
        ExponentAndModulus eam = new ExponentAndModulus();










        /// <summary>
        /// 使用公开密钥<n,e>对plaintext加密
        /// </summary>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns>密文ciphertext</returns>
        public string Encryption(string plaintext, string e, string n)
        {
            return eam.Operation(new CharToDigital(plaintext).iMingwen, e, n);
        }

        public string Encryption(string plaintext, string p, string q, string d)
        {
            string n = GetN(p, q);
            return eam.Operation(new CharToDigital(plaintext).iMingwen, d, n);
        }

        public string Decryption(string ciphertext, string e, string n)
        {
            return new DigitalToChar(eam.Operation(ciphertext, e, n)).cMingwen;
        }


        /// <summary>
        /// 解密方法 密钥组<p,q,d,faiN>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="d"></param>
        /// <param name="faiN"></param>
        /// <returns>明文plaintext</returns>
        public string Decryption(string ciphertext, string p, string q, string d)
        {
            string n = GetN(p, q);
            return new DigitalToChar(eam.Operation(ciphertext, d, n)).cMingwen;
        }

        /// <summary>
        /// 求得n=p*q;
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns>n</returns>
        public string GetN(string p, string q)
        {
            return bio.Multiply(p, q);                //求得n=p*q;
        }

        /// <summary>
        /// 求得faiN=(p-1)*(q-1);
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns>n</returns>
        public string GetFaiN(string p, string q)
        {
            return bio.Multiply(bio.Minus(p, "1"), bio.Minus(q, "1"));    //求得faiN = (p - 1) * (q - 1);
        }


        /// <summary>
        /// 求参数d，ed=1modfaiN;
        /// </summary>
        /// <param name="faiN"></param>
        /// <param name="e"></param>
        /// <returns>返回D</returns>
        public string GetD(string faiN, string e)
        {
            //Div dd = new Div();
            for (int k = 1; ; k++)
            {
                string div1 = bio.Plus(bio.Multiply(k.ToString(), faiN), "1");
                if (bio.Divide(div1, e)[1] == "0")
                {
                    return bio.Divide(div1, e)[0];
                }
            }
        }

        /// <summary>
        /// 求参数e，要求与faiN互质；
        /// </summary>
        /// <param name="faiN"></param>
        /// <returns><返回E/returns>
        public string GetE(string faiN)
        {
            //这里e取5位
            do
            {
                e = string.Empty;            //清空e
                e += rand.Next(1, 10);
                for (int i = 0; i < 3; i++)
                {
                    e += rand.Next(0, 10);
                }
                e += (rand.Next(0, 10) * 2 + 1) % 10;
            } while (Euclidean(faiN, e) != "1");

            return e;
        }

        /// <summary>
        /// 几里德算法（Euclidean algorithm）乃求两个正整数之最大公因子的算法
        /// 如果为结果为1的话则说明这两个数互质
        /// function gcd(a, b)
        /// { 　　
        /// if b<>0 　　
        /// return gcd(b, a mod b); 
        /// else 
        /// return a; 　
        /// }
        /// </summary>
        /// <param name="faiN"></param>
        /// <param name="e"></param>
        /// <returns>最大公因子</returns>
        private string Euclidean(string faiN, string e)
        {
            if (e != "0")
            {
                return Euclidean(e, bio.Divide(faiN, e)[1]);
            }
            else
            {
                return faiN;
            }
        }


    }

    /// <summary>
    /// 获取大素数类
    /// </summary>
    class GetBigPrimeNumber
    {

        private long countTest = 0;               //记录测试的大数的次数
        /// <summary>
        /// 检测大数的个数
        /// </summary>
        public long CountTest
        {
            get { return countTest; }
            set { countTest = value; }
        }
        private BigIntegerOperation bio = new BigIntegerOperation();                //大数运算类的实例
        ExponentAndModulus eam = new ExponentAndModulus();                          //幂模运算类的实例
        private Random rand = new Random();


        /// <summary>
        /// 获得素数方法
        /// </summary>
        /// <param name="primeLengthLow">素数的最小位数</param>
        /// <param name="primeLengthHigh">素数的最大位数</param>
        /// <returns>素数</returns>
        public string GetPrime(int primeLengthLow, int primeLengthHigh)
        {
            //获取大素数的长度
            //参数设置大素数的长度低位和高位大小；
            int primeLength = rand.Next(primeLengthLow, primeLengthHigh);             //素数长度   
            string primeNumber = "";
            char lastNumber;           //伪素数的最后一位

            #region  找呀找呀找素数
            int j = 0;
            do
            {
                countTest++;
                #region 获取伪素数
                //清空伪素数
                primeNumber = "";
                //获取伪素数，用来测试
                //保证首位不为0；
                primeNumber += (rand.Next(1, 10));
                for (int i = 0; i < primeLength; i++)
                {
                    primeNumber += (rand.Next(0, 10));
                }


                //保证伪素数的结尾数为奇数，且不为5，以便最有可能是素数
                do
                {
                    lastNumber = (char)((rand.Next(0, 10) * 2 + 1) % 10 + '0');
                } while (lastNumber == '5');
                primeNumber += lastNumber;

                #endregion
                j = 0;
                //5次miller测试通过即可认为是素数,不是是素数的概率大约为2**-10； 
                for (j = 0; j < 5; j++)
                {
                    if (!RabinMiller(primeNumber))           //new Rabin_Test().MillerRabin_test(num) == false
                        break;
                }
                if (j < 5)
                {
                    j = 0;
                }
            } while (j != 5);
            return primeNumber;

            #endregion

        }


        /// <summary>
        /// RobinMiller素性检测方法
        /// /*0、先计算出m、j，使得n-1=m*2^j，其中m是正奇数，j是非负整数
        /// 1、随机取一个b，2<=b 
        /// 2、计算v=b^m mod n
        ///3、如果v==1，通过测试，返回
        ///4、令i=1
        ///5、如果v=n-1，通过测试，返回
        /// 6、如果i==j，非素数，结束
        ///7、v=v^2 mod n，i=i+1
        /// 8、循环到5 */
        /// </summary>
        /// <param name="testnum"></param>
        /// <returns></returns>
        private Boolean RabinMiller(string testNumber)
        {

            //求出m,j
            int j = 0;
            string m = "", index = bio.Minus(testNumber, "1"), v;
            do
            {
                index = bio.Divide(index, "2")[0];
                j++;
            } while (bio.Divide(index, "2")[1] == "0");
            m = bio.Divide((bio.Minus(testNumber, "1")), BigIntegerPow(2, j))[0];
            long b = rand.Next(2, 100);
            v = eam.Operation(b.ToString(), m, testNumber);
            if (v == "1")
            {
                return true;
            }
            int i = 1;

            do
            {
                if (v == bio.Minus(testNumber, "1"))
                {
                    return true;
                }
                if (i == j)
                {
                    return false;
                }
                v = eam.Operation(v, "2", testNumber);
                i++;
            } while (true);
        }


        /// <summary>
        /// 大数的幂运算，底数和幂的值为一个整型，结果不能超过1000位，否则会越界;
        /// </summary>
        /// <returns></returns>
        private string BigIntegerPow(int n, int m)
        {

            //保存结果值
            string result = "1";
            for (int i = 0; i < m; i++)
            {
                result = bio.Multiply(result, n.ToString());
            }
            return result;
        }
    }

    /// <summary>
    /// 大数幂模运算 求C^E%n；
    /// </summary>
    class ExponentAndModulus
    {
        private BigIntegerOperation bio = new BigIntegerOperation();

        public string Operation(string C, string E, string n)
        {
            //将a二进制化；
            string aBinary = this.ToBinary(E);
            //Console.WriteLine(aBinary);
            //a二进制数的长度；
            int aBinaryLength = aBinary.Length;



            //快速模乘运算
            string D = "1";
            for (int i = aBinaryLength - 1; i >= 0; i--)
            {
                D = bio.Divide(bio.Multiply(D, D), n)[1];
                if (aBinary.ToCharArray()[i] == '1')
                {

                    D = bio.Divide(bio.Multiply(D, C), n)[1];    //D * P % n;
                }
            }
            return D;
        }

        //得到一个逆置的二进制化字符串
        private string ToBinary(string number)
        {
            string numberBinary = string.Empty;
            string[] strResult = new string[2];
            do
            {
                strResult = bio.Divide(number, "2");
                numberBinary += strResult[1];
                number = strResult[0];
            } while (number != "0");
            return numberBinary;
        }
    }

    /// <summary>
    /// 大整数四则运算类
    /// 作者 Donne
    /// 10-9-14
    /// </summary>
    class BigIntegerOperation
    {
        private const int MAX = 400;                    //定义数组的最大长度
        private string errorMessage = string.Empty;      //错误信息字符串
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        /// <summary>
        /// 检查传入的字符串是否合法
        /// </summary>
        /// <returns>合法返回true 不合法返回false</returns>
        private bool Check(string operationNumberA)
        {
            if (operationNumberA.ToCharArray()[0] == '0' && operationNumberA.Length != 1)
            {
                errorMessage = "大整数首位不能为0！且 字符串中不能有除0~9以外的字符！";
                return false;
            }
            for (int i = 0; i < operationNumberA.Length; i++)
            {
                if (operationNumberA.ToCharArray()[i] < '0' || operationNumberA.ToCharArray()[i] > '9')
                {
                    errorMessage = "大整数首位不能为0！且 字符串中不能有除0~9以外的字符！";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 加法函数，返回和，并将和存入sum字段；
        /// </summary>
        /// <returns></returns>
        public string Plus(string operationNumberA, string operationNumberB)
        {
            if (!(this.Check(operationNumberA) && this.Check(operationNumberB)))
            {
                return errorMessage;
            }
            string sum = "";                                              //存放和
            int[] sumArr = new int[MAX];                                  //存放和的数组
            int BigIntegerNumberALength = operationNumberA.Length - 1;    //操作数A的长度
            int BigIntegerNumberBLength = operationNumberB.Length - 1;    //操作数B的长度
            int flag = 0;                                                 //设置标记位，控制进位！
            int k = 1;                                                    //记录和的位数

            while (BigIntegerNumberALength >= 0 & BigIntegerNumberBLength >= 0)
            {
                sumArr[k] = ((operationNumberA.ToCharArray()[BigIntegerNumberALength] - '0') + (operationNumberB.ToCharArray()[BigIntegerNumberBLength] - '0') + flag) % 10;
                flag = ((operationNumberA.ToCharArray()[BigIntegerNumberALength] - '0') + (operationNumberB.ToCharArray()[BigIntegerNumberBLength] - '0') + flag) / 10;
                BigIntegerNumberALength--;
                BigIntegerNumberBLength--;
                k++;
            }
            while (BigIntegerNumberALength >= 0)
            {
                sumArr[k] = ((operationNumberA.ToCharArray()[BigIntegerNumberALength] - '0') + flag) % 10;
                flag = ((operationNumberA.ToCharArray()[BigIntegerNumberALength] - '0') + flag) / 10;
                k++;
                BigIntegerNumberALength--;
            }
            while (BigIntegerNumberBLength >= 0)
            {
                sumArr[k] = ((operationNumberB.ToCharArray()[BigIntegerNumberBLength] - '0') + flag) % 10;
                flag = ((operationNumberB.ToCharArray()[BigIntegerNumberBLength] - '0') + flag) / 10;
                k++;
                BigIntegerNumberBLength--;
            }
            if (flag == 1)
            {
                sum += '1';
            }
            for (int i = k - 1; i >= 1; i--)
            {
                sum += sumArr[i];
            }
            return sum;
        }


        /// <summary>
        /// 减法函数，返回差，并将差存入remainder字段
        /// </summary>
        /// <returns></returns>
        public string Minus(string operationNumberA, string operationNumberB)
        {
            if (!(this.Check(operationNumberA) && this.Check(operationNumberB)))
            {
                return errorMessage;
            }
            string remainder = "";
            int[] remainderArr = new int[MAX];   //存放差的数组
            int[] minuend = new int[MAX];        //逆置存放被减数的数组
            int[] subtrahend = new int[MAX];     //逆置存放减数的数组
            int BigIntegerNumberALength = 0;      //被减数长度
            int BigIntegerNumberBLength = 0;      //减数长度

            if (Compare(operationNumberA, operationNumberB) == 0)
            {
                remainder = "0";
                return remainder;
            }
            else if (Compare(operationNumberA, operationNumberB) == -1)
            {
                string temp = "";
                temp = operationNumberA;
                operationNumberA = operationNumberB;
                operationNumberB = temp;
                remainder += '-';
                // Console.WriteLine(operationNumberA +"\n"+ operationNumberB);
            }
            BigIntegerNumberALength = operationNumberA.Length;      //被减数长度
            BigIntegerNumberBLength = operationNumberB.Length;      //减数长度


            //初始化逆置减数被减数
            #region
            for (int i = 0; i < BigIntegerNumberALength; i++)
            {
                minuend[i] = operationNumberA.ToCharArray()[BigIntegerNumberALength - i - 1] - '0';           //被减数逆置存放在minuend[]中
            }
            for (int i = 0; i < BigIntegerNumberBLength; i++)
            {
                subtrahend[i] = operationNumberB.ToCharArray()[BigIntegerNumberBLength - i - 1] - '0';           //被减数逆置存放在subtrahend[]中
            }
            #endregion


            int index = 0;
            for (int i = 0; i < MAX; i++)
            {
                remainderArr[i] = minuend[i] - subtrahend[i];
                if (remainderArr[i] < 0)
                {
                    remainderArr[i] += 10;
                    minuend[i + 1]--;
                }
            }

            for (int i = BigIntegerNumberALength; i >= 0; i--)
            {
                if (remainderArr[i] != 0)
                {
                    break;
                }
                index++;
            }
            for (int i = BigIntegerNumberALength - index; i >= 0; i--)
            {
                remainder += remainderArr[i];

            }
            return remainder;

        }
        /// <summary>
        /// 比较两个大整数的大小
        /// 如果A>B 返回1；
        /// 如果A<B 返回-1；
        /// 如果A=B 返回0；
        /// </summary>
        /// <param name="BigIntegerNumberA"></param>
        /// <param name="BigIntegerNumberB"></param>
        /// <returns></returns>
        private int Compare(string BigIntegerNumberA, string BigIntegerNumberB)
        {
            if (BigIntegerNumberA == BigIntegerNumberB)
            {
                return 0;
            }
            if (BigIntegerNumberA.Length < BigIntegerNumberB.Length)
            {
                return -1;
            }
            else if (BigIntegerNumberA.Length == BigIntegerNumberB.Length)
            {
                int i = 0;
                for (i = 0; i < BigIntegerNumberA.Length; i++)
                {
                    if (BigIntegerNumberA.ToCharArray()[i] > BigIntegerNumberB.ToCharArray()[i])
                    {
                        return 1;
                    }
                    else if (BigIntegerNumberA.ToCharArray()[i] < BigIntegerNumberB.ToCharArray()[i])
                    {
                        return -1;
                    }
                }
            }
            return 1;

        }

        /// <summary>
        /// 乘法运算，返回字符串型的积
        /// </summary>
        /// <returns></returns>
        public string Multiply(string operationNumberA, string operationNumberB)
        {
            if (!(this.Check(operationNumberA) && this.Check(operationNumberB)))
            {
                return errorMessage;
            }

            string product = "";
            int BigIntegerNumberALength = operationNumberA.Length;      //被乘数数长度
            int BigIntegerNumberBLength = operationNumberB.Length;      //乘数长度
            int[] projectArr = new int[2 * MAX];                        //存放积的数组
            int i = 0, j = 0;                                           //游标

            //如果乘数和被乘数中有0，则直接返回0；
            if (operationNumberA == "0" || operationNumberB == "0")
            {
                return "0";
            }

            for (i = BigIntegerNumberBLength - 1; i >= 0; i--)
            {
                for (j = BigIntegerNumberALength - 1; j >= 0; j--)
                {
                    int midProduct = (operationNumberA.ToCharArray()[j] - '0') * (operationNumberB.ToCharArray()[i] - '0');
                    projectArr[i + j + 0] += midProduct / 10;
                    projectArr[i + j + 1] += midProduct % 10;
                }
            }

            for (i = BigIntegerNumberBLength + BigIntegerNumberALength - 1; i > 0; i--)
            {
                if (projectArr[i] >= 10)
                {
                    projectArr[i - 1] += projectArr[i] / 10;
                    projectArr[i] = projectArr[i] % 10;
                }

            }

            int pos = 0;
            for (i = 0; i < BigIntegerNumberBLength + BigIntegerNumberALength; i++)
            {
                if (projectArr[i] != 0)
                {
                    pos = i;
                    break;
                }
            }
            for (int x = pos; x < BigIntegerNumberBLength + BigIntegerNumberALength; x++)
            {
                product += projectArr[x];                       //记录结果
            }

            return product;

        }


        /// <summary>
        /// 除法运算
        /// 返回一个字符串数组 string[0]表示商，string[1]表示余数
        /// </summary>
        public string[] Divide(string operationNumberA, string operationNumberB)
        {
            if (!(this.Check(operationNumberA) && this.Check(operationNumberB)))
            {
                return new string[] { errorMessage, "" };
            }
            //如果被除数小于除数，则商为0,余数为被除数
            if (this.Compare(operationNumberA, operationNumberB) == -1)
            {
                return new string[] { "0", operationNumberA };
            }
            string quotient = "";
            string yushu = operationNumberA;                                     //初始化余数等于被除数
            int[] shang = new int[operationNumberA.Length];                     //初始化存放商的数组长度为被除数的长度
            int BigIntegerNumberBLength = operationNumberB.Length;               //除数的长度
            string partDividend = "";                                            //存放部分被除数
            string lastDividend = "";                                              //存放剩下的被除数
            int index = BigIntegerNumberBLength - 1;                                 //记录商的位置

            do
            {
                partDividend = yushu.Substring(0, BigIntegerNumberBLength);
                if (Compare(partDividend, operationNumberB) == -1)
                {
                    partDividend = yushu.Substring(0, BigIntegerNumberBLength + 1);
                    index++;
                }
                lastDividend = yushu.Substring(partDividend.Length, yushu.Length - partDividend.Length);

                int k = 1;
                for (k = 1; ; k++)
                {
                    partDividend = this.Minus(partDividend, operationNumberB);
                    if (partDividend == "0")
                    {
                        partDividend = "";
                    }
                    if (Compare(partDividend, operationNumberB) == -1)
                    {

                        shang[index] = k;
                        break;
                    }
                }
                yushu = partDividend + lastDividend;
                int countZero = CountZero(yushu);
                if (countZero > 0)
                {
                    index = index + countZero + BigIntegerNumberBLength;
                }
                else if (countZero == 0)
                {
                    index += BigIntegerNumberBLength - partDividend.Length;
                }
                yushu = yushu.Substring(countZero, yushu.Length - countZero);
            } while (Compare(yushu, operationNumberB) != -1);

            //将int型的数组shang【】 存入quotient中
            for (int i = 0; i < shang.Length; i++)
            {
                quotient += (char)(shang[i] + 48);
            }
            quotient = quotient.Substring(CountZero(quotient), quotient.Length - CountZero(quotient));

            if (yushu == "")
            {
                yushu = "0";
            }
            return new string[] { quotient, yushu };

        }

        /// <summary>
        /// 输入如“00123”；返回前面无效0的个数2；
        /// </summary>
        /// <param name="BigInteger">大整数</param>
        /// <returns>无效0的个数</returns>
        private int CountZero(string BigInteger)
        {
            int countZero = 0;     //统计无效0的个数
            for (int i = 0; i < BigInteger.Length; i++)
            {
                if (BigInteger.ToCharArray()[i] == '0')
                {
                    countZero++;
                }
                else
                {
                    return countZero;
                }
            }
            return countZero;
        }

    }

    class CharToDigital
    {
        public string iMingwen = "";
        private string cMingwen = "";
        public CharToDigital(String cMingwen)
        {
            this.cMingwen = cMingwen;
            ctd();
        }
        private void ctd()
        {
            for (int i = 0; i < cMingwen.ToCharArray().Length; i++)
            {
                if (97 <= (int)cMingwen.ToCharArray()[i] && cMingwen.ToCharArray()[i] <= 122)
                {
                    int index = cMingwen.ToCharArray()[i] - 87;
                    iMingwen = iMingwen + index.ToString();
                }
                else if (48 <= (int)cMingwen.ToCharArray()[i] && cMingwen.ToCharArray()[i] <= 57)
                {
                    int index = cMingwen.ToCharArray()[i] + 12;
                    iMingwen = iMingwen + index.ToString();
                }
            }
        }
    }   //字符转数字

    class DigitalToChar
    {
        private string iMingwen = "";
        public string cMingwen = "";
        public DigitalToChar(String iMingwen)
        {
            this.iMingwen = iMingwen;
            dtc();
        }
        private void dtc()
        {
            for (int i = 0; i < iMingwen.ToCharArray().Length; i = i + 2)
            {
                if (Convert.ToInt32(iMingwen.Substring(i, 2)) < 50)
                {
                    int index = Convert.ToInt32(iMingwen.Substring(i, 2)) + 87;
                    cMingwen += (char)index;
                }
                else
                {
                    int index = Convert.ToInt32(iMingwen.Substring(i, 2)) - 12;
                    cMingwen += (char)index;
                }
            }
        }
    }   //数字转字符
}
