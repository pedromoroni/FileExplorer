namespace Explorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lvwExplorador = new ListView();
            clhNome = new ColumnHeader();
            clhTamanho = new ColumnHeader();
            clhDataDeModificao = new ColumnHeader();
            imgsPastasEFicheiros = new ImageList(components);
            tvwDiretorios = new TreeView();
            txtCaminho = new TextBox();
            cbApresentarListView = new ComboBox();
            btnVoltar = new Button();
            chkMostrarOcultos = new CheckBox();
            btnCopiar = new Button();
            btnColar = new Button();
            txtBarraPesquisa = new TextBox();
            btnAtras = new Button();
            btnFrente = new Button();
            btnApagar = new Button();
            btnCriarPasta = new Button();
            txtNomeDoFicheiro = new TextBox();
            SuspendLayout();
            // 
            // lvwExplorador
            // 
            lvwExplorador.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwExplorador.Columns.AddRange(new ColumnHeader[] { clhNome, clhTamanho, clhDataDeModificao });
            lvwExplorador.LargeImageList = imgsPastasEFicheiros;
            lvwExplorador.Location = new Point(227, 90);
            lvwExplorador.Margin = new Padding(9);
            lvwExplorador.MinimumSize = new Size(10, 10);
            lvwExplorador.Name = "lvwExplorador";
            lvwExplorador.Size = new Size(879, 505);
            lvwExplorador.SmallImageList = imgsPastasEFicheiros;
            lvwExplorador.TabIndex = 0;
            lvwExplorador.UseCompatibleStateImageBehavior = false;
            lvwExplorador.View = View.Details;
            lvwExplorador.SelectedIndexChanged += lvwExplorador_SelectedIndexChanged;
            lvwExplorador.DoubleClick += lvwExplorador_DoubleClick;
            // 
            // clhNome
            // 
            clhNome.Text = "Nome";
            clhNome.Width = 500;
            // 
            // clhTamanho
            // 
            clhTamanho.Text = "Tamanho";
            clhTamanho.Width = 180;
            // 
            // clhDataDeModificao
            // 
            clhDataDeModificao.Text = "Data de Modificação";
            clhDataDeModificao.Width = 200;
            // 
            // imgsPastasEFicheiros
            // 
            imgsPastasEFicheiros.ColorDepth = ColorDepth.Depth32Bit;
            imgsPastasEFicheiros.ImageStream = (ImageListStreamer)resources.GetObject("imgsPastasEFicheiros.ImageStream");
            imgsPastasEFicheiros.TransparentColor = Color.Transparent;
            imgsPastasEFicheiros.Images.SetKeyName(0, "arquivo.png");
            imgsPastasEFicheiros.Images.SetKeyName(1, "pasta.png");
            // 
            // tvwDiretorios
            // 
            tvwDiretorios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tvwDiretorios.Location = new Point(12, 12);
            tvwDiretorios.Name = "tvwDiretorios";
            tvwDiretorios.ShowLines = false;
            tvwDiretorios.ShowPlusMinus = false;
            tvwDiretorios.ShowRootLines = false;
            tvwDiretorios.Size = new Size(209, 583);
            tvwDiretorios.TabIndex = 1;
            tvwDiretorios.BeforeExpand += tvwDiretorios_BeforeExpand;
            tvwDiretorios.AfterSelect += tvwDiretorios_AfterSelect;
            // 
            // txtCaminho
            // 
            txtCaminho.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCaminho.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCaminho.Location = new Point(285, 53);
            txtCaminho.Name = "txtCaminho";
            txtCaminho.ReadOnly = true;
            txtCaminho.Size = new Size(585, 30);
            txtCaminho.TabIndex = 2;
            // 
            // cbApresentarListView
            // 
            cbApresentarListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbApresentarListView.DropDownStyle = ComboBoxStyle.DropDownList;
            cbApresentarListView.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbApresentarListView.FormattingEnabled = true;
            cbApresentarListView.Items.AddRange(new object[] { "Details", "Large", "Small" });
            cbApresentarListView.Location = new Point(948, 11);
            cbApresentarListView.Name = "cbApresentarListView";
            cbApresentarListView.Size = new Size(158, 28);
            cbApresentarListView.TabIndex = 4;
            cbApresentarListView.SelectedIndexChanged += cbApresentarListView_SelectedIndexChanged;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(227, 52);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(52, 32);
            btnVoltar.TabIndex = 5;
            btnVoltar.Text = "<<";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // chkMostrarOcultos
            // 
            chkMostrarOcultos.AutoSize = true;
            chkMostrarOcultos.Location = new Point(665, 13);
            chkMostrarOcultos.Name = "chkMostrarOcultos";
            chkMostrarOcultos.Size = new Size(136, 24);
            chkMostrarOcultos.TabIndex = 6;
            chkMostrarOcultos.Text = "Mostrar Ocultos";
            chkMostrarOcultos.UseVisualStyleBackColor = true;
            chkMostrarOcultos.CheckedChanged += chkMostrarInvisiveis_CheckedChanged;
            // 
            // btnCopiar
            // 
            btnCopiar.Enabled = false;
            btnCopiar.Location = new Point(807, 10);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(65, 29);
            btnCopiar.TabIndex = 7;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // btnColar
            // 
            btnColar.Enabled = false;
            btnColar.Location = new Point(878, 10);
            btnColar.Name = "btnColar";
            btnColar.Size = new Size(65, 29);
            btnColar.TabIndex = 10;
            btnColar.Text = "Colar";
            btnColar.UseVisualStyleBackColor = true;
            btnColar.Click += btnColar_Click;
            // 
            // txtBarraPesquisa
            // 
            txtBarraPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBarraPesquisa.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarraPesquisa.Location = new Point(876, 53);
            txtBarraPesquisa.Name = "txtBarraPesquisa";
            txtBarraPesquisa.Size = new Size(230, 30);
            txtBarraPesquisa.TabIndex = 12;
            txtBarraPesquisa.TextChanged += txtBarraPesquisa_TextChanged;
            // 
            // btnAtras
            // 
            btnAtras.Enabled = false;
            btnAtras.Location = new Point(227, 13);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(26, 29);
            btnAtras.TabIndex = 13;
            btnAtras.Text = "<";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // btnFrente
            // 
            btnFrente.Enabled = false;
            btnFrente.Location = new Point(253, 13);
            btnFrente.Name = "btnFrente";
            btnFrente.Size = new Size(26, 29);
            btnFrente.TabIndex = 14;
            btnFrente.Text = ">";
            btnFrente.UseVisualStyleBackColor = true;
            btnFrente.Click += btnFrente_Click;
            // 
            // btnApagar
            // 
            btnApagar.Enabled = false;
            btnApagar.Location = new Point(580, 10);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(79, 29);
            btnApagar.TabIndex = 15;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            // 
            // btnCriarPasta
            // 
            btnCriarPasta.Enabled = false;
            btnCriarPasta.Location = new Point(480, 10);
            btnCriarPasta.Name = "btnCriarPasta";
            btnCriarPasta.Size = new Size(94, 29);
            btnCriarPasta.TabIndex = 16;
            btnCriarPasta.Text = "Criar Pasta";
            btnCriarPasta.UseVisualStyleBackColor = true;
            btnCriarPasta.Click += btnCriarPasta_Click;
            // 
            // txtNomeDoFicheiro
            // 
            txtNomeDoFicheiro.Location = new Point(349, 11);
            txtNomeDoFicheiro.Name = "txtNomeDoFicheiro";
            txtNomeDoFicheiro.Size = new Size(125, 27);
            txtNomeDoFicheiro.TabIndex = 17;
            txtNomeDoFicheiro.TextChanged += txtNomeDoFicheiro_TextChanged;
            txtNomeDoFicheiro.KeyPress += txtNomeDoFicheiro_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 607);
            Controls.Add(txtNomeDoFicheiro);
            Controls.Add(btnCriarPasta);
            Controls.Add(btnApagar);
            Controls.Add(btnFrente);
            Controls.Add(btnAtras);
            Controls.Add(txtBarraPesquisa);
            Controls.Add(btnColar);
            Controls.Add(btnCopiar);
            Controls.Add(chkMostrarOcultos);
            Controls.Add(btnVoltar);
            Controls.Add(cbApresentarListView);
            Controls.Add(txtCaminho);
            Controls.Add(tvwDiretorios);
            Controls.Add(lvwExplorador);
            MinimumSize = new Size(1136, 654);
            Name = "Form1";
            Text = "File Explorer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvwExplorador;
        private TreeView tvwDiretorios;
        private TextBox txtCaminho;
        private ComboBox cbApresentarListView;
        private Button btnVoltar;
        private ImageList imgsPastasEFicheiros;
        private CheckBox chkMostrarOcultos;
        private Button btnCopiar;
        private Button button2;
        private Button btnColar;
        private TextBox txtBarraPesquisa;
        private Button btnAtras;
        private Button btnFrente;
        private ColumnHeader clhNome;
        private ColumnHeader clhTamanho;
        private ColumnHeader clhDataDeModificao;
        private Button btnApagar;
        private Button btnCriarPasta;
        private TextBox txtNomeDoFicheiro;
    }
}
