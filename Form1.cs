using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace PushtoTalk2
{
    public partial class GciBreaker : Form
    {

        // VARIABLES GLOBALES---------------------------------------

        private Rectangle originalFormSize = new Rectangle(0, 0, 0, 0);
        private int tamanofuenteoriginal;


        private Rectangle nextbuttonOriginalRectangle;
        private Rectangle outputspanelOriginalRectangle;
        private Rectangle inputspanelOriginalRectangle;
        private Rectangle pictureBox1OriginalRectangle;
        private Rectangle pictureBox2OriginalRectangle;
        private Rectangle scorepanelOriginalRectangle;
        private Rectangle feedbackpanelOriginalRectangle;
        private Rectangle frequencyoutOriginalRectangle;
        private Rectangle controlboxOriginalRectangle;
        private Rectangle tacticwordsOriginalRectangle;
        private Rectangle numberspanelOriginalRectangle;
        private Rectangle enviarOriginalRectangle;
        private Rectangle borrarOriginalRectangle;
        private Rectangle timepanelOriginalRectangle;
        private Rectangle closewordspanelOriginalRectangle;
        private Rectangle interceptorOriginalRectangle;
        private Rectangle identifiqueOriginalRectangle;
        private Rectangle izquierdaOriginalRectangle;
        private Rectangle derechaOriginalRectangle;
        private Rectangle angelesOriginalRectangle;
        private Rectangle tecnicaOriginalRectangle;
        private Rectangle slashlOriginalRectangle;
        private Rectangle ceroOriginalRectangle;
        private Rectangle thousandOriginalRectangle;
        private Rectangle unoOriginalRectangle;
        private Rectangle dosOriginalRectangle;
        private Rectangle tresOriginalRectangle;
        private Rectangle cuatroOriginalRectangle;
        private Rectangle cincoOriginalRectangle;
        private Rectangle seisOriginalRectangle;
        private Rectangle sieteOriginalRectangle;
        private Rectangle ochoOriginalRectangle;
        private Rectangle nueveOriginalRectangle;
        private Rectangle tacticcontrolOriginalRectangle;
        private Rectangle closecontrolOriginalRectangle;
        private Rectangle interceptortOriginalRectangle;
        private Rectangle threatOriginalRectangle;
        private Rectangle groupnameOriginalRectangle;
        private Rectangle braaOriginalRectangle;
        private Rectangle hotOriginalRectangle;
        private Rectangle flankOriginalRectangle;
        private Rectangle beamOriginalRectangle;
        private Rectangle dragOriginalRectangle;
        private Rectangle northOriginalRectangle;
        private Rectangle southOriginalRectangle;
        private Rectangle westOriginalRectangle;
        private Rectangle eastOriginalRectangle;
        private Rectangle stackOriginalRectangle;
        private Rectangle classificationOriginalRectangle;
        private Rectangle heavyOriginalRectangle;
        private Rectangle contactsOriginalRectangle;
        private Rectangle highOriginalRectangle;
        private Rectangle lowOriginalRectangle;
        private Rectangle pistaOriginalRectangle;
        private Rectangle feedbackOriginalRectangle;                
        private Rectangle label1OriginalRectangle;
        private Rectangle label2OriginalRectangle;
        private Rectangle label3OriginalRectangle;
        private Rectangle label4OriginalRectangle;
        private Rectangle buenasOriginalRectangle;
        private Rectangle malasOriginalRectangle;
        private Rectangle tiempototalOriginalRectangle;
        private Rectangle timelabelOriginalRectangle;
        private Rectangle trampaOriginalRectangle;
        private Rectangle resultadoboxOriginalRectangle;
        private Rectangle mensajeOriginalRectangle;


        //---------------------------------------------------------
        SpeechRecognitionEngine oEscucha = new SpeechRecognitionEngine();
        int good = 0;
        int wrong = 0;
        int time = 0;
        int overalltime = 0;
        int limittime = 0;

        Random aleatorio = new Random(); // declaro una variable aleatoria para usarla cuando la necesite
        Graphics papel; // establezco una variable papel de tipo graphic que sera el picturebox

        int ancho = 30; // establezco el ancho y alto de las imagenes que voy a usar para el grupo desconocido y el interceptor
        int alto = 30;
        int rangediv = 8;// valor por el que voy a dividir la distancia entre el fighter y el bogey para que no de tan grande
        int resultanteheading = 60;// establezco un valor constante para que el vector de heading tenga siempre la misma longitud
        Font font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold); // establezco una fuente para los textos que se vayan a escribir

        int clasificacion = 0;
        int contactos = 0;
        string clasifstring;

        Pen bearingline = new Pen(Color.Green);
        Pen hstline = new Pen(Color.Red);
        Pen unkhdline = new Pen(Color.Yellow);
        Pen frdhdline = new Pen(Color.Blue);
        SolidBrush colorhostil = new SolidBrush(Color.Red);
        SolidBrush colorunk = new SolidBrush(Color.Yellow);
        SolidBrush colorfrd = new SolidBrush(Color.Blue);

        Bitmap unk = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"UNK.jpg");
        Bitmap hst = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"HST.jpg");
        Bitmap frd = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"FRD.jpg");
        Bitmap live = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"live.jpg");
        Bitmap die = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"die.jpg");


        int xfrd = 0;
        int yfrd = 0;
        int xfrdhd = 0;
        int yfrdhd = 0;
        int xunk = 0;
        int yunk = 0;
        int yunkhd = 0;
        int xunkhd = 0;
        int bearingangle = 0; 
        int unkheading = 0;
        int frdheading = 0;
        double resultantebearing = 0;
        int datablockxpos, datablockypos,datablockxfrd, datablockyfrd;
        int xdif = 0; // calculo la diferencia de las coordenadas para hallar la pendiente
        int ydif = 0;
        int xdifunk = 0;
        int ydifunk = 0;
        int xdiffrd = 0;
        int ydiffrd = 0;
        string unkdatablock = "";
        string frddatablock = "";


        string alturasstr = "";
        int[] alturas = new int[] { 0, 0, 0, 0 };

        // FIN VARIABLES GLOBALES
        public GciBreaker()
        {
            InitializeComponent();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //this.WindowState = FormWindowState.Maximized;          
            mensaje.Text = "";

            MXP.URL = AppDomain.CurrentDomain.BaseDirectory + "\\ArcadeAudio.wav";
            MXP.settings.playCount = 9999; // para repetir la musica
            MXP.Ctlcontrols.play();
            MXP.Visible = false;


            closewordspanel.Enabled = false;
            tacticwordspanel.Enabled = false;
            numberspanel.Enabled = false;
            enviar.Enabled = false;
            borrar.Enabled = false;
            Pista.Enabled = false;
            Pista.Checked = false;


        }
        // PRINCIPALES------------------------------------------


        private void next_Click(object sender, EventArgs e)
        {
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\ArcadeAudio.wav";
            //player.PlayLooping();    

            if (closecontrol.Checked == true) 
            {
                limittime = 60;

                closewordspanel.Visible = true; 
                closewordspanel.Enabled = true; 
                tacticwordspanel.Visible = false;
                tacticwordspanel.Enabled = false;
            }
            else 
            {
                limittime = 90;

                closewordspanel.Visible = false;
                closewordspanel.Enabled = false;
                tacticwordspanel.Visible = true;
                tacticwordspanel.Enabled = true;
            }

            numberspanel.Enabled = true;
            numberspanel.Visible = true;
            enviar.Enabled = true;
            enviar.Visible = true;
            borrar.Enabled = true;
            borrar.Visible = true;
            Pista.Enabled = true;
            Pista.Visible = true;
            Pista.Checked = false;
            timepanel.Visible = true;
            timelabel.ForeColor = Color.LimeGreen;
            frequencyout.ForeColor = Color.LimeGreen;
          


            time = 0;
            mensaje.Text = "";
            timelabel.Text = "00";
            timer1.Start();
            //Instruccion.Text = "";
            frequencyout.Text = "";            

            papel = pictureBox1.CreateGraphics();
            papel.Clear(Color.Black);

            clasificacion = aleatorio.Next(2);
            contactos = aleatorio.Next(1,5);

            int alturafrd = aleatorio.Next(50);
            int velocidad = aleatorio.Next(200,500);



            if (clasificacion == 0) {clasifstring = "BOGUEY";classification.Text = clasifstring;}
            else {clasifstring = "HOSTILE"; classification.Text = clasifstring;}
            

            xfrd = aleatorio.Next(pictureBox1.Width - ancho); // uso la variable aleatoria para establecer coordenadas tanto de la aeronave desconocida como del interceptor
            yfrd = aleatorio.Next(pictureBox1.Height - alto);

            xunk = aleatorio.Next(pictureBox1.Width - ancho);
            yunk = aleatorio.Next(pictureBox1.Height - alto);

            //int bearingangle = aleatorio.Next(360);
            //float yunk = Yunkcalc(bearingangle, xunk, xfrd, yfrd);
            
            int randsign = aleatorio.Next(0, 2) * 2 - 1; // como los calculos son con raices cuadradas debo contemplar un signo aleatorio para cubrir 360 grados, sino solamente tendria un numero aleatorio entre 0 y 180 grados
            int randsign2 = aleatorio.Next(0, 2) * 2 - 1;

            int randsign3 = aleatorio.Next(0, 2) * 2 - 1; // como los calculos son con raices cuadradas debo contemplar un signo aleatorio para cubrir 360 grados, sino solamente tendria un numero aleatorio entre 0 y 180 grados
            int randsign4 = aleatorio.Next(0, 2) * 2 - 1;

            yunkhd = yunk + (randsign * aleatorio.Next(resultanteheading));
            xunkhd = randsign2 * ((int)Math.Round(Math.Sqrt(Math.Pow(resultanteheading, 2) - Math.Pow(yunk - yunkhd, 2)))) + xunk;// despejo el valor de la coordenada x con una longitud constante del vector de heading del bandido

            yfrdhd = yfrd + (randsign3 * aleatorio.Next(resultanteheading));
            xfrdhd = randsign4 * ((int)Math.Round(Math.Sqrt(Math.Pow(resultanteheading, 2) - Math.Pow(yfrd - yfrdhd, 2)))) + xfrd;// despejo el valor de la coordenada x con una longitud constante del vector de heading del fighter

            xdif = xfrd - xunk; // calculo la diferencia de las coordenadas para hallar la pendiente
            ydif = yfrd - yunk;

            xdifunk = xunk - xunkhd;
            ydifunk = yunk - yunkhd;

            xdiffrd = xfrd - xfrdhd;
            ydiffrd = yfrd - yfrdhd;



            resultantebearing = Math.Sqrt(Math.Pow(xdif, 2) + Math.Pow(ydif, 2));

            if (resultantebearing < 80) { next.PerformClick(); } // establezco un valor minimo para que no queden tan cerca el fighter y el bandido
            else
            {
                bearingangle = (int)Math.Round(Math.Atan2(xdif, ydif) * 180 / Math.PI); // hallo la pendiente en grados, modificando la formula a x/y por prueba y error

                unkheading = (int)Math.Round(Math.Atan2(xdifunk, ydifunk) * 180 / Math.PI);
                frdheading = (int)Math.Round(Math.Atan2(xdiffrd, ydiffrd) * 180 / Math.PI);

                bearingangle = Corregiryredondear(bearingangle);
                unkheading = Corregiryredondear(unkheading);
                frdheading = Corregiryredondear(frdheading);

                //-------------------------------------------------------------
                alturasstr = "";
                for (int i = 1; i <= contactos; i++) { alturas[i - 1] = aleatorio.Next(1, 50); }
                Array.Sort(alturas);
                Array.Reverse(alturas);
                for (int i = 1; i <= contactos; i++) { alturasstr = alturasstr + tresdigitosstr(alturas[i - 1] * 10).ToString() + " "; }

                //--bloque de datos del amigo---------------------
                frddatablock = "H: " + tresdigitosstr(frdheading) + "\n" + "S :" + tresdigitosstr(velocidad) + "\n" + "A: " + tresdigitosstr(alturafrd * 10);

                if (xfrd + ancho + 50 > pictureBox1.Width) datablockxfrd = xfrd - ancho - 25;
                else datablockxfrd = xfrd + ancho;

                if (yfrd + alto + 50 > pictureBox1.Height) datablockyfrd = yfrd - alto - 30;
                else datablockyfrd = yfrd + alto;
                //------------------------------------------------

                if (closecontrol.Checked == true)
                {

                    int altura = aleatorio.Next(50);                    
                    int tec = aleatorio.Next(0, 2);
                    int idkill = aleatorio.Next(0, 2);
                    int intercall = aleatorio.Next(0, 4);
                    int internum = aleatorio.Next(0, 4);

                    if (intercall == 0) interceptor.Text = "VIPER";
                    else if (intercall == 1) interceptor.Text = "DARDO";
                    else if (intercall == 2) interceptor.Text = "ROCKET";
                    else  interceptor.Text = "CROMO";

                    if (internum == 0) interceptor.Text = interceptor.Text + "11";
                    else if (internum == 1) interceptor.Text = interceptor.Text + "12";
                    else if (internum == 2) interceptor.Text = interceptor.Text + "21";
                    else interceptor.Text = interceptor.Text + "22";


                    if (idkill == 0) identifique.Text = "ID";
                    else identifique.Text = "KILL";

                    if (tec == 0) tecnica.Text = "CUT OFF";
                    else tecnica.Text = "STERN";

                    string ATA = interceptlogic(bearingangle, unkheading, altura, frdheading);


                    // bloque de datos del blanco y su ubicación--------------------

                    unkdatablock = "H: " + tresdigitosstr(unkheading) + "\n" + "S :" + tresdigitosstr(velocidad) + "\n" + "A: " + tresdigitosstr(altura * 10);
                    
                    if (xunk + ancho + 40 > pictureBox1.Width) datablockxpos = xunk - 30;
                    else datablockxpos = xunk + ancho;

                    if (yunk + alto + 40 > pictureBox1.Height) datablockypos = yunk - 30;
                    else datablockypos = yunk + alto;
                    //--------------------------------------------------------------


                    if (ATA == "NOTFUNC") { next.PerformClick(); }
                    else{ graficar(0);}
                }
                else 
                {

                    // bloque de datos del blanco y su ubicación--------------------

                    unkdatablock = "H: " + tresdigitosstr(unkheading) + "\n" + "S :" + tresdigitosstr(velocidad) + "\n" + "A: " + alturasstr;

                    if (xunk + ancho + (contactos * 25) > pictureBox1.Width) datablockxpos = xunk - ancho - (contactos * 25);
                    else datablockxpos = xunk + ancho;

                    if (yunk + alto + 50 > pictureBox1.Height) datablockypos = yunk - alto - 30;
                    else datablockypos = yunk + alto;

                    //--------------------------------------------------------------------

                    tacticlogic(bearingangle, unkheading, (int) Math.Round(resultantebearing / rangediv), alturas, clasifstring, contactos);
                    graficar(0);                    
                }
            }
        }
        private string interceptlogic(int bearing, int heading, int altitud, int frdheading)
        {
            int counterbearing;
            int TA, ATA;
            string frase, lado, angelfrd;


            counterbearing = contrarumbo(bearing);

            TA = heading - counterbearing;


            if (Math.Abs(TA) > 80 || TA == 0 || TA == 10) { return "NOTFUNC"; }

            if (TA >= 180) TA = 360 - TA;

            if (TA <= -180) TA = TA + 360;

            ATA = bearing - TA;

            ATA = g360(ATA); 

            lado = ladostr(frdheading, ATA);

            int alturainter = altitud + 1;
            if (alturainter < 10) angelfrd = "0" + alturainter.ToString();
            else angelfrd = alturainter.ToString();

            trampa.Text = "CB:" + tresdigitosstr(counterbearing) + "\nTA:" + tresdigitosstr(Math.Abs(TA)) + "\nATH:" + tresdigitosstr(ATA);

            frase = interceptor.Text + " " + identifique.Text + " " + lado + " " + tresdigitosstr(ATA) + " " + "ANGELS" + " " + angelfrd + " " + tecnica.Text;

            resultadobox.Text = frase;

            return frase;

        }
        private void tacticlogic(int bearing, int heading, int distance, int[] altitud, string classif, int contacts)
        {
            int counterbearing;
            int TA;
            string aspect = "DEF";  
            string frase = "DEF";
            string rumbo = "DEF";
            string aspectrange = "DEF";
            string contactstring = "DEF";


            counterbearing = contrarumbo(bearing);
            TA = heading - counterbearing;

            if (TA >= 180) TA = 360 - TA;

            if (TA <= -180) TA = TA + 360;


            if (heading == 0 || heading == 360) rumbo = "NORTH";
            else if (heading > 0 && heading < 90) rumbo = "NORTH EAST";
            else if (heading == 90) rumbo = "EAST";
            else if (heading > 90 && heading < 180) rumbo = "SOUTH EAST";
            else if (heading == 180) rumbo = "SOUTH";
            else if (heading > 180 && heading < 270) rumbo = "SOUTH WEST";
            else if (heading == 270) rumbo = "WEST";
            else if (heading > 270 && heading < 360) rumbo = "NORTH WEST";


            if (Math.Abs(TA) >= 0 && Math.Abs(TA) <= 20) { aspect = "HOT"; aspectrange = "/0-20"; rumbo = ""; }
            else if (Math.Abs(TA) >= 30 && Math.Abs(TA) <= 60) { aspect = "FLANK"; aspectrange = "/30-60"; }
            else if (Math.Abs(TA) >= 70 && Math.Abs(TA) <= 110) { aspect = "BEAM"; aspectrange = "/70-110"; }
            else if (Math.Abs(TA) >= 120 && Math.Abs(TA) <= 180) { aspect = "DRAG"; aspectrange = "/120-180"; }


            
            trampa.Text = "CB:" + tresdigitosstr(counterbearing) + "\nTA:" + tresdigitosstr(Math.Abs(TA)) + aspectrange;

            string stackstr = altitud[0].ToString() + "K ";
            string altitudstacks = "";
            string pesado = "";
            string highlowstr = "";

            if (contacts > 1) 
            {

                int diferencia;
                int h = 0;
                int highclose = 0;
                int lowclose = 0;                
                contactstring = contacts.ToString() + " CONTACTS ";
 

                diferencia = altitud[0] - altitud[contacts-1];

                if (diferencia > 10) // VERIFICA SI HAY STACKS
                {
                    stackstr = "STACK " + altitud[0].ToString() + "K " + altitud[contacts - 1].ToString() + "K ";

                    for (int i = 0; i < contacts - 1; i++)
                    {
                        highclose = Math.Abs(altitud[0] - altitud[i]); // REVISA SI ESTAN MAS CERCANOS AL GRUPO ALTO O AL GRUPO BAJO
                        lowclose = Math.Abs(altitud[contacts - 1] - altitud[i]);

                        if (highclose < lowclose) { h++; }              
                    }
                    highlowstr =  h.ToString() + " HIGH " + (contacts - h).ToString() + " LOW ";
                }

            }
            else { contactstring = "";}

            if (contacts > 2) { pesado = "HEAVY "; }

            string etiqueta;


            if (distance < 25 && classif == "HOSTILE") { etiqueta = "THREAT"; }
            else {etiqueta = groupname.Text;}

            frase = interceptort.Text + " " + etiqueta + " " + braa.Text + " " + tresdigitosstr(bearing) + "/" + distance.ToString() + "/" + stackstr + altitudstacks + aspect + " " + rumbo + " " + classif + " " + pesado + contactstring + highlowstr;

            resultadobox.Text = frase;

        }
        private void borrar_Click(object sender, EventArgs e)
        {
            //Instruccion.Text = "";
            frequencyout.Text = "";
        }
        private void enviar_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            closewordspanel.Enabled = false;
            closewordspanel.Visible = false;
            tacticwordspanel.Enabled = false;
            tacticwordspanel.Visible = false;
            numberspanel.Enabled = false;
            numberspanel.Visible = false;
            Pista.Enabled = true;
            enviar.Enabled = false;
            enviar.Visible = false;
            borrar.Enabled = false;
            borrar.Visible = false;

            if (frequencyout.Text == resultadobox.Text)
            {
                overalltime = overalltime + time;
                tiempototal.Text = overalltime.ToString();
                good++;
                buenas.Text = good.ToString();


                //pictureBox1.ImageLocation = @"C:\Users\luvir\source\repos\PushtoTalk2\live.jpg";
                //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                graficar(1);


                mensaje.ForeColor = Color.Green;

                if (time < 15)
                {
                    SoundPlayer flawless = new SoundPlayer();
                    flawless.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Flawless_Victory.wav";
                    flawless.Play();

                    mensaje.Text = "FLAWLESS";
                }
                else if (time < 30)
                {
                    SoundPlayer excellent = new SoundPlayer();
                    excellent.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Excellent.wav";
                    excellent.Play();

                    mensaje.Text = "EXCELLENT";
                }

                else                 
                {
                    SoundPlayer welldone = new SoundPlayer();
                    welldone.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Well_Done.wav";
                    welldone.Play();

                    mensaje.Text = "WELL DONE";
                }

            }
            else
            {
                wrong++;
                malas.Text = wrong.ToString();
                frequencyout.ForeColor = Color.DarkRed;

                graficar(2);

                int audioloose = aleatorio.Next(0, 3);

                if (audioloose == 0)
                {
                    SoundPlayer awwbaby = new SoundPlayer();
                    awwbaby.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Aww_Baby.wav";
                    awwbaby.Play();

                    mensaje.ForeColor = Color.DarkRed;
                    mensaje.Text = "AWW BABY!";
                }
                else if (audioloose == 1)
                {
                    SoundPlayer deception = new SoundPlayer();
                    deception.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Deception_Laugh.wav";
                    deception.Play();

                    mensaje.ForeColor = Color.DarkRed;
                    mensaje.Text = "BUAJAJA!";
                }
                else
                {
                    SoundPlayer noob = new SoundPlayer();
                    noob.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Noob.wav";
                    noob.Play();

                    mensaje.ForeColor = Color.DarkRed;
                    mensaje.Text = "NOOB!";
                }

                Pista.Checked = true;

            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time < limittime)
            {
                time++;
                timelabel.Text = dosdigitosstr(time);
            }
            else
            {
                timer1.Stop();
                wrong++;
                malas.Text = wrong.ToString();

                closewordspanel.Enabled = false;
                numberspanel.Enabled = false;
                enviar.Enabled = false;
                borrar.Enabled = false;
                Pista.Enabled = true;

                //overalltime = overalltime + time;
                //tiempototal.Text = overalltime.ToString();

                graficar(2);

                SoundPlayer deceptionlaugh = new SoundPlayer();
                deceptionlaugh.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Deception_Laugh.wav";
                deceptionlaugh.Play();

                mensaje.ForeColor = Color.DarkRed;
                timelabel.ForeColor = Color.DarkRed;
                frequencyout.ForeColor = Color.DarkRed;
                mensaje.Text = "BUAJAJA!";

                Pista.Checked = true;

            }
            if (time == 0)
            {
                timelabel.ForeColor = Color.LimeGreen;
                frequencyout.ForeColor = Color.LimeGreen;
            }
            if (time == Math.Round(limittime * 0.25))
            {
                timelabel.ForeColor = Color.YellowGreen;
                frequencyout.ForeColor = Color.YellowGreen;
            }
            if (time == Math.Round(limittime * 0.5))
            {
                SoundPlayer finishhim = new SoundPlayer();
                finishhim.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Finish_Him.wav";
                finishhim.Play();
                timelabel.ForeColor = Color.Yellow;
                frequencyout.ForeColor = Color.Yellow;
            }
            if (time == Math.Round(limittime * 0.75))
            {
                timelabel.ForeColor = Color.Orange;
            }
            if (time == Math.Round(limittime * 0.85))
            {
                SoundPlayer hereitcomes = new SoundPlayer();
                hereitcomes.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Here_It_Comes.wav";
                hereitcomes.Play();
                timelabel.ForeColor = Color.OrangeRed;
                frequencyout.ForeColor = Color.OrangeRed;
            }
            if (time == Math.Round(limittime * 0.95))
            {
                SoundPlayer getoverhere = new SoundPlayer();
                getoverhere.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Get_Over_Here.wav";
                getoverhere.Play();
                timelabel.ForeColor = Color.Red;
                frequencyout.ForeColor = Color.Red;
            }



        }
        private void Pista_CheckedChanged(object sender, EventArgs e)
        {
            if (Pista.Checked == true) feedbackpanel.Visible = true;
            else feedbackpanel.Visible = false;
        }
        private void graficar(int background)
        {
            if (background == 0)
            {
                papel.Clear(Color.Black);

            }
            else if (background == 1)
            {
                papel.DrawImage(live, pictureBox1.Width - pictureBox1.Width / 4 - 10, 10, pictureBox1.Width / 4, pictureBox1.Height / 2);

            }
            else if (background == 2)
            {
                papel.DrawImage(die, pictureBox1.Width - pictureBox1.Width / 4 - 10,  10, pictureBox1.Width / 4, pictureBox1.Height / 2);

            }

            if (clasifstring == "BOGUEY")
            {
                papel.DrawImage(unk, xunk, yunk, ancho, alto);
                papel.DrawLine(unkhdline, xunk + (ancho / 2), yunk + (alto / 2), xunkhd, yunkhd);
                papel.DrawString(unkdatablock, font, colorunk, datablockxpos, datablockypos);
            }
            else if (clasifstring == "HOSTILE")
            {
                papel.DrawImage(hst, xunk, yunk, ancho, alto);
                papel.DrawLine(hstline, xunk + (ancho / 2), yunk + (alto / 2), xunkhd, yunkhd);
                papel.DrawString(unkdatablock, font, colorhostil, datablockxpos, datablockypos);

            }

            papel.DrawImage(frd, xfrd, yfrd, ancho, alto);
            papel.DrawLine(frdhdline, xfrd + (ancho / 2), yfrd + (alto / 2), xfrdhd, yfrdhd);
            //papel.DrawString(frdheading.ToString(), font, colorfrd, xfrd - xdiffrd/2, yfrd - ydiffrd/2);
            papel.DrawString(frddatablock, font, colorfrd, datablockxfrd, datablockyfrd);
            papel.DrawLine(bearingline, xfrd + (ancho / 2), yfrd + (alto / 2), xunk + (ancho / 2), yunk + (alto / 2));
            papel.DrawString(tresdigitosstr(bearingangle) + "/" + Math.Round(resultantebearing / rangediv).ToString(), font, new SolidBrush(Color.Green), xfrd - (xdif / 2), yfrd - (ydif / 2));// dividi la distancia por 8, para que den numeros mayores a 50 en rango                                                                                                                                                                                                      
        }

        // UTILITARIAS------------------------------------------
        private int Corregiryredondear(int rumbo)
        {
            int rumboc = rumbo;

            if (rumbo < 0) rumboc = rumbo * (-1); // igualmente por prueba y error establezco las operaciones para ver los grados de 0 a 360
            else if (rumbo == 0) rumboc = 360;
            else if (rumbo > 0) rumboc = 360 - rumbo;

            double rumboround = rumboc / 10;

            rumboround = Math.Round(rumboround);
            rumboc = (int)rumboround * 10;

            return rumboc;
        }
        private int contrarumbo(int rumbo)
        {
            int counterbearing;
            if (rumbo >= 180 && rumbo < 360) { counterbearing = rumbo - 180; }
            else { counterbearing = rumbo + 180; }
            return counterbearing;
        }
        private int g360(int rumbo)
        {
            int rumboc;

            if (rumbo == 0) { rumboc = 360; }

            else if (rumbo > 360)
            {
                rumboc = rumbo - 360;
            }
            else if (rumbo < 0)
            {
                rumboc = 360 + rumbo;
            }

            else { rumboc = rumbo; }

            return rumboc;
        }
        private string ladostr (int heading, int ATH)
        {
            int sumando, restando;

            // EN CONTRA DE LAS MANECILLAS DEL RELOJ
            if (heading >= 0 && heading <= 180 && ATH > 180 && ATH <= 360)
            {
                restando = Math.Abs(heading + (360 - ATH));
                sumando = Math.Abs((180 - heading) + (ATH - 180));

                if (sumando > restando) { return "LEFT"; }
                else { return "RIGHT"; }
            }
            else if (ATH >= 0 && ATH <= 180 && heading > 180 && heading <= 360)
            {
                restando = Math.Abs((360 - heading) + ATH);
                sumando = Math.Abs(heading - 180 + (180 - ATH));

                if (sumando > restando) { return "RIGHT"; }
                else { return "LEFT"; }
            }
            else 
            { 
                restando = heading - ATH;

                if (restando < 0) { return "RIGHT"; }
                else { return "LEFT"; }
            }

        }
        private string tresdigitosstr(int x)
        {
            if (x < 10) return "00" + x.ToString();
            else if (x < 100) return "0" + x.ToString();
            else return x.ToString();
        }
        private string dosdigitosstr(int x)
        {
            if (x < 10) return "0" + x.ToString();
            else return x.ToString();
        }
        private float Yunkcalc(int bearing, int xunk, int xfrd, int yfrd)
        {

            float theta;
            float thetarad = 0;
            float yunk = 0;


            if (bearing <= 360 && bearing >= 270)
            {
                theta = bearing - 270;
                thetarad = (float)(theta * Math.PI / 180);
                yunk = (float)(yfrd - (Math.Tan(thetarad) * (xfrd - xunk)));
            }

            else if (bearing < 90 && bearing >= 0)
            {
                theta = bearing;
                thetarad = (float)(theta * Math.PI / 180);
                yunk = (float)(yfrd - (Math.Tan(thetarad) * (xunk - xfrd)));
            }

            else if (bearing < 270 && bearing >= 180)
            {
                theta = bearing - 180;
                thetarad = (float)(theta * Math.PI / 180);
                yunk = (float)(yfrd + (Math.Tan(thetarad) * (xfrd - xunk)));
            }

            else if (bearing < 180 && bearing >= 90)
            {
                theta = bearing - 90;
                thetarad = (float)(theta * Math.PI / 180);

                yunk = (float)(yfrd + (Math.Tan(thetarad) * (xunk - xfrd)));
            }

            return yunk;

        }

        // RECONOCIMIENTO DE VOZ-------------------------------
        private void Voz_CheckedChanged(object sender, EventArgs e)
        {
            if (Voz.Checked == true) panel1.Enabled = true;
            else panel1.Enabled = false;

        }
        private void Deteccion(object sender, SpeechRecognizedEventArgs e)
        {
            progressBar1.Value = e.Result.Words.Count() * 10;
            //Instruccion.Text = e.Result.Text;
            frequencyout.Text = e.Result.Text;
        }
        private void bPTT_Click(object sender, EventArgs e)
        {

            oEscucha.SetInputToDefaultAudioDevice(); // selecciona la entrada de audio por defecto del sistema


            //------------------------------------------------------------------

            Choices commit = new Choices();
            Choices lado = new Choices();
            Choices d1 = new Choices();
            Choices d2 = new Choices();
            Choices d3 = new Choices();
            Choices altura = new Choices();
            Choices a1 = new Choices();
            Choices a2 = new Choices();
            Choices tecnica = new Choices();

            string[] digitos = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Guardo los digitos que se usaran en la pronunciacion del bearing

            commit.Add(new string[] { "id", "kill" });              // Establezco las instrucciones que tendran la misma secuencia "gramatical"
            lado.Add(new string[] { "left", "right" });
            d1.Add(digitos);
            d2.Add(digitos);
            d3.Add(digitos);
            altura.Add(new string[] { "angels" });
            a1.Add(digitos);
            a2.Add(digitos);
            tecnica.Add(new string[] { "cut off", "stern" });

            GrammarBuilder com_gb = new GrammarBuilder();

            com_gb.Append(commit);
            com_gb.Append(lado);
            com_gb.Append(d1);
            com_gb.Append(d2);
            com_gb.Append(d3);
            com_gb.Append(altura);
            com_gb.Append(a1);
            com_gb.Append(a2);
            com_gb.Append(tecnica);

            Grammar com_gramatica = new Grammar(com_gb);

            //-----------------------------------------------------------------
            oEscucha.LoadGrammar(com_gramatica); // carga el diccionario por defecto de reconocimiento de voz del pc (depende del lenguaje del windows)
            //oEscucha.LoadGrammar(new DictationGrammar()); // carga el diccionario por defecto de reconocimiento de voz del pc (depende del lenguaje del windows)
            oEscucha.SpeechRecognized += Deteccion; // se agrega el metodo deteccion al speechrecognized
            oEscucha.RecognizeAsync(RecognizeMode.Multiple); // deteccion de varias voces

        }
        private void bEND_Click(object sender, EventArgs e)
        {
            oEscucha.RecognizeAsyncStop();
        }

        // TECLAS----------------------------------------------
        private void uno_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "1";
        }
        private void dos_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "2";
        }
        private void tres_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "3";
        }
        private void cuatro_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "4";
        }
        private void cinco_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "5";
        }
        private void seis_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "6";
        }
        private void siete_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "7";
        }
        private void ocho_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "8";
        }
        private void nueve_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "9";
        }
        private void cero_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "0";
        }
        private void thousand_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + thousand.Text + " ";
        }
        private void slash_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + "/";
        }

        //TECLAS CONTROL CERRADO----------------------------------
        private void identifique_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + identifique.Text;
        }
        private void izquierda_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + izquierda.Text + " ";
        }
        private void derecha_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + derecha.Text + " ";
        }
        private void angeles_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + angeles.Text + " ";
        }
        private void tecnica_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + tecnica.Text;
        }
        private void interceptor_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + interceptor.Text;
        }

        //TECLAS CONTROL TÁCTICO-------------------------------------
        private void interceptort_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + interceptort.Text + " ";
        }
        private void braa_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + braa.Text + " ";
        }
        private void groupname_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + groupname.Text + " ";
        }
        private void flank_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + flank.Text + " ";
        }
        private void hot_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + hot.Text + " ";
        }
        private void beam_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + beam.Text + " ";
        }
        private void drag_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + drag.Text + " ";
        }
        private void classification_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + classification.Text + " ";
        }
        private void contacts_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + contacts.Text + " ";
        }
        private void north_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + north.Text + " ";
        }

        private void south_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + south.Text + " ";
        }

        private void west_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + west.Text + " ";
        }

        private void east_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + east.Text + " ";
        }

        private void stack_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + stack.Text + " ";
        }

        private void heavy_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + heavy.Text + " ";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {                  
            MessageBox.Show("by CROMO: luvirton.gonzalez@fac.mil.co","ARMAS Y TACTICAS - GCIBREAKER", MessageBoxButtons.OK, MessageBoxIcon.Question);          
        }


        //ESTOY AQUI------------------------

        private void resizeControl(Rectangle r, Control c)
        {
            float xratio = (float)this.Width / (float)originalFormSize.Width;
            float yratio = (float)this.Height / (float)originalFormSize.Height;

            int newX = (int)(r.Location.X * xratio);
            int newY = (int)(r.Location.Y * yratio);
            int newWidth = (int)(r.Width * xratio);
            int newHeight = (int)(r.Height * yratio);

            c.Location= new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

            if (c.Name == "mensaje" | c.Name == "timelabel")
            {
                c.Font = new Font("Sans Serif", tamanofuenteoriginal * xratio * 2, FontStyle.Bold);
            }
            else 
            {
                c.Font = new Font("Sans Serif", tamanofuenteoriginal * xratio, FontStyle.Bold);
            }

            



        }
        private void GciBreaker_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            tamanofuenteoriginal = ((int)borrar.Font.Size);


            outputspanelOriginalRectangle = new Rectangle(outputspanel.Location.X, outputspanel.Location.Y, outputspanel.Width, outputspanel.Height);
            inputspanelOriginalRectangle = new Rectangle(inputspanel.Location.X, inputspanel.Location.Y, inputspanel.Width, inputspanel.Height);
            pictureBox1OriginalRectangle = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            nextbuttonOriginalRectangle = new Rectangle(next.Location.X, next.Location.Y, next.Width, next.Height);
            pictureBox2OriginalRectangle = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            scorepanelOriginalRectangle = new Rectangle(scorepanel.Location.X, scorepanel.Location.Y, scorepanel.Width, scorepanel.Height);
            feedbackpanelOriginalRectangle = new Rectangle(feedbackpanel.Location.X, feedbackpanel.Location.Y, feedbackpanel.Width, feedbackpanel.Height);
            frequencyoutOriginalRectangle = new Rectangle(frequencyout.Location.X, frequencyout.Location.Y, frequencyout.Width, frequencyout.Height);
            controlboxOriginalRectangle = new Rectangle(controlbox.Location.X, controlbox.Location.Y, controlbox.Width, controlbox.Height);
            tacticwordsOriginalRectangle = new Rectangle(tacticwordspanel.Location.X, tacticwordspanel.Location.Y, tacticwordspanel.Width, tacticwordspanel.Height);
            numberspanelOriginalRectangle = new Rectangle(numberspanel.Location.X, numberspanel.Location.Y, numberspanel.Width, numberspanel.Height);
            enviarOriginalRectangle = new Rectangle(enviar.Location.X, enviar.Location.Y, enviar.Width, enviar.Height);
            borrarOriginalRectangle = new Rectangle(borrar.Location.X, borrar.Location.Y, borrar.Width, borrar.Height);
            timepanelOriginalRectangle = new Rectangle(timepanel.Location.X, timepanel.Location.Y, timepanel.Width, timepanel.Height);
            closewordspanelOriginalRectangle = new Rectangle(closewordspanel.Location.X, closewordspanel.Location.Y, closewordspanel.Width, closewordspanel.Height);
            interceptorOriginalRectangle = new Rectangle(interceptor.Location.X, interceptor.Location.Y, interceptor.Width, interceptor.Height);
            identifiqueOriginalRectangle = new Rectangle(identifique.Location.X, identifique.Location.Y, identifique.Width, identifique.Height);
            izquierdaOriginalRectangle = new Rectangle(izquierda.Location.X, izquierda.Location.Y, izquierda.Width, izquierda.Height);
            derechaOriginalRectangle = new Rectangle(derecha.Location.X, derecha.Location.Y, derecha.Width, derecha.Height);
            angelesOriginalRectangle = new Rectangle(angeles.Location.X, angeles.Location.Y, angeles.Width, angeles.Height);
            tecnicaOriginalRectangle = new Rectangle(tecnica.Location.X, tecnica.Location.Y, tecnica.Width, tecnica.Height);
            slashlOriginalRectangle = new Rectangle(slash.Location.X, slash.Location.Y, slash.Width, slash.Height);
            ceroOriginalRectangle = new Rectangle(cero.Location.X, cero.Location.Y, cero.Width, cero.Height);
            thousandOriginalRectangle = new Rectangle(thousand.Location.X, thousand.Location.Y, thousand.Width, thousand.Height);
            unoOriginalRectangle = new Rectangle(uno.Location.X, uno.Location.Y, uno.Width, uno.Height);
            dosOriginalRectangle = new Rectangle(dos.Location.X, dos.Location.Y, dos.Width, dos.Height);
            tresOriginalRectangle = new Rectangle(tres.Location.X, tres.Location.Y, tres.Width, tres.Height);
            cuatroOriginalRectangle = new Rectangle(cuatro.Location.X, cuatro.Location.Y, cuatro.Width, cuatro.Height);
            cincoOriginalRectangle = new Rectangle(cinco.Location.X, cinco.Location.Y, cinco.Width, cinco.Height);
            seisOriginalRectangle = new Rectangle(seis.Location.X, seis.Location.Y, seis.Width, seis.Height);
            sieteOriginalRectangle = new Rectangle(siete.Location.X, siete.Location.Y, siete.Width, siete.Height);
            ochoOriginalRectangle = new Rectangle(ocho.Location.X, ocho.Location.Y, ocho.Width, ocho.Height);
            nueveOriginalRectangle = new Rectangle(nueve.Location.X, nueve.Location.Y, nueve.Width, nueve.Height);
            tacticcontrolOriginalRectangle = new Rectangle(tacticcontrol.Location.X, tacticcontrol.Location.Y, tacticcontrol.Width, tacticcontrol.Height);
            closecontrolOriginalRectangle = new Rectangle(closecontrol.Location.X, closecontrol.Location.Y, closecontrol.Width, closecontrol.Height);
            interceptortOriginalRectangle = new Rectangle(interceptort.Location.X, interceptort.Location.Y, interceptort.Width, interceptort.Height);
            threatOriginalRectangle = new Rectangle(threat.Location.X, threat.Location.Y, threat.Width, threat.Height);
            groupnameOriginalRectangle = new Rectangle(groupname.Location.X, groupname.Location.Y, groupname.Width, groupname.Height);
            braaOriginalRectangle = new Rectangle(braa.Location.X, braa.Location.Y, braa.Width, braa.Height);
            hotOriginalRectangle = new Rectangle(hot.Location.X, hot.Location.Y, hot.Width, hot.Height);
            flankOriginalRectangle = new Rectangle(flank.Location.X, flank.Location.Y, flank.Width, flank.Height);
            beamOriginalRectangle = new Rectangle(beam.Location.X, beam.Location.Y, beam.Width, beam.Height);
            dragOriginalRectangle = new Rectangle(drag.Location.X, drag.Location.Y, drag.Width, drag.Height);
            northOriginalRectangle = new Rectangle(north.Location.X, north.Location.Y, north.Width, north.Height);
            southOriginalRectangle = new Rectangle(south.Location.X, south.Location.Y, south.Width, south.Height);
            westOriginalRectangle = new Rectangle(west.Location.X, west.Location.Y, west.Width, west.Height);
            eastOriginalRectangle = new Rectangle(east.Location.X, east.Location.Y, east.Width, east.Height);
            stackOriginalRectangle = new Rectangle(stack.Location.X, stack.Location.Y, stack.Width, stack.Height);
            classificationOriginalRectangle = new Rectangle(classification.Location.X, classification.Location.Y, classification.Width, classification.Height);
            heavyOriginalRectangle = new Rectangle(heavy.Location.X, heavy.Location.Y, heavy.Width, heavy.Height);
            contactsOriginalRectangle = new Rectangle(contacts.Location.X, contacts.Location.Y, contacts.Width, contacts.Height);
            highOriginalRectangle = new Rectangle(high.Location.X, high.Location.Y, high.Width, high.Height);
            lowOriginalRectangle = new Rectangle(low.Location.X, low.Location.Y, low.Width, low.Height);
            pistaOriginalRectangle = new Rectangle(Pista.Location.X, Pista.Location.Y, Pista.Width, Pista.Height);
            feedbackOriginalRectangle = new Rectangle(feedbackpanel.Location.X, feedbackpanel.Location.Y, feedbackpanel.Width, feedbackpanel.Height);
            label1OriginalRectangle = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2OriginalRectangle = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3OriginalRectangle = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label4OriginalRectangle = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            buenasOriginalRectangle = new Rectangle(buenas.Location.X, buenas.Location.Y, buenas.Width, buenas.Height);
            malasOriginalRectangle = new Rectangle(malas.Location.X, malas.Location.Y, malas.Width, malas.Height);
            tiempototalOriginalRectangle = new Rectangle(tiempototal.Location.X, tiempototal.Location.Y, tiempototal.Width, tiempototal.Height);
            timelabelOriginalRectangle = new Rectangle(timelabel.Location.X, timelabel.Location.Y, timelabel.Width, timelabel.Height);
            trampaOriginalRectangle = new Rectangle(trampa.Location.X, trampa.Location.Y, trampa.Width, trampa.Height);
            resultadoboxOriginalRectangle = new Rectangle(resultadobox.Location.X, resultadobox.Location.Y, resultadobox.Width, resultadobox.Height);
            mensajeOriginalRectangle = new Rectangle(mensaje.Location.X, mensaje.Location.Y, mensaje.Width, mensaje.Height);


        }

        private void GciBreaker_Resize(object sender, EventArgs e)
        {
            
            if (originalFormSize.Width != 0) // Es solo para la primera entrada del programa
            { 
                
                resizeControl(outputspanelOriginalRectangle, outputspanel);
                resizeControl(inputspanelOriginalRectangle, inputspanel);
                resizeControl(pictureBox1OriginalRectangle, pictureBox1);
                resizeControl(nextbuttonOriginalRectangle, next);
                resizeControl(pictureBox2OriginalRectangle, pictureBox2);
                resizeControl(scorepanelOriginalRectangle, scorepanel);
                resizeControl(feedbackpanelOriginalRectangle, feedbackpanel);
                resizeControl(frequencyoutOriginalRectangle, frequencyout);
                resizeControl(controlboxOriginalRectangle, controlbox);
                resizeControl(tacticwordsOriginalRectangle, tacticwordspanel);
                resizeControl(numberspanelOriginalRectangle, numberspanel);
                resizeControl(enviarOriginalRectangle, enviar);
                resizeControl(borrarOriginalRectangle, borrar);
                resizeControl(timepanelOriginalRectangle, timepanel);
                resizeControl(closewordspanelOriginalRectangle, closewordspanel);
                resizeControl(interceptorOriginalRectangle, interceptor);
                resizeControl(identifiqueOriginalRectangle, identifique);
                resizeControl(izquierdaOriginalRectangle, izquierda);
                resizeControl(derechaOriginalRectangle, derecha);
                resizeControl(angelesOriginalRectangle, angeles);
                resizeControl(tecnicaOriginalRectangle, tecnica);
                resizeControl(slashlOriginalRectangle, slash);
                resizeControl(ceroOriginalRectangle, cero);
                resizeControl(thousandOriginalRectangle, thousand);
                resizeControl(unoOriginalRectangle, uno);
                resizeControl(dosOriginalRectangle, dos);
                resizeControl(tresOriginalRectangle, tres);
                resizeControl(cuatroOriginalRectangle, cuatro);
                resizeControl(cincoOriginalRectangle, cinco);
                resizeControl(seisOriginalRectangle, seis);
                resizeControl(sieteOriginalRectangle, siete);
                resizeControl(ochoOriginalRectangle, ocho);
                resizeControl(nueveOriginalRectangle, nueve);
                resizeControl(tacticcontrolOriginalRectangle, tacticcontrol);
                resizeControl(closecontrolOriginalRectangle, closecontrol);
                resizeControl(interceptortOriginalRectangle, interceptort);
                resizeControl(threatOriginalRectangle, threat);
                resizeControl(groupnameOriginalRectangle, groupname);
                resizeControl(braaOriginalRectangle, braa);
                resizeControl(hotOriginalRectangle, hot);
                resizeControl(flankOriginalRectangle, flank);
                resizeControl(beamOriginalRectangle, beam);
                resizeControl(dragOriginalRectangle, drag);
                resizeControl(northOriginalRectangle, north);
                resizeControl(southOriginalRectangle, south);
                resizeControl(westOriginalRectangle, west);
                resizeControl(eastOriginalRectangle, east);
                resizeControl(stackOriginalRectangle, stack);
                resizeControl(classificationOriginalRectangle, classification);
                resizeControl(heavyOriginalRectangle, heavy);
                resizeControl(contactsOriginalRectangle, contacts);
                resizeControl(highOriginalRectangle, high);
                resizeControl(lowOriginalRectangle, low);
                resizeControl(pistaOriginalRectangle, Pista);
                resizeControl(feedbackOriginalRectangle, feedbackpanel);
                resizeControl(label1OriginalRectangle, label1);
                resizeControl(label2OriginalRectangle, label2);
                resizeControl(label3OriginalRectangle, label3);
                resizeControl(label4OriginalRectangle, label4);
                resizeControl(buenasOriginalRectangle, buenas);
                resizeControl(malasOriginalRectangle, malas);
                resizeControl(tiempototalOriginalRectangle, tiempototal);
                resizeControl(timelabelOriginalRectangle, timelabel);
                resizeControl(trampaOriginalRectangle, trampa);
                resizeControl(resultadoboxOriginalRectangle, resultadobox);
                resizeControl(mensajeOriginalRectangle, mensaje);

            }

        }

        //---------------------------------------------------------------

        private void high_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + high.Text + " ";
        }

        private void low_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + " " + low.Text + " ";
        }

        private void threat_Click(object sender, EventArgs e)
        {
            frequencyout.Text = frequencyout.Text + threat.Text + " ";
        }
    }
}
