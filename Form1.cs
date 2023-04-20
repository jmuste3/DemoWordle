using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace DemoWordle
{
    public partial class Form1 : Form
    {
        private Partida wordle;
        private BindingSource bsLabel;
        private List<Button> btnList = new List<Button>(); //Llista per gestionar el teclat

        public Form1()
        {
            InitializeComponent();

            //millora: gestor d'excepcions

            //preparar controls per nova partida
            textBoxParaula.Text = "";
            textBoxParaula.Enabled = false;
            buttonPartida.Enabled = false;
            buttonNou.Enabled = true;
            //afegir teclat en pantalla
            AddKeyboard();
            DisableKeyboard();
            //objecte amb les dades i la lògica de la partida
            wordle = new Partida(6); //6 intents com a màxim
            // DataBindings
            bsLabel = new BindingSource();
            bsLabel.DataSource = wordle;
            labelMissatges.DataBindings.Add("Text", bsLabel, "missatge"); //missatges sobre la partida
            dataGridView1.DataSource = wordle.lletres;

            //configurar propietats del dataGrid
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 16);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //gestionar event teclat en pantalla
        public void ClickButton(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            wordle.EscriureLletra(btn.Text);
            //actualitzar bindings
            bsLabel.ResetBindings(false);
        }

        private void ClickCHECK(object sender, EventArgs e)
        {
            //actualitzar binding
            bsLabel.ResetBindings(false);
            bool haGuanyat = wordle.VerificarParaula();
            dataGridView1.Invalidate(); //forçar redibuixar
            if (haGuanyat) //ha encertat la paraula
            { 
                MessageBox.Show("Enhorabona, has encertat la paraula", "WordleDemo");
            }
        }

        private void ClickDEL(object sender, EventArgs e)
        {
            //esborrar la ultima lletra
            wordle.EsborrarLletra();
            //actualitzar bindings
            bsLabel.ResetBindings(false);
        }

        //funció auxiliar per crear el teclat en pantalla
        private void AddKeyboard()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26
            // Create (26) Buttons + 2 for DEL and CHECK
            
            for (int i = 0; i < 26; i++)
            {
                // Initialize one variable
                btnList.Add(new Button ());
            }
            int n = 0;

            while (n < 26)
            {
                btnList[n].Tag = n + 1; // Tag of button
                btnList[n].Width = 34; // Width of button
                btnList[n].Height = 40; // Height of button
                if (n == 9) // segona fila
                {
                    xPos = 0;
                    yPos = 42;
                }
                if (n == 18) // tercera fila
                {
                    xPos = 0;
                    yPos = 84;
                }
                // Location of button:
                btnList[n].Left = xPos;
                btnList[n].Top = yPos;
                // Font
                btnList[n].Font= new Font("Segoe UI", 18, FontStyle.Bold);
                // Add buttons to a Panel:
                pnlButtons.Controls.Add(btnList[n]); // Let panel hold the Buttons
                xPos = xPos + btnList[n].Width + 2; // Left of next button
                                                     // Write English Character:
                btnList[n].Text = ((char)(n + 65)).ToString();

                /* *********************************************
                You can use following code instead previous line
                char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                'W', 'X', 'Y', 'Z'}; btnArray[n].Text = Alphabet[n].ToString();
               ****************************************** */
                // the Event of click Button
                btnList[n].Click += new EventHandler(ClickButton);
                n++;
            }
            //add DEL and CHECK buttons to list for faster enable/disable
            btnList.Add(buttonDEL);
            btnList.Add(buttonCHECK);
        }

        private void DisableKeyboard()
        {
            foreach (Button btn in btnList)
            {
                btn.Enabled = false;
            }
        }

        private void EnableKeyboard()
        {
            foreach (Button btn in btnList)
            {
                btn.Enabled = true;
            }

        }

        private void buttonNou_Click(object sender, EventArgs e)
        {
            if (wordle.partidaIniciada)
            { 
                DialogResult resposta = MessageBox.Show("Ja hi ha una partida iniciada, vols començar-ne una de nova?", "Demo Wordle",MessageBoxButtons.YesNo);
                if (resposta==DialogResult.Yes) {
                    textBoxParaula.Text = "";
                    textBoxParaula.Enabled = true;
                    buttonPartida.Enabled = true;
                    buttonNou.Enabled = false;
                    EnableKeyboard();
                }
            }
            else
            {
                textBoxParaula.Text = "";
                textBoxParaula.Enabled = true;
                buttonPartida.Enabled = true;
                buttonNou.Enabled = false;
            }
        }

        private void buttonPartida_Click(object sender, EventArgs e)
        {
            if (textBoxParaula.Text.Length < 5)
            {
                MessageBox.Show("Paraula massa curta", "Demo Wordle");
            }
            else
            {
                wordle.Reiniciar(textBoxParaula.Text.ToUpper());
                textBoxParaula.Text = "";
                textBoxParaula.Enabled = false;
                buttonPartida.Enabled = false;
                buttonNou.Enabled = true;
                EnableKeyboard();

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {       
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex<6)
            {
                // Obtenir el color de la cel·la del DataTable "colors"
                Color color = (Color)wordle.colors.Rows[e.RowIndex][e.ColumnIndex];

                // Establim el color de fons de la cel·la del DataGridView
                e.CellStyle.BackColor = color;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection(); //evitar que hi hagi cel·les seleccionades
        }
    }
}
