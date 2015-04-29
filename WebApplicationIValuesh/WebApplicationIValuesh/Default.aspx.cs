using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationIValuesh
{
    public partial class Default : System.Web.UI.Page
    {
        #region .: Variaveis :.

        //letras tipo foo
        String[] Letrasfoo = new String[] { "t", "s", "w", "l", "h" };

        #endregion

        #region .: Metodos :.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LimpaConteudo();
            }

        }

        private string PreposicaoArquivo(String strArquivo)
        {
            /*
             * Primeiramente, as letras IValuesh são classificadas em dois grupos:
             * as letras t, s, w, l e h são chamadas “letras tipo foo“, 
             * enquanto que as demais são conhecidas como “letras tipo bar“.
             * Os linguistas descobriram que as preposições em IValuesh são as palavras
             * de 3 letras que terminam numa letra tipo foo, mas onde não ocorre a letra m.
             * Portanto, é fácil ver que existem 13 preposições no Texto A. E no Texto B,
             * quantas preposições existem?
             */

            int prepo = 0;
            String[] divArquivo = strArquivo.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            foreach (var item in divArquivo)
            {
                if (item.Length == 3)
                {
                    foreach (var item2 in Letrasfoo)
                    {
                        if (item.EndsWith(item2))
                        {
                            if (!item.Contains("m"))
                            {
                                prepo += 1;
                            }
                        }
                    }

                }

            }
            return "Existem " + prepo + " preposições";
        }

        private string VerbetesArquivo(String strArquivo)
        {
            /*
             * Outro fato interessante descoberto pelos linguistas é que,
             * no IValuesh, os verbos sempre são palavras de 8 ou mais 
             * letras que terminam numa letra tipo foo. Além disso, 
             * se um verbo começa com uma letra tipo foo, o verbo está em
             * primeira pessoa.
             * Assim, lendo o Texto A, é possível identificar 29 verbos no texto,
             * dos quais 4 estão em primeira pessoa. E no Texto B,
             * quantos verbos existem? E quantos em primeiro pessoa?
             */

            int verbos = 0;
            int verbPrimera = 0;
            String[] divArquivo = strArquivo.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            foreach (var item in divArquivo)
            {
                if (item.Length >= 8)
                {
                    foreach (var item2 in Letrasfoo)
                    {
                        if (item.EndsWith(item2))
                        {
                            verbos++;
                            foreach (var item3 in Letrasfoo)
                            {
                                if (item.StartsWith(item3))
                                    verbPrimera++;
                            }

                        }
                    }
                }
            }


            return "Existem " + verbos + " Verbos, sendo " + verbPrimera + " em primeira pessoa.";
        }

        private void LimpaConteudo()
        {
            lb1.Text = "";
            lb21.Text = "";
            lbResult.Text = "";
            lbResult2.Text = "";
            lbResultVerbetes.Text = "";
            lbResultVerbetes2.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            divText1.Style.Add("display", "none");
            divText2.Style.Add("display", "none");
        }

        #endregion

        #region .: Clicks :.

        protected void btn_comparar_Click(object sender, EventArgs e)
        {
            if (arq.HasFile)
            {
                string fileName = Server.HtmlEncode(arq.PostedFile.FileName);
                string nomePath = Server.MapPath("~/TempArquivo/") + arq.FileName;
                arq.PostedFile.SaveAs(nomePath);
                String texto = System.IO.File.ReadAllText(nomePath);
                lbResult.Text = PreposicaoArquivo(texto);
                lbResultVerbetes.Text = VerbetesArquivo(texto);
                lb1.Text = fileName;
                TextBox1.Visible = true;
                TextBox1.Text = texto;
                divText1.Style.Remove("display");

            }
            if (arq1.HasFile)
            {
                string fileName2 = Server.HtmlEncode(arq1.PostedFile.FileName);
                string nomePath2 = Server.MapPath("~/TempArquivo") + fileName2;
                arq1.PostedFile.SaveAs(nomePath2);
                String texto2 = System.IO.File.ReadAllText(nomePath2);
                lbResult2.Text = PreposicaoArquivo(texto2);
                lbResultVerbetes2.Text = VerbetesArquivo(texto2);
                lb21.Text = fileName2;
                TextBox2.Visible = true;
                TextBox2.Text = texto2;
                divText2.Style.Remove("display");
            }
        }

        protected void btn_limpar_Click(object sender, EventArgs e)
        {
            LimpaConteudo();
        }

        #endregion

    }
}