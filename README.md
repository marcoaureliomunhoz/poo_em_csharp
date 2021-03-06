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

**Encapsulamento:** recurso que permite proteger os membros de uma classe. 

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
- new: oculta o membro marcado com _new_.
- override: substitui o membro marcado com _override_. Para marcar na classe filha um membro com _override_ o mesmo deve ser marcado na classe mãe com _virtual_.

> Tanto para new quanto para override podemos acessar os membros da classe mãe através da keyword _base_.

```csharp
public class Papagaio1
{
    public void QualSeuNome(string nome)
    {
        Console.WriteLine("Não importa!");
    }
}

public class PapagaioEducadoPorNew : Papagaio1
{
    public new void QualSeuNome(string nome)
    {
        Console.WriteLine("É {0}!", nome);
    }

    public void FalaSerio(string nome)
    {
        base.QualSeuNome(nome);
    }
}

public class Papagaio2
{
    public virtual void QualSeuNome(string nome)
    {
        Console.WriteLine("Não importa!");
    }
}

public class PapagaioEducadoPorOverride : Papagaio2
{
    public override void QualSeuNome(string nome)
    {
        Console.WriteLine("É {0}!", nome);
    }

    public void FalaSerio(string nome)
    {
        base.QualSeuNome(nome);
    }
}
```

**Polimorfismo:** é um dos pilares da orientação a objetos e que confere a um objeto a capacidade de assumir diferentes formas.

- A sobrecarga é um tipo de polimorfismo onde um mesmo método/construtor possui várias formas (assinaturas diferentes).
- No polimorfismo por herança é possível que referências para objetos genéricos apontem para objetos especializados. Isso significa que referências mais abstratas podem assumir formas mais abstratas.

> Essa habilidade confere aos objetos mais dinamismo para representar com mais fidelidade os objetos do mundo real.

```csharp
public class Narrador 
{
    public string Lance { get; set; }

    public virtual void Narrar()
    {
        Console.WriteLine(Lance);
    }
}

public class Narrador1 : Narrador
{
    public override void Narrar()
    {
        if (Lance == "caneta") 
            Console.WriteLine("Sensacional a caneta que o Pelé deu no Maradona!");
    }
}

public class Narrador2 : Narrador
{
    public override void Narrar()
    {
        if (Lance == "caneta") 
            Console.WriteLine("Incrível o rolinho que o Pelé deu no Maradona!");
    }
}

//uso
public class Jogo 
{
    private Narrador _narrador;

    public void SetNarrador(Narrador narrador)
    {
        _narrador = narrador;
    }

    public void NovoLance(string lance)
    {
        _narrador.Lance = lance;
        _narrador.Narrar();
    }
}

//O narrador escalado para o jogo é o Neto Berolo
Narrador1 netoBerolo = new Narrador1();
//Começa o jogo
Jogo jogo = new Jogo();
jogo.SetNarrador(netoBerolo);
//Ocorre o primeiro lance
jogo.NovoLance("caneta");
//Felizmente o Neto Berolo teve uma dor de barriga daquelas e teve que ser substituído pelo Galvão Pateta
Narrador2 galvaoPatela = new Narrador2();
jogo.SetNarrador(galvaoPatela);
//Ocorre o segundo lance
jogo.NovoLance("caneta");
```

> Outras observações sobre polimorfismo:
- Repare que jogo espera um narrador genérico, mas quem de fato realiza a narração é um narrador especialista. Graças ao polimorfismo foi possível substituir o Neto Berolo pelo Galvão Pateta e ainda seria possível substituir este último por um narrador menos pior. Graças ao polimorfismo objetos diferentes podem atuar no lugar de um objeto genérico através da herança.
- É possível realizar substituições em tempo de execução e obter o mesmo resultado final de um jeito diferente.

**Tipos de Classes:** 
- **abstract**: classes abstratas não podem ser instanciadas.
- **sealed**: classes finais (seladas) não podem ser herdadas.
- **partial**: classes parciais permite dividir uma classe em vários arquivos.

**Métodos Abstratos:** um método abstrato não tem implementação, possui apenas a declaração do método. A implementação fica por conta das classes filhas.
- Classe Abstrata com Métodos Abstratos: é possível combinar métodos abstratos com classes abstratas. Neste caso todos os métodos devem ser abstratos.
- Classe Concreta com Métodos Abstratos: também é possível combinar métodos abstratos com métodos concretos em classes concretas. Neste caso os métodos concretos possuem implementação e os métodos abstratos ficam por conta das classes filhas.

**Interfaces:** estrutura abstrata que fornece apenas as especificações dos métodos e dos atributos de uma classe base. Os métodos não possuem implementação. Por padrão todos os métodos são públicos (**public**).

> A diferença entre _abstract_ e _interface_ é que com _interface_ fica claro que a estrutura não possui implementação. No caso de _abstract_ o mesmo é obtido se a classe for _abstract_.

> Ambas, classes abstratas e interfaces servem de base e podem ser usadas como "contratos" entre classes e sistemas.

```csharp
interface Repositorio 
{
    int Inserir(string registro);
    void Alterar(int id, string registro);
    void Excluir(int id);
}

public class RepositorioTxt : Repositorio
{
    public int Inserir(string registro)
    {
        //abre o arquivo
        //grava o registro no arquivo
        //retorna o número de linhas do arquivo
    }

    public void Alterar(int id, string registro)
    {
        //abre o arquivo
        //posiciona na linha
        //substitui a linha
    }

    public void Excluir(int id, string registro)
    {
        //abre o arquivo
        //posiciona na linha
        //remove a linha
    }
}
```