using System;

class MainClass
{
    private static NMatricula nmatricula = new NMatricula();
    private static NAluno naluno = new NAluno();
    public static void Main()
    {
        int op = 0;
        Console.WriteLine("----- Aplicativo Escolar -----");
        do
        {
            try
            {
                op = Menu();
                switch (op)
                {
                    case 1: MatriculaListar(); break;
                    case 2: MatriculaInserir(); break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                op = 100;
            }
        } while (op != 0);
        Console.WriteLine("Bye.....");
    }
    public static int Menu()
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine("1 - Matrícula - Listar");
        Console.WriteLine("2 - Matrícula - Inserir");
        Console.WriteLine("3 - Aluno - Listar");
        Console.WriteLine("4 - Aluno - Inserir");
        Console.WriteLine("0 - Fim");
        Console.Write("Informe uma opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }
    public static void MatriculaListar()
    {
        Console.WriteLine("----- Lista de Matrículas -----");
        Matricula[] cs = nmatricula.Listar();
        if (cs.Length == 0)
        {
            Console.WriteLine("Nenhuma Matrícula cadastrada");
            return;
        }
        foreach (Matricula c in cs) Console.WriteLine(c);
        Console.WriteLine();
    }

    public static void MatriculaInserir()
    {
        Console.WriteLine("----- Inserção de Matrículas -----");
        Console.Write("Informe um código para Matrícula: ");
        long id = long.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição: ");
        string descricao = Console.ReadLine();
        // Instanciar a classe de Categoria
        Matricula c = new Matricula(id, descricao);
        // Inserção da categoria
        nmatricula.Inserir(c);
    }
    public static void AlunoListar()
    {
        Console.WriteLine("----- Lista de Alunos -----");
        Aluno[] ps = naluno.Listar();
        if (ps.Length == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado");
            return;
        }
        foreach (Aluno a in ps) Console.WriteLine(p);
        Console.WriteLine();
    }
    public static void AlunoInserir()
    {
        Console.WriteLine("----- Inserção de Alunos -----");
        Console.Write("Informe um código para o aluno: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe o nome completo: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o endereço: ");
        int endereco = int.Parse(Console.ReadLine());
        Console.Write("Informe o telefone: ");
        int telefone = int.Parse(Console.ReadLine());
        MatriculaListar();
        Console.Write("Informe o código da matrícula do aluno: ");
        int idmatricula = int.Parse(Console.ReadLine());
        // Seleciona a matricula a partir do id
        Matricula c = nmatricula.Listar(idmatricula);
        // Instanciar a classe de Aluno
        Aluno p = new Aluno(id, nome, endereco, telefone, c);
        // Inserção de aluno
        naluno.Inserir(p);
    }

}

//Classe de Cursos
class Curso
{
    private int id;
    private string descricao;

    public Curso(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }

    public int GetId()
    {
        return id;
    }

    public string GetDescricao()
    {
        return descricao;
    }

    public override string ToString()
    {
        return id + " - " + descricao;
    }
}

//Classe de Matricula
class Matricula
{
    private long id;
    private string descricao;
    private Aluno[] alunos = new Aluno[10];
    private int np;

    public Matricula(long id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }

    public void SetId(long id)
    {
        this.id = id;
    }

    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }

    public long GetId()
    {
        return id;
    }

    public string GetDescricao()
    {
        return descricao;
    }

    public Aluno[] AlunoListar()
    {
        Aluno[] c = new Aluno[np];
        Array.Copy(alunos, c, np);
        return c;
    }

    public void AlunoInserir(Aluno a)
    {
        if (np == alunos.Length)
        {
            Array.Resize(ref alunos, 2 * alunos.Length);
        }
        alunos[np] = a;
        np++;
    }
    public override string ToString()
    {
        return "Matrícula: " + id + " - " + "Tipo: " + descricao;
    }
}

class NMatricula
{
    private Matricula[] matriculas = new Matricula[10];
    private int nc;

    public Matricula[] Listar()
    {
        Matricula[] c = new Matricula[nc];
        Array.Copy(matriculas, c, nc);
        return c;
    }

    public Matricula Listar(int id)
    {
        for (int i = 0; i < nc; i++)
            if (matriculas[i].GetId() == id) return matriculas[i];
        return null;
    }

    public void Inserir(Matricula c)
    {
        if (nc == matriculas.Length)
        {
            Array.Resize(ref matriculas, 2 * matriculas.Length);
        }
        matriculas[nc] = c;
        nc++;
    }

}

//Classe Aluno
class Aluno
{
    private int id;
    private string nome;
    private string endereco;
    private int telefone;
    private Matricula matricula;

    public Aluno(int id, string nome, int endereco1, string endereco, int telefone)
    {
        this.id = id;
        this.nome = nome;
        this.endereco = endereco;
        this.telefone = telefone > 0 ? telefone : 0;
    }
    public Aluno(int id, string nome, string endereco, int telefone, Matricula matricula) : this(id, nome, endereco, telefone)
    {
        this.matricula = matricula;
    }
    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public void SetEndereco(string endereco)
    {
        this.endereco = endereco;
    }

    public void SetTelefone(int telefone)
    {
        this.telefone = telefone > 0 ? telefone : 0;
    }

    public void SetMatricula(Matricula matricula)
    {
        this.matricula = matricula;
    }

    public int GetId()
    {
        return id;
    }

    public string GetNome()
    {
        return nome;
    }

    public string GetEndereco()
    {
        return endereco;
    }

    public int GetTelefone()
    {
        return telefone;
    }

    public Matricula GetMatricula()
    {
        return matricula;
    }
    public override string ToString()
    {
        if (matricula == null)
            return id + " - " + "Aluno(a): " + nome + " - Endereço: " + endereco + " - Telefone: " + telefone.ToString("0");
        else
            return id + " - " + "Aluno(a): " + matricula.GetId() + nome + " - Endereço: " + endereco + " - Telefone: " + telefone.ToString("0");

    }
}

class NAluno {
  private Aluno[] alunos = new Aluno[10];
  private int np;

  public Aluno[] Listar() {
    Aluno[] p = new Aluno[np];
    Array.Copy(alunos, p, np);
    return p;
  }

  public Aluno Listar(int id) {
    for (int i = 0; i < np; i++)
      if (alunos[i].GetId() == id) return alunos[i];
    return null;  
  }

  public void Inserir(Aluno p) {
    if (np == alunos.Length) {
      Array.Resize(ref alunos, 2 * alunos.Length);
    }
    alunos[np] = p;
    np++;
    // Recuperar a matricula do aluno que está sendo inserido
    Matricula c = p.GetMatricula();
    if (c != null) c.AlunoInserir(p);
  } 

}
