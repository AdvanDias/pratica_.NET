using System;

namespace projeto_NET
{
    class Program
    {
        static void Main(string[] args)
        {
           int indiceAluno = 0; 
           Aluno[] alunos = new Aluno[5];
           string opcaoUsuario = ObterOpcaoUsuario();


           while(opcaoUsuario.ToUpper() != "X")
           {
                switch(opcaoUsuario)
                {
                    case "1":
                         Console.WriteLine("Informe o nome do aluno:");
                         Aluno aluno = new Aluno();
                         aluno.Nome = Console.ReadLine();
                        //uma forma de converter string para decimal
                            //Console.WriteLine("Informe a nota do aluno:");
                            //var nota = decimal.Parse(Console.ReadLine());
                            //aluno.Nota = nota;
                        // melhor forma de converter string para decimal
                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = (int)nota;
                        }else{
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;


                        break;
                    case "2":
                        //foreach(var a in alunos)
                        for(int a=0; a < alunos.Length; a++)
                        {
                            if (alunos[a]!=null)
                            {
                                Console.WriteLine($"Aluno: {alunos[a].Nome} - Nota: {alunos[a].Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                       
                        var numAlunos = 0;
                        for(int i=0; i < alunos.Length; i++)
                        {
                           if (alunos[i]!=null)
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                numAlunos++;
                                
                            }
                            
                        }
                        var mediageral = notaTotal/numAlunos;
                        Console.WriteLine($"MEDIA GERAL: {mediageral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
           }
        }

        private static string ObterOpcaoUsuario()
        { 
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Insira novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

             string opcaoUsuario = Console.ReadLine();
             return opcaoUsuario;
        }
    }
}
