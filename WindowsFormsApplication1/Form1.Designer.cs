namespace WindowsFormsApplication1
{
    partial class FormStringCounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buscaTxt = new System.Windows.Forms.OpenFileDialog();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnLocalizaArquivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Palavra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tamanho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prefixos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sufixos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subpalavras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAlfabeto = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblSubpalavra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buscaTxt
            // 
            this.buscaTxt.DefaultExt = "txt";
            this.buscaTxt.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.buscaTxt.Title = "Localizar Arquivo";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(24, 52);
            this.txtArquivo.Multiline = true;
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(538, 20);
            this.txtArquivo.TabIndex = 1;
            // 
            // btnLocalizaArquivo
            // 
            this.btnLocalizaArquivo.Location = new System.Drawing.Point(611, 49);
            this.btnLocalizaArquivo.Name = "btnLocalizaArquivo";
            this.btnLocalizaArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnLocalizaArquivo.TabIndex = 2;
            this.btnLocalizaArquivo.Text = "Buscar";
            this.btnLocalizaArquivo.UseVisualStyleBackColor = true;
            this.btnLocalizaArquivo.Click += new System.EventHandler(this.btnLocalizaArquivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione o arquivo que deseja utilizar clicando no botão \'Buscar\'.";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num,
            this.Palavra,
            this.Tamanho,
            this.Prefixos,
            this.Sufixos,
            this.Subpalavras});
            this.listView1.Location = new System.Drawing.Point(24, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1062, 358);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Num
            // 
            this.Num.Text = "Num";
            this.Num.Width = 41;
            // 
            // Palavra
            // 
            this.Palavra.Text = "Palavra";
            this.Palavra.Width = 89;
            // 
            // Tamanho
            // 
            this.Tamanho.Text = "Tamanho";
            // 
            // Prefixos
            // 
            this.Prefixos.Text = "Prefixos";
            this.Prefixos.Width = 300;
            // 
            // Sufixos
            // 
            this.Sufixos.Text = "Sufixos";
            this.Sufixos.Width = 300;
            // 
            // Subpalavras
            // 
            this.Subpalavras.Text = "Subpalavras";
            this.Subpalavras.Width = 265;
            // 
            // lblAlfabeto
            // 
            this.lblAlfabeto.AutoSize = true;
            this.lblAlfabeto.Location = new System.Drawing.Point(30, 481);
            this.lblAlfabeto.Name = "lblAlfabeto";
            this.lblAlfabeto.Size = new System.Drawing.Size(52, 13);
            this.lblAlfabeto.TabIndex = 7;
            this.lblAlfabeto.Text = "Alfabeto: ";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(767, 52);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(195, 20);
            this.txtPesquisa.TabIndex = 8;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(1011, 49);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblSubpalavra
            // 
            this.lblSubpalavra.AutoSize = true;
            this.lblSubpalavra.Location = new System.Drawing.Point(764, 26);
            this.lblSubpalavra.Name = "lblSubpalavra";
            this.lblSubpalavra.Size = new System.Drawing.Size(204, 13);
            this.lblSubpalavra.TabIndex = 10;
            this.lblSubpalavra.Text = "Digite a subpalavra que deseja pesquisar.";
            // 
            // FormStringCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 508);
            this.Controls.Add(this.lblSubpalavra);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.lblAlfabeto);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLocalizaArquivo);
            this.Controls.Add(this.txtArquivo);
            this.Name = "FormStringCounter";
            this.Text = "Contador de Strings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog buscaTxt;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnLocalizaArquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Num;
        private System.Windows.Forms.ColumnHeader Palavra;
        private System.Windows.Forms.ColumnHeader Tamanho;
        private System.Windows.Forms.ColumnHeader Prefixos;
        private System.Windows.Forms.ColumnHeader Sufixos;
        private System.Windows.Forms.Label lblAlfabeto;
        private System.Windows.Forms.ColumnHeader Subpalavras;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblSubpalavra;
    }
}

