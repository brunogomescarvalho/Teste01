bool continuar = true;

while (continuar)
{
    try
    {
        Console.Clear();
        Console.WriteLine("-- Classificador de Triângulos -- ");
        Console.WriteLine("\nDigite as medidas do triângulo.");

        double[] triangulo = new double[3];

        Console.Write("\nLado A: ");
        triangulo[0] = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nLado B: ");
        triangulo[1] = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nLado C: ");
        triangulo[2] = Convert.ToDouble(Console.ReadLine());

        BarraProgresso();
        Console.Clear();
        VerificaMedidas(triangulo);

        var classificacao = ClassificaTriangulo(triangulo);
        Console.WriteLine($"\nSeu triângulo é do tipo: {classificacao}.\n");
        var resposta = "";

        do
        {
            Console.WriteLine("Deseja Continuar? [S/N]");
            resposta = Console.ReadLine();

            if (resposta!.ToUpper() == "N")
            {
                continuar = false;
            }
            Console.Clear();

        } while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }
}


string ClassificaTriangulo(double[] triangulo)
{
    var lados = new HashSet<double>(triangulo);
    var ladosRepetidos = triangulo.Length - lados.Count;

    if (ladosRepetidos == 1)
    {
        return "Isósceles";
    }
    else if (ladosRepetidos == 2)
    {
        return "Equilátero";
    }
    else
        return "Escaleno";
}

void VerificaMedidas(double[] triangulo)
{
    var valoresOrdenados = triangulo.OrderByDescending(t => t).ToArray();

    var maiorValor = valoresOrdenados[0];
    var valorCentral = valoresOrdenados[1];
    var menorValor = valoresOrdenados[2];

    var valorAceito = (menorValor + valorCentral) > maiorValor;

    if (!valorAceito)
    {
        throw new Exception("Triângulo Inválido.\n\nTecle para continuar...");
    }
}

void BarraProgresso()
{
    Console.Clear();
    Console.Write("Aguarde.");
    for (var i = 0; i < 3; i++)
    {
        Thread.Sleep(700);
        Console.Write(".");
    }
}