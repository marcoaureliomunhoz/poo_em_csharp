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

**Classes Estáticas:** ao marcar uma classe como estática seus membros devem ser estáticos. Neste caso a classe estática não pode ser extendida (herança) e nem instanciada. A classe estática é instanciada para a memória quando a aplicação entra em execução e fica disponível para acesso através do "nome da classe".

```csharp
public static Calculadora
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
public Calculadora
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

