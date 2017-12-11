# Programação Orientada a Objetos em C#

O paradigma da programação orientada a objetos quando bem aplicada promove uma série de vantagens.

* Reutilização de código.
* Redução do número de linhas de código.
* Separação de responsabilidades.
* Organização do código.
* Encapsulamento.
* Polimorfismo.
* Herança.
* Flexibilidade dentre tantas outras vantagens.

### Conceitos da POO

**Classe:** define as características e o comportamento de um objeto.

**Objeto:** instância de uma classe em memória.

**Variável de Objeto:** espaço de memória que aponta para um objeto.

**Modificadores de Classes:** definem as regras de acesso de uma classe.

Modificador | Descrição
--- | ---
**public** | Visível para todos.
**internal** | Visível apenas dentro do mesmo assembly (dll). É o modificador padrão no C# para classes.

**Membros de Classe:** temos como membros de classe:
- Atributos tipo Campo
- Atributos tipo Propriedade
- Métodos tipo Procedimento
- Métodos tipo Função

Membro | Descrição
--- | ---
Campo | Nada mais é do que uma variável _public_.
Propriedade | É uma maneira de aplicar encapsulamento em atributos. É uma forma mais sofisticada de lidar com atributos.
Procedimento | Nada mais é do que um método sem retorno, ou seja, do tipo _void_.
Função | É um método que retorna valor ou referência.

> Exemplos:
```csharp
class Carro 
{ 
    //campo = variável pública (convenção camelCase)
    public int numeroDeMarchas = 5;

    //variável interna = private
    string _nome = "";
    //propriedade (convenção PascalCase)
    public string Nome 
    { 
        get 
        {
            return _nome;
        } 

        set 
        {
            _nome = value;
        }
    }

    //propriedade "auto properties"
    public string Modelo { get; set; }
```

**Modificadores de Membros de Classes:** definem as regras de acesso e de herança de um membro de classe.

Modificador | Descrição
--- | ---
public | O membro pode ser acessado internamente, externamente e por herança.
private | O membro só pode ser acessado dentro da classe e não fica acessível por herança.
protected | O membro só pode ser acessado dentro da classe e fica acessível por herança.
internal | O membro pode ser acessado somente dentro do mesmo assembly (dll).

> _private_ é o modificador padrão para atributos.

> _internal_ é o modificador padrão para classes.

**Classes Estáticas:** ao marcar uma classe como estática seus membros devem ser estáticos. Neste caso a classe estática não pode ser estendida (herança) e nem instanciada. A classe estática é instanciada para a memória quando a aplicação entra em execução e fica disponível para acesso através do "nome da classe".

```csharp
public static class Calculadora
{
    public static int Somar(int v1, int v2) 
    {
        return v1 + v2;
    }

    public static int Multiplicar(int v1, int v2)
    {
        return v1 * v2;
    }
}

//Usando
Calculadora.Somar(2,3);
Calculadora.Multiplicar(3,3);
```

**Classes Não Estáticas e Membros Estáticos:** ao marcar um membro como estático dentro de uma classe não estática este membro só pode ser acessado através do "nome da classe". Neste caso uma instância da classe e os membros estáticos são carregados para a memória e ficam disponíveis para acesso através do "nome da classe".

```csharp
public class Calculadora
{
    public static int contador = 0;

    public Calculadora()
    {
        contador++;
    }

    ~Calculadora()
    {
        contador--;
    }

    public int Somar(int v1, int v2) 
    {
        return v1 + v2;
    }

    public int Multiplicar(int v1, int v2)
    {
        return v1 * v2;
    }
}

//usando
Calculadora.contador; //0
Calculadora c1 = new Calculadora();
c1.Somar(2,2);
Calculadora.contador; //1
Calculadora c2 = new Calculadora();
c2.Multiplicar(2,6);
Calculadora.contador; //2
c1 = null;
GC.Collect();
GC.WaitForPendingFinalizers();
Calculadora.contador; //1
c2 = null;
GC.Collect();
GC.WaitForPendingFinalizers();
Calculadora.contador; //0
```

**Sobrecarga de Métodos:** vários métodos com mesmo nome e parâmetros diferentes.

**Sobrecarga de Construtores:** vários construtores com parâmetros diferentes.

**Herança:** é a capacidade de uma classe _filha_ herdar os atributos e métodos de uma classe _mãe_ e estender/especializar/ampliar/melhorar as características e o comportamento desta classe _mãe_.

> No c# não existe _herança múltipla_, ou seja, uma classe filha só pode ter uma classe mãe.

> Em determinadas ocasiões é desejável herdar atributos e métodos de uma classe mãe sem deixar esses atributos e métodos acessíveis na instância. Neste caso devemos utilizar o modificador de acesso _protected_.

**Encapsulamento:**: recurso que permite proteger os membros de uma classe. 

- Para esconder do mundo externo os membros de uma instância e impedir o acesso por herança devemos utilizar _private_. 
- Para esconder do mundo externo e permitir acesso por herança devemos utilizar _protected_.
- Para permitir somente a leitura de atributos devemos deixar os atributos como _private_ e devemos expor funções _public_ para retornar os atributos. Ainda é possível utilizar _auto properties_ sem o método _set_.

```csharp
public class Carro 
{
    private int _kmTotal = 0;

    public int GetKmTotal()
    {
        return _kmTotal;
    }
    //ou
    public int KmTotal 
    {
        get { return _kmTotal; }
    }

    public void Andar(int km, int velocidade)
    {
        for (var i=0; i<=km; i++)
        {
            Thread.Sleep(velocidade);
        }
        _kmTotal += km;
    }
}
```

**new vs override:** ambos nos permitem sobrescrever membros herdados em uma classe filha. Desta forma podemos modificar comportamentos e características indesejados provenientes da herança.
- new: oculta o membro marcado com _new_, porém ainda é possível acessar através da keyword _base_.
- override: substitui o membro marcado com _override_. Para marcar na classe filha um membro com _override_ o mesmo deve ser marcado na classe mãe com _virtual_.

```csharp
public class PapagaioCurintiano1
{
    public void QualSeuNome()
    {
        Console.WriteLine("É cú!");
    }
}

public class PapagaioCurintianoEducadoPorNew : PapagaioCurintiano1
{
    public new void QualSeuNome()
    {
        Console.WriteLine("É curi!");
    }

    public void FalaSerio()
    {
        base.QualSeuNome();
    }
}

public class PapagaioCurintiano2
{
    public virtual void QualSeuNome()
    {
        Console.WriteLine("É cú!");
    }
}

public class PapagaioCurintianoEducadoPorOverride : PapagaioCurintiano2
{
    public override void QualSeuNome()
    {
        Console.WriteLine("É curi!");
    }

    public void FalaSerio()
    {
        base.QualSeuNome();
    }
}

```