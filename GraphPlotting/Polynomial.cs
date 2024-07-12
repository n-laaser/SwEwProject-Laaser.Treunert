using System.CodeDom;
using System.Reflection.Emit;

public class Polynomial{
    public Random rnd = new Random();
    bool rationalzeros;
    int degree;
    double[] coeffs;
    double[] zeros;
    public string funcstring;
    double rndfactor;
    public Polynomial(bool rationalzeros_n, int degree_n){
        rationalzeros = rationalzeros_n; 
        degree = degree_n; 
        zeros = genZeros(rationalzeros_n,degree_n);
        rndfactor = Convert.ToDouble(rnd.Next(-5,5))/Convert.ToDouble(rnd.Next(1,5));
        Console.WriteLine(rndfactor);
            if(rndfactor==0){
                rndfactor=1;
            }
        coeffs = calcCoeffs(zeros);
        funcstring = makeFuncstring(coeffs);
        
        }
    
    public bool Rationalzeros{
        get{return rationalzeros;}
        set{rationalzeros=value;}
    }
    public int Degree{
        get{return degree;}
        set{degree=value;}
    }
    public double[] Coeffs{
        get{return coeffs;}
    }
    public double[] Zeros{
        get{return zeros;}
        }
    public string Funcstring{
        get{return funcstring;}
    }
    
    double[] genZeros(bool rationalzeros_n, int degree_n){
        double[] zeros= new double[degree_n]; // Länge angegeben weil dynamisches array irgendwie nicht funktioniert
        for(int i=0; i<degree_n; i++){
                zeros[i] = rnd.Next(-10,10); // Zufallszahlen für Nullstelle generieren (Zähler)
                Console.WriteLine(zeros[i].ToString()+":genZerosTestNat");
        if (rationalzeros_n==true){
                zeros[i]/=rnd.Next(1,10); // Nenner generieren (falls zahl rational sein soll)
        }
        Console.WriteLine(zeros[i].ToString()+":genZerosTestRat");
        
        }
        
        //eventuell Sortieralgorithmus auf array anwenden
        return zeros;
    }
    double[] calcCoeffs(double[] zeros){
        double[] coeffs= new double[zeros.Length+1];
        double a;
        double b;
        double c;
        double d;
        double e;
        double factor = this.rndfactor;
        switch(zeros.Length){ // SwitchCase um Koeffizienten für unterschiedliche Grade zu berechnen
            case 1:
                a = zeros[0];
                coeffs[0]=factor*-a;
                coeffs[1]=factor*1;
                return coeffs;
            
            case 2:
                a = zeros[0];
                b = zeros[1];
                coeffs[0]=factor*(a*b);
                coeffs[1]=factor*(-a-b);
                coeffs[2]=factor*1;
                return coeffs;
            
            case 3:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                coeffs[0]=factor*(-a*b*c);
                coeffs[1]=factor*(a*b+a*c+c*b);
                coeffs[2]=factor*(-a-b-c);
                coeffs[3]=factor*1;
                return coeffs;
            
            case 4:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                d = zeros[3];
                coeffs[0]=factor*(a*b*c*d);
                coeffs[1]=factor*(a*c*(-b-d)+b*d*(-a-c));
                coeffs[2]=factor*(a*(b+c+d)+b*(d+c)+c*d);
                coeffs[3]=factor*(-a-b-c-d);
                coeffs[4]=factor*1;
                return coeffs;
            
            case 5:
                a = zeros[0];
                b = zeros[1];
                c = zeros[2];
                d = zeros[3];
                e = zeros[4];
                coeffs[0] =factor*(-a*b*c*d*e);
                coeffs[1] =factor*(a*b*(c*d+c*e+d*e)+c*d*e*(a+b));
                coeffs[2] =factor*(a*b*(-c-d-e)+c*d*(a-b-e)+c*e*(-a-b)+d*e*(-a-b));
                coeffs[3] =factor*(a*(b+c+d+e)+b*(c+d+e)+c*(d+e));
                coeffs[4] =factor*(-a-b-c-d-e);
                coeffs[5] =factor*1;
                return coeffs;
            
            default: return coeffs;
        }
    }
    string makeFuncstring(double[] coeffs){
        string funcstring = ""; // Funktions String initialisieren
        for(int i=coeffs.Length-1;i>=0;i--){// String zusammensetzen
            if((coeffs[i]>0) && (i!=coeffs.Length-1)){ // "+" Operator einfügen wo kein "-" oder höchster Grad ist
                funcstring += "+";
            }else if(coeffs[i]==-1){ // oder bei -1 nur ein "-" einfügen
                funcstring += "-";
            }
            if(coeffs[i]!=0 && coeffs[i]!=1 && coeffs[i]!=-1){// Koeffizient nur nötig wenn != 1,-1 oder 0
                funcstring += coeffs[i].ToString();// Koeffizient wird rechts an den bestehenden string addiert
            }
            if(coeffs[i]!=0 && i!=0){// x mit Exponent hinzufügen 
                funcstring += "x"+ToSuperScript(i); 
                }
            
        }
        return funcstring;
    }

    public double F(double x){
        double y=this.rndfactor;
        for(int i=0;i<zeros.Length;i++){
        y =y* (x-this.zeros[i]);
        }
        return y;
    }

    static private string ToSuperScript(int number) // Funktion um beliebige superscript nummern nutzen zu können
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