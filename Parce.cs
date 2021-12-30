using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_2_ser
{
    class ParseHash
    {
        private string str;
        private int numFunc, countPar;
        private List<string> Params = new List<string>();

        public void GetHash(string hash)
        {
            this.str = hash;
        }
        public int GetNum(char ch)
        {
            int res = 0;
            string answer = "";
            bool infoStream = false;
            for (int i = 0; i < this.str.Length; i++)
            {
                if (str[i] == ch)
                {
                    infoStream = !infoStream;
                }
                if (str[i] != ch && infoStream)
                {
                    answer += str[i];
                }
            }
            if (!int.TryParse(answer, out res))
            {
                if (ch == '|')
                {
                    res = 0;
                }
                if (ch == '?')
                {
                    res = 1;
                }
            }
            if (ch == '|')
            {
                if (res < 0 || res > 15)
                {
                    res = 0;
                }
                numFunc = res;
            }
            if (ch == '?')
            {
                if (res < 0 || res > 6)
                {
                    res = 1;
                }
                countPar = res;
            }

            return res;
        }

        public List<string> GetParams()
        {
            string par = "";
            bool steramInfo = false;

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '<')
                {
                    steramInfo = true;
                }
                if (str[i] == '>')
                {
                    steramInfo = false;
                    Params.Add(par);
                    par = "";
                }
                if (str[i] == ',')
                {
                    Params.Add(par);
                    par = "";
                }
                if (steramInfo && str[i] != ',' && str[i] != '<' && str[i] != '>')
                {
                    par += str[i];
                }
            }

            return Params;
        }
    }
}
