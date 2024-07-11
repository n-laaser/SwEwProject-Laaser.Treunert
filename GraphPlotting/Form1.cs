using Microsoft.VisualBasic.ApplicationServices;
using ScottPlot;
using ScottPlot.Colormaps;
using ScottPlot.Plottables;
using ScottPlot.Rendering.RenderActions;
using System.Collections;
using System.Text;
using Color = ScottPlot.Color;


namespace GraphPlotting
{
    public partial class Form1 : Form
    {
        
        //Grad der Funktion
        int degree;
        //rationale Nullstellen ja/nein
        bool rationalzeros;
        //Nullstellen unserer Funktion
        double[] zeros = { 1, 2, 3, 4, 5 };
        //ArrayList mit nicht in der Lösung angegebenen Nullstellen
        ArrayList missingzeros = new ArrayList();

        Polynomial function = new Polynomial(false, 5);

        //Notwendige Funktionen für ScottPlot
        public Form1()
        {
            InitializeComponent();
        }

        //Sorgt für die Darstellung von Exponenten (ist sonst nur bis hoch 3 möglich)
        public string ToSuperScript(int number)
        {
            if (number == 0 || number == 1)
                return "";
            const string SuperscriptDigits = "\u2070\u00b9\u00b2\u00b3\u2074\u2075\u2076\u2077\u2078\u2079";
            string Superscript = "";
            if (number < 0)
            {
                //Adds superscript minus
                Superscript = ((char)0x207B).ToString();
                number *= -1;
            }
            Superscript += new string(number.ToString().Select(x => SuperscriptDigits[x - '0']).ToArray());
            return Superscript;
        }

        //Anzeigen ob die Eingaben in den Textfeldern den korrekten Nullstellen entspricht (richtig/falsch)
        public void AnswerInZeros(TextBox t_box)
        {   
            for (int i = 0; i < zeros.Length; i++)
            {
                if (t_box.Text == zeros[i].ToString())
                {
                    t_box.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);//richtige Antwort = Grün
                    missingzeros.Remove(t_box.Text);
                    //Nachdem die Antwort in Zeros gefunden wurde, Schleife verlassen
                    break;
                }
                else
                {
                    t_box.BackColor = System.Drawing.Color.FromArgb(255, 100, 100);//Falsche Antwort = helles Rot
                }
            }
        }


        //Ab hier Labels,Buttons etc.
        
        //Auswahl des Funktionsgrades durch die ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Grad der Funktion wird eingelesen
            degree = Convert.ToInt32(ComboBox.Items[ComboBox.SelectedIndex]);

        }
        //Eine Checkbox, welche angibt ob man rationale Nullstellen haben möchte 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rationalzeros = checkBox.Checked;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Nach Eingabe von Grad,ganzen/rationalen Nullstellen
            //und drücken von "Lade Funktion" kann man alle drei Objekte nicht mehr verändern
            ComboBox.Enabled = false;
            checkBox.Enabled = false;
            LoadFunction.Enabled = false;

            function = new Polynomial(rationalzeros, degree);

            zeros = function.Zeros;
            //Wenn "Lade Funktion" gedrückt wurde, wird Funktion geladen und angezeigt
            TestLabel.Text = degree.ToString();//Zur Ausgabe von Werten, nur testweise

            Function.Text = function.funcstring;
            FunctionLabel.Visible = true;
            Function.Visible = true;
            AnswerLabel.Visible = true;
            SolutionButton.Visible = true;
            

            //Je nach angegebenem Grad wird nur eine bestimmte Menge an Lösungen zugelassen
            switch (degree)
            {
                case 1:
                    textBox1.Visible = true;
                    break;
                case 2:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    break;
                case 3:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    break;
                case 4:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    break;
                case 5:
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    break;
                default:
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            double x_min = -20;
            double x_max = 20;
            double step = 0.01;
            double[] x_value = new double[4000];
            double[] y_value = new double[4000];
            for (int i = 0; x_min <= x_max; x_min += step ,i++)
            {
                x_value[i] = x_min;
                y_value[i] = function.F(x_min);
            }
            TestLabel.Text = x_value[0].ToString();
            var v1 = ploti.Plot.Add.VerticalLine(0);
            var v2 = ploti.Plot.Add.HorizontalLine(0);
            v1.Color = Colors.Black;
            v2.Color = Colors.Black;
            ploti.Plot.Add.Scatter(x_value, y_value);
            ploti.Refresh();
        }

        private void SolutionButton_Click(object sender, EventArgs e)
        {
            //Wenn "Lösung anzeigen" gedrückt wurde
            Solution.Visible = true;
            ploti.Visible = true;
            RestartButton.Visible = true;

            //Sicherstellen Solution.Text nur "Nullstellen" anzeigt
            Solution.Text = "Noch fehlende Nullstellen: ";
            //Zeros in Missingzeros kopieren
            missingzeros.Clear();  
            foreach(double i in zeros)
            {
                missingzeros.Add(i.ToString());
            }

            //Um nur mögliche Lösungfelder anzusteuern
            switch (degree)
            {
                case 1:
                    AnswerInZeros(textBox1);
                    break;
                case 2:
                    AnswerInZeros(textBox1);
                    AnswerInZeros(textBox2);
                    break;
                case 3:
                    AnswerInZeros(textBox1);
                    AnswerInZeros(textBox2);
                    AnswerInZeros(textBox3);
                    break;
                case 4:
                    AnswerInZeros(textBox1);
                    AnswerInZeros(textBox2);
                    AnswerInZeros(textBox3);
                    AnswerInZeros(textBox4);
                    break;
                case 5:
                    AnswerInZeros(textBox1);
                    AnswerInZeros(textBox2);
                    AnswerInZeros(textBox3);
                    AnswerInZeros(textBox4);
                    AnswerInZeros(textBox5);
                    break;
                default:
                    break;
            }
            //Alle nicht selbst angegebenen Nullstellen anzeigen 
            foreach(string s in missingzeros)
            {
                Solution.Text += " "+s;
            }


        }
        //Neustarten der Application durch den "Nochmal" Button
        private void RestartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
