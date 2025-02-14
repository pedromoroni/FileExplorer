using Microsoft.VisualBasic.FileIO;
using System.CodeDom;

namespace Explorer
{
    public partial class Form1 : Form
    {
        private string _caminhoAtual;
        private string _caminhoOriginal;

        private bool _mostrarFicheirosInvisiveis = false;

        private List<string> _caminhosCopiar = new List<string>();

        private List<string> _movimentosParaTras = new List<string>();
        private List<string> _movimentosParaFrente = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbApresentarListView.SelectedIndex = 0;
            _caminhoOriginal = "C:" + '\\' + "Users" + '\\' + Environment.UserName + '\\';
            _caminhoAtual = _caminhoOriginal;



            MostrarDiretoriosNaTreeView();
            AtualizarCaminho();
            AtualizarFileExplorer();
        }

        private void MostrarDiretoriosNaTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            tvwDiretorios.Nodes.Clear();
            foreach (string diretorioCaminho in Directory.GetDirectories(_caminhoOriginal))
            {
                try
                {
                    DirectoryInfo diretorioInfo = new DirectoryInfo(diretorioCaminho);
                    if (diretorioInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                    {
                        continue;
                    }

                    string[] partes = diretorioCaminho.Split('\\');
                    string diretorio = partes[partes.Length - 1];
                    tvwDiretorios.Nodes.Add(diretorio);
                    tvwDiretorios.Nodes[tvwDiretorios.Nodes.Count - 1].Nodes.Add(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void tvwDiretorios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvwExplorador.Items.Clear();
            btnCopiar.Enabled = false;
            AdicionarCaminhoAoMovimentoAtras();
            MudarDiretorio();

            AlterarEnableDasSetas();
            AtualizarFileExplorer();
            AtualizarCaminho();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (_caminhoAtual + '\\' == _caminhoOriginal)
            {
                return;
            }

            AdicionarCaminhoAoMovimentoAtras();

            string[] partes = _caminhoAtual.Split('\\');
            _caminhoAtual = "";
            try
            {
                for (int i = 0; i < partes.Length - 1; i++)
                {
                    _caminhoAtual += i != partes.Length - 2 ?
                        partes[i] + '\\' :
                        partes[i];
                }
            }
            catch (Exception ex)
            {
                _caminhoAtual = _caminhoOriginal;
                Console.WriteLine(ex);
            }

            tvwDiretorios.SelectedNode = null;
            AlterarEnableDasSetas();
            AtualizarCaminho();
            AtualizarFileExplorer();
        }

        private void AtualizarCaminho()
        {
            txtCaminho.Text = _caminhoAtual;
        }

        private void AtualizarFileExplorer()
        {
            lvwExplorador.Items.Clear();

            try
            {
                foreach (string diretorio in Directory.GetDirectories(_caminhoAtual))
                {
                    DirectoryInfo diretorioInfo = new DirectoryInfo(diretorio);

                    if (diretorioInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                    {
                        continue;
                    }
                    else
                    {
                        string[] partes = diretorio.Split('\\');
                        DateTime dataDeModificacao = Directory.GetLastWriteTime(diretorio);
                        string diretorioNome = partes[partes.Length - 1];
                        lvwExplorador.Items.Add(diretorioNome);
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].SubItems.Add("-bytes");
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].SubItems.Add(dataDeModificacao.ToString());
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].ImageIndex = 1;
                    }
                }
                foreach (string ficheiro in Directory.GetFiles(_caminhoAtual))
                {
                    FileInfo ficheiroInfo = new FileInfo(ficheiro);
                    if (ficheiroInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                    {
                        continue;
                    }
                    else
                    {
                        string[] partes = ficheiro.Split('\\');
                        string tamanhoFicheiro = ficheiroInfo.Length.ToString();
                        DateTime dataDeModificacao = File.GetLastWriteTime(ficheiro);
                        string ficheiroNome = partes[partes.Length - 1];
                        lvwExplorador.Items.Add(ficheiroNome);
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].SubItems.Add(tamanhoFicheiro + " bytes");
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].SubItems.Add(dataDeModificacao.ToString());
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].ImageIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MostrarTodosOsDiretoriosDeUmDiretorio(String diretorioCaminho, TreeNode node)
        {
            try
            {
                foreach (String subDiretorioCaminho in Directory.GetDirectories(diretorioCaminho))
                {
                    try
                    {
                        DirectoryInfo subDiretorioInfo = new DirectoryInfo(subDiretorioCaminho);
                        if (subDiretorioInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                        {
                            continue;
                        }

                        string[] partes = subDiretorioCaminho.Split('\\');
                        string subDiretorio = partes[partes.Length - 1];
                        node.Nodes.Add(subDiretorio);
                        node.Nodes[node.Nodes.Count - 1].Nodes.Add(" ");
                        if (Directory.GetDirectories(subDiretorioCaminho).Length > 0)
                        {
                            MostrarTodosOsDiretoriosDeUmDiretorio(subDiretorioCaminho, node.Nodes[node.Nodes.Count - 1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso Negado!", "Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MudarDiretorio()
        {
            _caminhoAtual = _caminhoOriginal;
            _caminhoAtual += tvwDiretorios.SelectedNode.FullPath;
        }

        private void cbApresentarListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbApresentarListView.SelectedIndex)
            {
                case 0:
                    lvwExplorador.View = View.Details;
                    break;
                case 1:
                    lvwExplorador.View = View.LargeIcon;
                    break;
                case 2:
                    lvwExplorador.View = View.SmallIcon;
                    break;
                default:
                    break;

            }
        }

        private void lvwExplorador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwExplorador.SelectedItems.Count == 0)
            {
                btnApagar.Enabled = false;
                btnCopiar.Enabled = false;
                return;
            }
            else
            {
                btnApagar.Enabled = true;
                btnCopiar.Enabled = true;
            }
        }

        private void chkMostrarInvisiveis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarOcultos.Checked == true)
            {
                _mostrarFicheirosInvisiveis = true;
            }
            else
            {
                _mostrarFicheirosInvisiveis = false;
            }
            AtualizarFileExplorer();
            MostrarDiretoriosNaTreeView();
        }

        private void lvwExplorador_DoubleClick(object sender, EventArgs e)
        {
            if (lvwExplorador.SelectedItems.Count == 0)
            {
                return;
            }

            if (Directory.Exists(_caminhoAtual + '\\' + lvwExplorador.SelectedItems[0].Text))
            {
                AdicionarCaminhoAoMovimentoAtras();
                _caminhoAtual += _caminhoAtual[_caminhoAtual.Length - 1] != '\\' ?
                    '\\' + lvwExplorador.SelectedItems[0].Text :
                    lvwExplorador.SelectedItems[0].Text;

                lvwExplorador.SelectedItems.Clear();

                AdicionarTodosOsMovimentosDeFrenteAoDeTras();
                AlterarEnableDasSetas();
                AtualizarFileExplorer();
                AtualizarCaminho();
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            btnColar.Enabled = true;
            btnCopiar.Enabled = false;
            foreach (ListViewItem itemSelecionado in lvwExplorador.SelectedItems)
            {
                _caminhosCopiar.Add(_caminhoAtual + '\\' + itemSelecionado.Text);
            }
        }

        private void tvwDiretorios_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (tvwDiretorios.SelectedNode == null)
            {
                return;
            }
            tvwDiretorios.SelectedNode.Nodes.Clear();
            MostrarTodosOsDiretoriosDeUmDiretorio(_caminhoAtual, tvwDiretorios.SelectedNode);
        }

        private void txtBarraPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtBarraPesquisa.Text.Trim() == "")
            {
                AtualizarFileExplorer();
                return;
            }

            lvwExplorador.Items.Clear();
            try
            {
                foreach (string diretorio in Directory.GetDirectories(_caminhoAtual))
                {
                    DirectoryInfo diretorioInfo = new DirectoryInfo(diretorio);
                    string[] partes = diretorio.Split("\\");

                    if (diretorioInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                    {
                        continue;
                    }
                    else if (partes[partes.Length - 1].ToLower().Contains(txtBarraPesquisa.Text.ToLower().Trim()))
                    {

                        lvwExplorador.Items.Add(partes[partes.Length - 1]);
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].ImageIndex = 1;
                    }
                }
                foreach (string ficheiro in Directory.GetFiles(_caminhoAtual))
                {
                    FileInfo ficheiroInfo = new FileInfo(ficheiro);
                    string[] partes = ficheiro.Split("\\");

                    if (ficheiroInfo.Attributes.HasFlag(FileAttributes.Hidden) && !_mostrarFicheirosInvisiveis)
                    {
                        continue;
                    }
                    else if (partes[partes.Length - 1].ToLower().Contains(txtBarraPesquisa.Text.ToLower().Trim()))
                    {

                        lvwExplorador.Items.Add(partes[partes.Length - 1]);
                        lvwExplorador.Items[lvwExplorador.Items.Count - 1].ImageIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (string caminhoCopiar in _caminhosCopiar)
                {
                    if (File.Exists(caminhoCopiar))
                    {
                        File.Copy(caminhoCopiar, Path.Combine(_caminhoAtual, Path.GetFileName(caminhoCopiar)));
                    }
                    else if (Directory.Exists(caminhoCopiar))
                    {
                        CopiarTodosDiretorioDeUmDiretorio(caminhoCopiar, _caminhoAtual + '\\' + Path.GetFileName(caminhoCopiar));
                    }
                    else
                    {
                        MessageBox.Show("Erro, não conseguimos encontrar o que pretende colar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, verifique se o ficheiro ja existe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AtualizarFileExplorer();
        }

        private void CopiarTodosFicheirosDeUmDiretorio(string caminhoDiretorio, string caminhoDestinatario)
        {
            try
            {
                AtualizarCaminho();
                foreach (string ficheiro in Directory.GetFiles(caminhoDiretorio))
                {
                    string destinoFicheiro = Path.Combine(caminhoDestinatario, Path.GetFileName(ficheiro));
                    File.Copy(ficheiro, destinoFicheiro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void CopiarTodosDiretorioDeUmDiretorio(string caminhoDiretorioCopiar, string caminhoDestinatario)
        {
            try
            {
                foreach (string subDiretorio in Directory.GetDirectories(caminhoDiretorioCopiar))
                {
                    string nomeSubDiretorio = Path.GetFileName(subDiretorio);
                    string caminhoNovoSubDiretorio = Path.Combine(caminhoDestinatario, nomeSubDiretorio);
                    CopiarTodosDiretorioDeUmDiretorio(subDiretorio, caminhoNovoSubDiretorio);
                }

                Directory.CreateDirectory(caminhoDestinatario);
                CopiarTodosFicheirosDeUmDiretorio(caminhoDiretorioCopiar, caminhoDestinatario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            _movimentosParaFrente.Add(_caminhoAtual);
            _caminhoAtual = _movimentosParaTras[_movimentosParaTras.Count - 1];
            _movimentosParaTras.Remove(_caminhoAtual);

            AlterarEnableDasSetas();
            AtualizarCaminho();
            AtualizarFileExplorer();
        }

        private void AlterarEnableDasSetas()
        {
            if (_movimentosParaTras.Count >= 1)
            {
                btnAtras.Enabled = true;
            }
            else
            {
                btnAtras.Enabled = false;
            }

            if (_movimentosParaFrente.Count >= 1)
            {
                btnFrente.Enabled = true;
            }
            else
            {
                btnFrente.Enabled = false;
            }
        }

        private void btnFrente_Click(object sender, EventArgs e)
        {
            AdicionarCaminhoAoMovimentoAtras();
            _caminhoAtual = _movimentosParaFrente[_movimentosParaFrente.Count - 1];
            _movimentosParaFrente.Remove(_caminhoAtual);

            AlterarEnableDasSetas();
            AtualizarCaminho();
            AtualizarFileExplorer();
        }

        private void AdicionarCaminhoAoMovimentoAtras()
        {
            if (_movimentosParaTras.Count == 0)
            {
                _movimentosParaTras.Add(_caminhoAtual);
            }
            else if (_caminhoAtual != _movimentosParaTras[_movimentosParaTras.Count - 1])
            {
                _movimentosParaTras.Add(_caminhoAtual);
            }
        }

        private void AdicionarTodosOsMovimentosDeFrenteAoDeTras()
        {
            foreach (string movimento in _movimentosParaFrente)
            {
                _movimentosParaTras.Add(movimento);
            }
            _movimentosParaFrente.Clear();

            AlterarEnableDasSetas();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem itemSelecionado in lvwExplorador.SelectedItems)
                {
                    if (Directory.Exists(_caminhoAtual + '\\' + itemSelecionado.Text))
                    {
                        FileSystem.DeleteDirectory(_caminhoAtual + '\\' + itemSelecionado.Text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                    else if (File.Exists(_caminhoAtual + '\\' + itemSelecionado.Text))
                    {
                        FileSystem.DeleteFile(_caminhoAtual + '\\' + itemSelecionado.Text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnApagar.Enabled = false;
            btnCopiar.Enabled = false;
            AtualizarCaminho();
            AtualizarFileExplorer();
        }

        private void btnCriarPasta_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(_caminhoAtual + '\\' + txtNomeDoFicheiro.Text.Trim());
                AtualizarFileExplorer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar diretório: {ex.Message}");
            }
        }

        private void txtNomeDoFicheiro_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeDoFicheiro.Text.Trim() == "")
            {
                btnCriarPasta.Enabled = false;
            }
            else
            {
                btnCriarPasta.Enabled = true;
            }
        }

        private void txtNomeDoFicheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\\')
            {
                e.Handled = true;
            }
        }
    }
}