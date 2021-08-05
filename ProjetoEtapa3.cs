using System;

class MainClass {
  private static NAluno naluno = new NAluno();
  private static NMatricula nmatricula = new NMatricula();
  public static void Main() {
    int op = 0;
    Console.WriteLine ("----- Sistema Escolar ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : AlunoListar(); break;
          case 2 : AlunoInserir(); break;
          case 3 : MatriculaListar(); break;
          case 4 : MatriculaInserir(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("Bye.....");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Aluno - Listar");
    Console.WriteLine("2 - Aluno - Inserir");
    Console.WriteLine("3 - Matricula - Listar");
    Console.WriteLine("4 - Matricula - Inserir");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }
  public static void AlunoListar() {
    Console.WriteLine("----- Lista de Alunos -----");
    Aluno[] cs = naluno.Listar();
    if (cs.Length == 0) {
      Console.WriteLine("Nenhum aluno cadastrado");
      return;
    }
    foreach(Aluno c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void AlunoInserir() {
    Console.WriteLine("----- Inserção de Alunos -----");
    Console.Write("Informe um código para aluno: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o endereço: ");
    string endereco = Console.ReadLine();
    Console.Write("Informe o telefone: ");
    int telefone = int.Parse(Console.ReadLine());
    // Instanciar a classe de aluno
    Aluno c = new Aluno(id, nome, endereco, telefone);
    // Inserção de aluno
    naluno.Inserir(c);
  }

  public static void MatriculaListar() {
    Console.WriteLine("----- Lista de Matriculas -----");
    Matricula[] ps = nmatricula.Listar();
    if (ps.Length == 0) {
      Console.WriteLine("Nenhuma matricula cadastrada");
      return;
    }
    foreach(Matricula p in ps) Console.WriteLine(p);
    Console.WriteLine();  
  }
  public static void MatriculaInserir() {
    Console.WriteLine("----- Inserção de matriculas -----");
    Console.Write("Informe um código para a matricula: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    
    AlunoListar();
    Console.Write("Informe o código do aluno com a matricula: ");
    int idaluno = int.Parse(Console.ReadLine());
    // Seleciona a categoria a partir do id
    Aluno c = naluno.Listar(idaluno);    
    // Instanciar a classe de Produto
    Matricula p = new Matricula(id, descricao, c);
    // Inserção da produto
    nmatricula.Inserir(p);
  }

}

/*
//Classe principal
class MainClass
{
    public static void Main()
    {
        Curso c1 = new Curso(1, "TADS");
        Curso c2 = new Curso(2, "REDES");
        Console.WriteLine(c1);
        Console.WriteLine(c2);

        Matricula m1 = new Matricula(20191014040076, "Ativa");
        Matricula m2 = new Matricula(20191014040004, "Ativa");
        Matricula m3 = new Matricula(20151014040016, "Ativa");
        Matricula m4 = new Matricula(20191014040010, "Cancelada");
        Console.WriteLine(m1);
        Console.WriteLine(m2);
        Console.WriteLine(m3);
        Console.WriteLine(m4);

        Aluno a1 = new Aluno(001, "Joana", "Rua Dois, 00", 990225632, m1);
        Aluno a2 = new Aluno(002, "Virginia", "Rua Três, 05", 990725633, m2);
        Aluno a3 = new Aluno(003, "Christian", "Rua Quatro, 08", 995225634, m4);
        Console.WriteLine(a1);
        Console.WriteLine(a2);
        Console.WriteLine(a3);

        m1.AlunoInserir(a1);
        m2.AlunoInserir(a2);
        m3.AlunoInserir(a2);
        m4.AlunoInserir(a3);

        Aluno[]v = m1.AlunoListar();
        Console.Write("Alunos com matricula: ");
        Console.WriteLine(m1.GetId());
        foreach (Aluno a in v) Console.WriteLine(a);

        Console.WriteLine();
        v = m2.AlunoListar();
        Console.Write("Alunos com matricula: ");
        Console.WriteLine(m2.GetId());
        foreach (Aluno a in v) Console.WriteLine(a);

        Console.WriteLine();
        v = m3.AlunoListar();
        Console.Write("Alunos com matricula: ");
        Console.WriteLine(m3.GetId());
        foreach (Aluno a in v) Console.WriteLine(a);

        Console.WriteLine();
        v = m4.AlunoListar();
        Console.Write("Alunos com matricula cancelada: ");
        Console.WriteLine(m4.GetId());
        foreach (Aluno a in v) Console.WriteLine(a);
    }
}

*/

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
//Classe Aluno
class Aluno {
  private int id;
  private string nome;
  private string endereco;
  private int telefone;
  private Matricula[] matriculas = new Matricula[10];
  private int np;
  public Aluno (int id, string nome, string endereco, int telefone) {
    this.id = id;
    this.nome = nome;
    this.endereco = endereco;
    this.telefone = telefone;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetEndereco(string endereco) {
    this.endereco = endereco;
  }
  public void SetTelefone(int telefone) {
    this.telefone = telefone;
  }
  public int GetId() {
    return id;
  }
  public string GetNome() {
    return nome;
  }
  public string GetEndereco() {
    return endereco;
  }
  public int GetTelefone() {
    return telefone;
  }
  public Matricula[] MatriculaListar() {
    Matricula[] c = new Matricula[np];
    Array.Copy(matriculas, c, np);
    return c;
  }
  public void MatriculaInserir(Matricula p) {
    if (np == matriculas.Length) {
      Array.Resize(ref matriculas, 2 * matriculas.Length);
    }
    matriculas[np] = p;
    np++;
  }
  public override string ToString() {
    return id + " - " + nome + " - Nº produtos: " + np;
  }
}
//Classe de Matricula
class Matricula {
  private int id;
  private string descricao;
  private Aluno aluno;
  public Matricula(int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  public Matricula(int id, string descricao, Aluno aluno) : this(id, descricao) {
    this.aluno = aluno;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public void SetAluno(Aluno aluno) {
    this.aluno = aluno;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  
  public Aluno GetAluno() {
    return aluno;
  }
  public override string ToString() {
    if (aluno == null)
      return id + " - " + descricao;
    else  
      return id + " - " + descricao + " - " + aluno.GetDescricao();

    /*
    public Aluno[] AlunoListar()
    {
        Aluno[] c = new Aluno[np];
        Array.Copy(alunos, c, np);
        return c;
    }

    public void AlunoInserir (Aluno a)
    {
        if(np ==alunos.Length) {
            Array.Resize(ref alunos, 2 * alunos.Length);
        }
        alunos[np] = a;
        np++;
    }
    public override string ToString()
    {
        return "Matrícula: " + id + " - " + "Tipo: " + descricao;
    }
    */
}
}


class NAluno {
  private Aluno[] alunos = new Aluno[10];
  private int nc;

  public Aluno[] Listar() {
    Aluno[] c = new Aluno[nc];
    Array.Copy(alunos, c, nc);
    return c;
  }

  public Aluno Listar(int id) {
    for (int i = 0; i < nc; i++)
      if (alunos[i].GetId() == id) return alunos[i];
    return null;  
  }

  public void Inserir(Aluno c) {
    if (nc == alunos.Length) {
      Array.Resize(ref alunos, 2 * alunos.Length);
    }
    alunos[nc] = c;
    nc++;
  } 

}

class NMatricula {
  private Matricula[] matriculas = new Matricula[10];
  private int np;

  public Matricula[] Listar() {
    Matricula[] p = new Matricula[np];
    Array.Copy(matriculas, p, np);
    return p;
  }

  public Matricula Listar(int id) {
    for (int i = 0; i < np; i++)
      if (matriculas[i].GetId() == id) return matriculas[i];
    return null;  
  }

  public void Inserir(Matricula p) {
    if (np == matriculas.Length) {
      Array.Resize(ref matriculas, 2 * matriculas.Length);
    }
    matriculas[np] = p;
    np++;
    // Recuperar a categoria do produto que está sendo inserido
    Aluno c = p.GetAluno();
    if (c != null) c.MatriculaInserir(p);
  } 
  }
