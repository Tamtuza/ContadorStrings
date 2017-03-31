/*
 * Autor: Tamillys Pantuza Coelho Pinto
 * Finalidade: Trabalho da disciplina Linguagens Formais e Autômatos
 * Professor: Frederico Miranda Coelho
 * Instituição: IF Sudeste MG, Campus Rio Pomba
 * Data: 12/08/2013 (v1)
 *       22/08/2013 (v2) 
 *       05/09/2013 (v3)
 *       03/10/2013 (v4)
 * */

///<Objetivos>
///
/// Versão 1:
/// - Contar Palavras;
///	- Imprimir Palavras;
///	
///	Versão 2:
///	- Imprimir Tamanho das palavras;
///	- Imprimir Prefixo das palavras;
///	- Imprimir Sufixo das palavras;
///	- Especificar se cada palavra é valida ou não;
///	
///	Versão 3:
///	- Imprimir Conjunto de caracteres (Alfabeto utilizado no texto);
///	- Especificar subpalavras dentro da cadeia atual.
///	
/// Versão 4:
/// - Testar quais palavras são válidas para a seguinte gramática.
///
///     G = ( {q0, q1, q2, q3, q4} , {0...9} , P, q0)
///         P:
///             q0 --> +q1 | -q1
///             q1 --> [0...9]q2
///             q2 --> [0...9]q2 | .q3
///             q3 --> [0...9]q4
///             q4 --> [0...9]q4
///	
///<Objetivos>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace WindowsFormsApplication1
{
    public partial class FormStringCounter : Form
    {
        // Variável que irá receber o conteúdo de cada linha do arquivo a ser lido
        static string line;

        // Variável que irá receber prefixos e sufixos das palavras
        static string saida = "";

        // ArrayList responsável por armazenar os diferentes caracteres contidos no texto
        ArrayList alfabeto = new ArrayList();

        // ArrayList responsável por armazenar as diferentes palavras contidas no texto
        ArrayList cadeia = new ArrayList();

        // Conta total de palavras do arquivo
        int contPalavras = 0;

        // Instancia o item de ListView
        static ListViewItem item;

        public FormStringCounter()
        {
            // Inicializa componentes do formulário
            InitializeComponent();
        }

        private void leitura(String enderecoTxt)
        {
            try
            {
                // Verifica se arquivo existe
                if (File.Exists(enderecoTxt))
                {
                    // Muda a cor do fundo da caixa de texto usada para exibir a saída do programa
                    listView1.BackColor = (Color.White);

                    // Habilita a caixa de texto para que o usuário possa editá-la, fazer scroll, etc.
                    listView1.Enabled = true;

                    // Faz a leitura no arquivo usando 'Encoder' para que acentos e caracteres especiais sejam aceitos
                    using (StreamReader reader = new StreamReader(enderecoTxt, Encoding.Default,true))
                    {
                        // Verifica se a linha a ser lida não está vazia
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Define caracter de separação das palavras e as armazena no array split
                            string[] split = line.Split(new Char[] { ' ' });

                            // Trabalha cada string dentro do array
                            foreach (string s1 in split)
                            {
                                // Garante que a string seja diferente do caracter de espaço e que ela não esteja vazia
                                if ((s1.Trim() != " ") && (s1 != "") && (s1 != "\t"))
                                {
                                    // Cria item do listview
                                    item = new ListViewItem();

                                    // Chama função que obtem prefixos
                                    string[] prefx = Pref(s1);

                                    // Chama função que obtem sufixos
                                    string[] sufx = Suf(s1);

                                    // Calcula quantos prefixos e sufixos 's1' terá
                                    //int n = (s1.Length * (s1.Length + 1)) / 2;

                                    // Coluna Num
                                    item.Text = (contPalavras + 1).ToString();
                                    
                                    // Coluna Palavra
                                    item.SubItems.Add(s1);
                                    
                                    // Coluna Tamanho
                                    item.SubItems.Add((s1.Length).ToString());

                                    // Coluna Prefixo
                                    for (int x = 0; x < prefx.Length; x++)
                                    {
                                        saida += (prefx[x]);
                                        // Garante que a vírgula seja colocada após todos os elementos, menos o último
                                        if (x != prefx.Length - 1)
                                        {
                                            saida += (", ");
                                        }
                                    }
                                    item.SubItems.Add("{ - ," + saida + "}");
                                    saida = "";

                                    // Coluna Sufixo
                                    for (int x = 0; x < sufx.Length; x++)
                                    {
                                        saida += (sufx[x]);
                                        // Garante que a vírgula seja colocada após todos os elementos, menos o último
                                        if (x != sufx.Length - 1)
                                        {
                                            saida += (", ");
                                        }
                                    }
                                    item.SubItems.Add("{ - ," + saida + "}");

                                    // Coluna Subpalavras
                                    item.SubItems.Add(""); /* Só vai ser preenchido com valores reais ao final da leitura */

                                    // Adiciona todos os itens anteriores no listview
                                    listView1.Items.Add(item);
                                    
                                    // Garante que os caracteres repetidos não sejam adicionados ao alfabeto
                                    foreach (char c in s1)
                                    {
                                        if (!alfabeto.Contains(c))
                                            alfabeto.Add(c);
                                    }
                                    
                                    // Insere palavra atual no ArrayList de Palavras
                                    cadeia.Add(s1);
             
                                    // Incrementa o número total de palavras no txt
                                    contPalavras++;
                                    saida = "";
                                }
                            }
                        }
                    }
                }

                // Chama a função que verifica palavras válidas
                verificaPalavraValida(contPalavras);

                // Exibe na caixa de texto o resultado do total de palavras
                MessageBox.Show("Total de palavras: " + contPalavras);

                // Ordena a variável alfabeto para que ela seja exibida em órdem alfabética
                alfabeto.Sort();

                // Exibe todos os elementos do ArrayList (alfabeto) em ordem alfabética
                lblAlfabeto.Text += "{ ";
                for (int z = 0; z < alfabeto.Count; z++)
                {
                    lblAlfabeto.Text += (alfabeto[z]);
                    // Garante que a vírgula seja colocada após todos os elementos, menos o último
                    if (z != alfabeto.Count - 1)
                    {
                        lblAlfabeto.Text += (", ");
                    }                       
                }
                lblAlfabeto.Text += (" } = " + alfabeto.Count);

                // Chama função que encontra as subpalavras de cada palavra do texto
                encontraSubpalavras(cadeia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Função que cria array com todos os possíveis PREFIXOS das palavras
        private string[] Pref(string palavra)
        {
            // Cria vetor string e define seu tamanho de acordo com a palavra em questão
            string[] pref = new string[palavra.Length];

            for (int i = 0; i < palavra.Length; i++)
            {
                // Armazena prefixo quebrando a string de acordo com: (posição, quantidade de caracteres)
                pref[i] = palavra.Substring(0, i + 1);
            }
            return pref;
        }

        // Função que cria array com todos os possíveis SUFIXOS das palavras
        private string[] Suf(string palavra)
        {
            // Variável que aponta a posição de início dos sufixos
            int x = palavra.Length - 1;

            // Cria vetor string e define seu tamanho de acordo com a palavra em questão
            string[] sufx = new string[palavra.Length];

            for (int i = 0; i < palavra.Length; i++)
            //for (int i = palavra.Length; i == 0; i--)
            {
                // Armazena sufixo quebrando a string de acordo com: (posição, quantidade de caracteres)
                sufx[i] = palavra.Substring(x, i + 1);
                x--;
            }
            return sufx;
        }

        // Função que retorna as subpalavras de cada uma das palavras do texto
        private void encontraSubpalavras(ArrayList cadeia)
        {
            // Variável usada para definir posição que os dados serão lançados no listview
            int pos = 0;

            // Variável que irá receber as subpalavras
            string temp = "";

            // Varre o ArrayList cadeia e analisa palavra por palavra
            foreach (string s1 in cadeia)
            {
                string saida = "{ ";
                // Percorre a palavra de de 'i' a 'j' para encontrar possíveis subpalavras
                for (int i = 0; i < s1.Length; i++)
                {
                    // Define tamanho da subpalavra atual (j)
                    for (int j = 1; j < 1+ (s1.Length - i); j++)
                    {
                        temp = s1.Substring(i, j);
                        // Verifica que a subpalavra 'temp' existe na cadeia atual
                        if ((cadeia.Contains(temp)) && (s1 != temp))
                        {
                            saida += (temp + ", ");
                        }
                    }
                }
                saida += "}";
                // Acrescenta as subpalavras no listview de acordo com a posição da palavra em questão
                listView1.Items[pos].SubItems[5].Text = saida;
                pos++;
            }
        }

        // Verifica quais palavras do texto são válidas dada uma determinada gramática. (Especificada no início do programa)
        private void verificaPalavraValida(int quantidade) {

            // Varre o listview da primeira até a última linha
            for (int i = 0; i < quantidade; i++)
            {
                // Armazena a palavra da linha atual para ser analisada pela máquina de estados
                string palavra = listView1.Items[i].SubItems[1].Text;
                int estado = 0;

                // Verifica cada posição da string para garantir que ela pertença à gramática
                foreach (char c in palavra)
                {
                    switch (estado)
                    {                         
                        case 0:
                            // O primeiro estado (caracter da palavra) deve ser obrigatoriamente um sinal de positivo ou negativo
                            if ((c == '+') || (c == '-'))
                                { estado = 1; }
                            else
                                { estado = -1; }
                            break;
                        case 1:
                            // O segundo estado deve ser obrigatoriamente um número de 0 a 9.
                            if ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9'))
                                { estado = 2; }
                            else
                                { estado = -1; }
                            break;
                        case 2:
                            // O terceiro estado pode conter outro número (também de 0 a 9) ou um ponto ('.').
                            if ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9'))
                                { estado = 2; }
                            else if (c == '.')
                                { estado = 3; }
                            else
                                { estado = -1; }
                            break;
                        case 3:
                            // O quarto estado deve ser obrigatoriamente um número de 0 a 9.
                            if ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9'))
                                { estado = 4; }
                            else
                                { estado = -1; }
                            break;
                        case 4:
                            // O quinto estado deve ser um número de 0 a 9 ou vazio.
                            if ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9'))
                                { estado = 4; }
                            else
                                { estado = -1; }
                            break;
                    }
                }
                if (estado == 4)
                {
                    // Muda a cor da fonte de exibição das palavras válidas.
                    listView1.Items[i].BackColor = Color.LightGray;
                }
            }
        }

        private void btnLocalizaArquivo_Click(object sender, EventArgs e)
        {
            // Define as propriedades do controle 'OpenFileDialog'
            this.buscaTxt.Multiselect = false;
            this.buscaTxt.Title = "Selecionar Arquivo";
            buscaTxt.InitialDirectory = @"C:\";

            //filtra para exibir somente arquivos de texto
            buscaTxt.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // Instancia objeto que chama o 'OpenFileDialog' para busca do arquivo de leitura
            DialogResult dr = this.buscaTxt.ShowDialog();

            // Verifica se o arquivo encontrado existe e pode ser lido
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Armazena endereço do arquivo em variável string
                String arquivo = buscaTxt.FileName;

                // Exibe endereço do arquivo no textBox
                txtArquivo.Text += arquivo;

                // Chama função que realiza leitura do txt passando como parâmetro o endereço do mesmo
                leitura(arquivo);
            }
        }

        // Função usada para pesquisar quais palavras possuem uma subpalavra
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Variável que irá receber as subpalavras
            string temp = "";
            string subPesquisa = txtPesquisa.Text;
            string saida = "";
            foreach (string s1 in cadeia)
            {
                // Percorre a palavra de de 'i' a 'j' para encontrar possíveis subpalavras
                for (int i = 0; i < s1.Length; i++)
                {
                    // Define tamanho da subpalavra atual (j)
                    for (int j = 1; j < 1 + (s1.Length - i); j++)
                    {
                        temp = s1.Substring(i, j);
                        // Verifica que a subpalavra 'temp' existe na cadeia atual
                        if (temp == subPesquisa)
                        {
                            saida += (s1 + ", ");
                        }
                    }
                }
            }
            // Exibe messagebox com as palavras referentes à subpalavra pesquisada
            MessageBox.Show("Palavras que contem a subpalavra '" + subPesquisa + "': \n\n" + saida);
        }
    }
}