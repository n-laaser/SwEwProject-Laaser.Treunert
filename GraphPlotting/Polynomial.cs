public class Polynomial
{
    public Random rnd = new Random(); // Seed für das generieren des Zufälligen faktors und der Nullstellen

    private bool rationalzeros; // Gibt an ob die Nullstellen des Polynoms ganzzahlig (false) oder rational (true) [Eingabe durch Benutzer]

    private int degree; // Gibt den Grad des Polynoms und somit auch die Anzahl der nullstellen an [Eingabe durch Benutzer]

    private double rndfactor; // Zufälliger Faktor, damit Koeffizient von x^degree auch ungleich 1 sein kann (Nullstellen bleiben unverändert)

    private double[] zeros; // Array der Nullstellen (Reihenfolge unwichtig, zeros.length == degree )

    private double[] coeffs; // Array der Koeffizienten f(x)=a*x^2+b*x+c aufsteigende Reihenfolge {c,b,a}  

    public string funcstring; // das polynom als string (zur Ausgabe im GUI) 

    public Polynomial(bool rationalzeros_n, int degree_n)
    {
        rationalzeros = rationalzeros_n;
        degree = degree_n;
        zeros = genZeros(rationalzeros_n, degree_n);
        rndfactor = Convert.ToDouble(rnd.Next(-5, 5));
        if (rndfactor == 0)
        { // 0*f(x) ist trivial
            rndfactor = 1;
        }
        coeffs = calcCoeffs(zeros);
        funcstring = makeFuncstring(coeffs);

    }

    public bool Rationalzeros
    {
        get { return rationalzeros; }
        set { rationalzeros = value; }
    }
    public int Degree
    {
        get { return degree; }
        set { degree = value; }
    }
    public double[] Zeros
    {
        get { return zeros; }
    }
    public double[] Coeffs
    {
        get { return coeffs; }
    }
    public string Funcstring
    {
        get { return funcstring; }
    }

    private double[] genZeros(bool rationalzeros_n, int degree_n)
    {
        double[] zeros = new double[degree_n]; // initialisieren des Nullstellen-Arrays (Anzahl der Nullstellen = Grad der Funktion) 
        for (int i = 0; i < degree_n; i++)
        {
            zeros[i] = rnd.Next(-50, 50); // Zufallszahlen für Nullstelle generieren (Zähler)
                                          //Console.WriteLine(zeros[i].ToString()+":genZerosTestNat");
            if (rationalzeros_n == true)
            {
                zeros[i] /= rnd.Next(1, 8); // Nenner generieren (falls Nullstelle rational sein soll)
            }
            //Console.WriteLine(zeros[i].ToString()+":genZerosTestRat"); 

        }
        return zeros;
    }
    private double[] calcCoeffs(double[] zeros)
    {
        double[] coeffs = new double[zeros.Length + 1]; // Immer ein Koeffizient mehr als Nullstellen
        double a;
        double b;
        double c;
        double d;
        double e;
        double factor = this.rndfactor; // zufälliger Skalierungsfaktor (ändert nichts an den Nullstellen)
        switch (zeros.Length)
        { // SwitchCase um Koeffizienten für unterschiedliche Grade zu berechnen 
          //(Formeln entsprechen der ausmultiplizierter Linearfaktorzerlegung mal dem rndfactor: sodass coeffs[0]*x^0 und coeffs[n]*x^n; Anzahl der Linearfaktoren == degree == zeros.length)
            case 1:
                a = zeros[0];
                coeffs[0] = factor * -a;
                coeffs[1] = factor * 1;
                return coeffs;

            case 2:
                a = zeros[0];
                b = zeros[1];
                coeffs[0] = factor * (a * b);
                coeffs[1] = factor * (-a - b);
                coeffs[2] = factor * 1;
                return coeffs;

            case 3:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                coeffs[0] = factor * (-a * b * c);
                coeffs[1] = factor * (a * b + a * c + c * b);
                coeffs[2] = factor * (-a - b - c);
                coeffs[3] = factor * 1;
                return coeffs;

            case 4:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                d = zeros[3];
                coeffs[0] = factor * (a * b * c * d);
                coeffs[1] = factor * (a * c * (-b - d) + b * d * (-a - c));
                coeffs[2] = factor * (a * (b + c + d) + b * (d + c) + c * d);
                coeffs[3] = factor * (-a - b - c - d);
                coeffs[4] = factor * 1;
                return coeffs;

            case 5:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                d = zeros[3];
                e = zeros[4];
                coeffs[0] = factor * (-a * b * c * d * e);
                coeffs[1] = factor * (a * b * (c * d + c * e + d * e) + c * d * e * (a + b));
                coeffs[2] = factor * (a * b * (-c - d - e) + c * d * (-a - b - e) + c * e * (-a - b) + d * e * (-a - b));
                coeffs[3] = factor * (a * (b + c + d + e) + b * (c + d + e) + c * (d + e) + d * e);
                coeffs[4] = factor * (-a - b - c - d - e);
                coeffs[5] = factor * 1;
                return coeffs;

            default: return coeffs;
        }
    }
    private string makeFuncstring(double[] coeffs)
    {
        string funcstring = ""; // Funktions String initialisieren
        for (int i = coeffs.Length - 1; i >= 0; i--)
        {// String zusammensetzen
            if ((coeffs[i] > 0) && (i != coeffs.Length - 1))
            { // "+" Operator einfügen wo kein "-" oder höchster Grad ist
                funcstring += "+";
            }
            else if (coeffs[i] == -1)
            { // oder bei -1 nur ein "-" einfügen
                funcstring += "-";
            }
            if (coeffs[i] != 0 && coeffs[i] != 1 && coeffs[i] != -1)
            {// Koeffizient als Zahl nur nötig wenn coeffs[i] != 1,-1 oder 0
                funcstring += Math.Round(coeffs[i],5).ToString();// Koeffizient wird rechts an den bestehenden string addiert
            }
            if (coeffs[i] != 0 && i != 0)
            {// x mit Exponent hinzufügen 
                funcstring += "x" + ToSuperScript(i);
            }

        }
        return funcstring;
    }

    public double F(double x)
    { // Funktion um das Polynom von Form1 aus aufzurufen man schreibt: var poly = new Polynomial(rationalzeros, degree); poly.F(3) --> gibt den wert der generierten Funktion an der Stelle x=3 aus
        double y = this.rndfactor; // zufälliger faktor
        for (int i = 0; i < zeros.Length; i++)
        {
            y = y * (x - this.zeros[i]);
        }
        return y;
    }
// Funktion von StackOverflow Link: https://stackoverflow.com/questions/17704169/how-to-write-superscript-in-a-string-and-display-using-messagebox-show
     
    static private string ToSuperScript(int number) // Funktion um beliebige Superscript Zahlen als string nutzen zu können
    {
        if (number == 0 ||
            number == 1)
            return "";

        const string SuperscriptDigits =
            "\u2070\u00b9\u00b2\u00b3\u2074\u2075\u2076\u2077\u2078\u2079";

        string Superscript = "";

        if (number < 0)
        {
            //Superscript Minus
            Superscript = ((char)0x207B).ToString();
            number *= -1;
        }


        Superscript += new string(number.ToString()
                                        .Select(x => SuperscriptDigits[x - '0'])
                                        .ToArray()
                                  );

        return Superscript;
    }

}
