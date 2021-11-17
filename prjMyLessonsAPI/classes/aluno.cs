using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class aluno:banco
    {

        #region propriedades
            public int rm { get; private set; }
            private string senha { get; set; }
            public string email { get; private set; }
            public string nome { get; set; }
            public int qtEsmeraldas { get; set; }
            public int nivel { get; set; }
            public double qtExperiencia { get; set; }

            public tema temaSelecionado { get; set; }
            public avatar avatarSelecionado { get; set; }

            public turma turmaAtual { get; set; }
        #endregion

        #region Construtores
            public aluno(int rm): base()
            {
                this.rm = rm;
            }
            public aluno(int rm, string senha):base()
            {
                this.rm = rm;
                this.senha = senha;
            }
        #endregion

        #region verificarAluno
            public bool verificarAluno() 
            {
                MySqlDataReader dados = null;
                string nomeSP = "verificarAluno";
                string[,] parametros = new string[2,2];
                parametros[0,0] = "VRm";
                parametros[0,1] = rm.ToString();
                parametros[1,0] = "vSenha";
                parametros[1,1] = senha;

                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }   
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

        #region Pegar o Email
            public bool pegaEmail()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarEmailAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm.ToString();

                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                email = dados["nm_email_aluno"].ToString();
                                nome = dados["nm_aluno"].ToString() ;
                            }
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

        #region Redefinir senha
            public bool redefinirSenha(string senha)
            {
                string nomeSP = "redefinirSenhaAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm.ToString(); 
                parametros[1, 0] = "vSenha";
                parametros[1, 1] = senha;

                return Executar(nomeSP, parametros);
            }
        #endregion

        #region Busca os dados do aluno
            public bool dados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "BuscarDadosAluno";
                string[,] parametros = new string[1,2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm.ToString();
                if(Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                nome = dados["nm_aluno"].ToString();
                                qtEsmeraldas = int.Parse(dados["qt_esmeralda"].ToString());
                                int tipoTema = int.Parse(dados["cd_tipo_tema"].ToString());
                                string tema = dados["cd_tema"].ToString();
                                string avatar = dados["cd_avatar"].ToString();
                                temaSelecionado = new tema(int.Parse(tema), new tipoTema(tipoTema));
                                avatarSelecionado = new avatar(int.Parse(avatar));
                            }
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

        #region Atualiza as quantidades de esmeralda e experência
            public bool atualizarXpEsmeraldas(int experiencia, int esmeralda)
            {
                string nomeSP = "AtualizarXpEsmeraldaAluno";
                string[,] parametros = new string[3, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm.ToString();
                parametros[1, 0] = "vXp";
                parametros[1, 1] = experiencia.ToString();
                parametros[2, 0] = "vEsmeralda";
                parametros[2, 1] = esmeralda.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

        #region Busca o nível do aluno
            public bool pegaNivel()
            {
                MySqlDataReader dados = null;
                string nomeSP = "CalcularNivelAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                double nivelBruto = double.Parse(dados["nivel"].ToString());
                                this.nivel = Convert.ToInt32(Math.Floor(nivelBruto));
                                this.qtExperiencia = nivelBruto;
                            }
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

    }
}