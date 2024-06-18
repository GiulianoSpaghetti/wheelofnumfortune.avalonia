using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;

namespace wheelofnumfortune.avalonia.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private static Task<HttpResponseMessage> httpResponse;
        private static HttpClient client = new HttpClient();
        private static Task<string> sTask;
        private static String risposta;
        private static String visualizzazione;
        private static int i;
        private static StringBuilder sb;
        private static Random random=new Random();
        public static string Tick()
        {
            try
            {
                httpResponse = client.GetAsync("https://api.justyy.workers.dev/api/fortune");
                if (httpResponse.Result.IsSuccessStatusCode)
                {

                    sTask = httpResponse.Result.Content.ReadAsStringAsync();
                    risposta = sTask.Result;
                    risposta = risposta.Substring(1, risposta.Length - 2);
                    risposta = risposta.Replace("\\n", System.Environment.NewLine);
                    risposta = risposta.Replace("\\t", "	");
                    risposta = risposta.Replace("\\\"", "\"");
                    risposta = risposta.Trim();
                    sb = new StringBuilder(risposta);
                    for (i = 0; i < sb.Length; i++)
                        switch (sb[i])
                        {
                            case 'q':
                            case 'Q':
                            case 'w':
                            case 'W':
                            case 'e':
                            case 'E':
                            case 'r':
                            case 'R':
                            case 't':
                            case 'T':
                            case 'y':
                            case 'Y':
                            case 'u':
                            case 'U':
                            case 'i':
                            case 'I':
                            case 'o':
                            case 'O':
                            case 'p':
                            case 'P':
                            case 'a':
                            case 'A':
                            case 's':
                            case 'S':
                            case 'd':
                            case 'D':
                            case 'f':
                            case 'F':
                            case 'g':
                            case 'G':
                            case 'h':
                            case 'H':
                            case 'j':
                            case 'J':
                            case 'k':
                            case 'K':
                            case 'l':
                            case 'L':
                            case 'z':
                            case 'Z':
                            case 'x':
                            case 'X':
                            case 'c':
                            case 'C':
                            case 'v':
                            case 'V':
                            case 'b':
                            case 'B':
                            case 'n':
                            case 'N':
                            case 'm':
                            case 'M':
                                sb[i] = '*';
                                break;


                        }
                    visualizzazione = sb.ToString();
                }
                else
                {
                    visualizzazione = $"The HTTP status code is ${httpResponse.Result.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;

                }
                return visualizzazione;

        }
        public static bool CheckRisposta(String s)
        {
            return s == risposta;
        }


        public static String getVisualizzazione() {
            return visualizzazione;
        }
        public static bool DiscoverLetter()
        {
            if (visualizzazione.IndexOf('*') == -1)
            {
                return false;
            }
            i = random.Next(0, sb.Length);
            while (sb[i] != '*' && visualizzazione.IndexOf("*") != -1)
            {
                i++;
                if (i == sb.Length)
                    i = 0;
            }
            sb[i] = risposta[i];
            visualizzazione = sb.ToString();
            return true;
        }

        public static bool ObtainedResponse() {
            bool ex = false;
            try {
                ex = httpResponse.Result.IsSuccessStatusCode;
            } catch (Exception e) {
                ex = false;
            }
            return ex;
        }

    }
}
