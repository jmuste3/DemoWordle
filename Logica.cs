
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DemoWordle
{

    internal class Partida //: INotifyPropertyChanged
    {
        private string _paraulaSecreta;
        private int _maxIntents = 6;
        private int _longitudParaula = 5;
        private int _filaActual = 0;
        private int _columnaActual = 0;
        private bool _partidaIniciada = false;
        //private char[] _Intents = new char[30];
        //private Color[] _Colors = new Color[30];
        public DataTable lletres;
        public DataTable colors;

        private string _missatge { get; set; } = "Benvingut al Wordle. Introdueix una nova paraula.";

        //public event PropertyChangedEventHandler PropertyChanged; //gestor events propertychanged

        public string missatge
        {
            get { return _missatge; }
            set
            {
                if (_missatge != value)
                {
                    _missatge = value;
                    //OnPropertyChanged("missatge");
                }
            }
        }
        public int filaActual
        {
            get { return _filaActual; }
            private set
            {
                if (_filaActual != value)
                {
                    _filaActual = value;
                    //OnPropertyChanged("filaActual");
                }
            }
        }

        public int columnaActual
        {
            get { return _columnaActual; }
            private set
            {
                if (_columnaActual != value)
                {
                    _columnaActual = value;
                    //OnPropertyChanged("columnaActual");
                }
            }
        }

        public bool partidaIniciada
        {
            get { return _partidaIniciada; }
            private set { _partidaIniciada = value; }
        }

        //constructor
        public Partida( int maxIntents)
        {
            if (maxIntents <= 0)
            {
                throw new ArgumentException("El número màxim d'intents ha de ser major que 0");
            }
            _paraulaSecreta = "";
            _maxIntents = maxIntents;
            _filaActual = 0;
            _columnaActual = 0;
            partidaIniciada = false; //no inicia partida
            lletres = new DataTable();
            colors=new DataTable();

            for (int i = 0; i < 5; i++)
            {
                lletres.Columns.Add();
                var colorscolumn = new DataColumn();
                colorscolumn.DataType = typeof(Color);
                colors.Columns.Add(colorscolumn);
            }

            for (int i = 0; i < 6; i++)
            {
                DataRow filaLletres = lletres.NewRow();
                DataRow filaColors = colors.NewRow();
                

                for (int j = 0; j < 5; j++)
                {
                    filaLletres[j] = "_";
                    filaColors[j] = Color.White;
                }

                lletres.Rows.Add(filaLletres);
                colors.Rows.Add(filaColors);
            }
        }

        //escriure lletra actual
        public void EscriureLletra(string lletra)
        {
            if (columnaActual < _longitudParaula) //actualitzar lletres si no ha arribat al límit
            {
                //Intents[filaActual*5+columnaActual] = lletra; //assigna la lletra
                //Colors[filaActual*5+columnaActual] = Color.Blue; //canvia el color de la lletra que s'ha escrit
                this.lletres.Rows[filaActual][columnaActual] = lletra;
                this.colors.Rows[filaActual][columnaActual] = Color.LightBlue;
                columnaActual++;
                _missatge = "Fila:" + filaActual + " Columna:" + columnaActual;
            }
            if (columnaActual == _longitudParaula) //si es verifica aquí supera la última posició
            {
                _missatge = "Vols verificar la paraula?";
            }
        }



        //verificar la paraula
        public bool VerificarParaula()
        {
            bool[] lletraEncertada = new bool[_longitudParaula];
            bool[] posicioEncertada = new bool[_longitudParaula];
            bool paraulaEncertada = true;

            // Comprovar lletres encertades i les seves posicions
            for (int columna = 0; columna < _longitudParaula; columna++)
            {
                string lletra = (string)lletres.Rows[filaActual][columna];
                if (_paraulaSecreta.Contains(lletra))
                {
                    int posicio = _paraulaSecreta.IndexOf(lletra);
                    if (posicio == columna)
                    {
                        
                        lletraEncertada[columna] = true;

                        posicioEncertada[columna] = true;
                    }
                    else
                    {
                        
                        lletraEncertada[columna] = true;
                    }
                }
            }

            // Actualitzar colors segons lletra i posició encertades
            for (int columna = 0; columna < _longitudParaula; columna++)
            {
                if (lletraEncertada[columna])
                {
                    if (posicioEncertada[columna])
                    {
                        this.colors.Rows[filaActual][columna] = Color.Green;
                    }
                    else
                    {
                        this.colors.Rows[filaActual][columna] = Color.Orange;
                        paraulaEncertada = false;
                    }
                }
                else
                {
                    this.colors.Rows[filaActual][columna] = Color.LightGray;
                    paraulaEncertada = false;
                }
            }

            // Actualitzar missatge segons si la paraula està encertada o no
            if (paraulaEncertada)
            {
                missatge = "Has encertat la paraula!";
                partidaIniciada = false;
                return true;
            }
            else
            {
                filaActual++;
                columnaActual = 0;
                if (filaActual == _maxIntents)
                {
                    missatge = "Has perdut. La paraula era " + _paraulaSecreta;
                    partidaIniciada = false;
                }
                else
                {
                    missatge = "La paraula no és correcta. Intenta-ho de nou.";
                }
                return false;
            }
        }

        //esborrar lletra
        public void EsborrarLletra()
        {
            if (columnaActual > 0)
            {
                columnaActual--;
                //Intents[filaActual*5+ columnaActual] = ' ';
                //Colors[filaActual*5+ columnaActual] = Color.White;
                this.lletres.Rows[filaActual][columnaActual] = " ";
                this.colors.Rows[filaActual][columnaActual] = Color.White;

                _missatge = "Fila:" + filaActual + " Columna:" + columnaActual;

            }
        }
        //reiniciar partida
        public void Reiniciar(string paraulaSecreta)
        {
            if (string.IsNullOrEmpty(paraulaSecreta) || paraulaSecreta.Length != 5)
            {
                throw new ArgumentException("La paraula ha de tenir 5 caracters");
            }
            _paraulaSecreta =  paraulaSecreta.ToUpper();
            _paraulaSecreta = paraulaSecreta;
            _filaActual = 0;
            _columnaActual = 0;
            _missatge = "Tria NOVA PARTIDA per començar";
            //inicialitzar lletres i colors
            // omplir les 6 files dels DataTables amb guions i blanc
            for (int fila = 0; fila < 6; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    this.lletres.Rows[fila][columna] = '.';
                    this.colors.Rows[fila][columna] = Color.White;
                }
            }
        }
    }

}

