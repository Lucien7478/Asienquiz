using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Asienquiz
{
    public class Form2 : Form
    {
        //hinzufügen der Klassenvariablen - sortiert nach Grafisch relevanten Klassenvariablen und Variablen zur Datenverwaltung innerhalb des Programmes
        //Datenverwaltung
        private readonly DB datenbank = new DB();
        private readonly IContainer components = (IContainer) null;
        private int fragenummer = 0;
        private readonly int frageart;
        private int punkte = 0;
        private readonly List<Land> laenderListe;

        //grafische Steuerelemente
        private PictureBox frageBild;
        private Label frageStellung;

        //Aufgrund des zeitlichen Engpasses in Bezug zu meinem Urlaub habe ich es leider nicht geschafft dies korrekt einzubinden
        private PictureBox flaggeFrage;
        private Label stadtFrage;
        private Label landFrage;

        private PictureBox flaggeLoesung;
        private Label stadtLoesung;
        private Label landLoesung;

        private Antwort moeglichkeitEins;
        private Antwort moeglichkeitZwei;
        private Antwort moeglichkeitDrei;
        private Antwort moeglichkeitVier;

        private Button weiter;

        public Form2(int auswahl)
        {
            initializeComponent();
            frageart = auswahl;
            laenderListe = this.datenbank.getLand();
        }

        //gibt den gewählten Spielmodus zurück
        public int getFrageArt()
        {
            return frageart;
        }

        //gibt die Fragenummer zurück
        public int getFrageNummer()
        {
            return fragenummer;
        }

        public List<Land> getLaenderListe()
        {
            return laenderListe;
        }

        //überschreibt die in Form deklarierte Dispose-Funktion und führt stattdessen diese aus
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void initializeComponent()
        {
            //unterbrechen des Layoutings
            SuspendLayout();

            //Fragestellung erstellen, anpassen und hinzufügen
            frageStellung = new Label();
            frageStellung.Font =  new Font("Microsoft YaHei", 18f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            frageStellung.Location = new Point(40, 55);
            frageStellung.Size = new Size(100, 30);
            add(frageStellung);

            //Flagge für die Fragestellung erstellen, anpassen, Initialisierung beginnen und hinzufügen
            flaggeFrage = new PictureBox();
            ((ISupportInitialize)flaggeFrage).BeginInit();
            add(flaggeFrage);

            //Hauptstadt für die Fragestellung erstellen, anpassen und hinzufügen
            stadtFrage = new Label();
            add(stadtFrage);

            //Land für die Fragestellung erstellen, anpassen und hinzufügen
            landFrage = new Label();
            add(landFrage);

            //Flagge für die Lösung erstellen, anpassen, Initialisierung beginnen und hinzufügen
            flaggeLoesung = new PictureBox();
            ((ISupportInitialize)flaggeLoesung).BeginInit();
            add(flaggeLoesung);

            //Hauptstadt für die Lösung erstellen, anpassen und hinzufügen
            stadtLoesung = new Label();
            add(stadtLoesung);

            //Land für die Lösung erstellen, anpassen und hinzufügen
            landLoesung = new Label();
            add(landLoesung);

            //Button zum weiterspielen
            weiter = new Button();
            weiter.Size = new Size(75, 25);
            weiter.Text = "Weiter";
            weiter.UseVisualStyleBackColor = true;
            weiter.Click += new EventHandler(this.weiterClickEvent);
            add(weiter);

            //Initialisierungen abschließen
            ((ISupportInitialize)flaggeFrage).EndInit();
            ((ISupportInitialize)flaggeLoesung).EndInit();

            //Dimensionen für das Steuerelement festlegen, den Skalierungsmodus festlegen, die Clientgröße bestimmen und den Text in der Taskleiste festlegen
            AutoScaleDimensions = new Size(100, 50);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Asien-Quiz";

            //Unterbrockenes Layout fortsetzen
            ResumeLayout(false);
            PerformLayout();
        }

        //Einkürzung bzw. Vereinheitlichung zum hinzufügen eines Kontrollelementes zum Steuerelement
        private void add(Control control)
        {
            Controls.Add(control);
        }

        //Überladung der Methode zur Vereinfachung und Übersichtlichkeit des Codes
        private void add(Antwort antwort)
        {
            Controls.Add((Control) antwort.getFlagge());
            Controls.Add((Control) antwort.getAntwortMoeglichkeit());
            Controls.Add((Control) antwort.getBezeichnung());
            Controls.Add((Control) antwort.getAuswahlButton());
        }


        //GUI an den gewählten Spielmodus anpassen
        private void enabledBoxes()
        {
            //Alle 
            flaggeLoesung.Visible = false;
            stadtLoesung.Visible = false;
            landLoesung.Visible = false;

            switch(frageart)
            {

                case 0:
                    {
                        //Hauptstadt zu Land
                        landLoesung.Visible = true;
                        frageStellung.Text = "Welche Hauptstadt gehört zu diesem Land?";
                        break;
                    }
                case 1:
                    {
                        //Land zu Hauptstadt
                        stadtLoesung.Visible = true;
                        frageStellung.Text = "Welches Land gehört zu dieser Hauptstadt?";
                        break;
                    }
                case 2:
                    {
                        //Flagge zu Land
                        landLoesung.Visible = true;
                        frageStellung.Text = "Welche Flagge gehört zu dem Land?";
                        break;
                    }
                case 3:
                    {
                        //Land zu Flagge
                        flaggeLoesung.Visible = true;
                        frageStellung.Text = "Welches Land gehört zu dieser Flagge?";
                        break;
                    }
                case 4:
                    {
                        //Hauptstadt zu Flagge
                        flaggeLoesung.Visible = true;
                        frageStellung.Text = "Welche Hauptstadt gehört zu dieser Flagge?";
                        break;
                    }
                case 5:
                    {
                        //Flagge zu Hauptstadt
                        stadtLoesung.Visible = true;
                        frageStellung.Text = "Welche Flagge gehört zu dieser Hauptstadt?";
                        break;
                    }
            }

            //aktualisiert die FrageStellung falls notwendig
            moeglichkeitEins.changeAuswahl(frageart);
            moeglichkeitZwei.changeAuswahl(frageart);
            moeglichkeitDrei.changeAuswahl(frageart);
            moeglichkeitVier.changeAuswahl(frageart);
        }

        private void showQuiz()
        {
            //Laden der Lösung - aufgrund welcher die nachfolgenden Klassenvariablen mit dem Inhalt dieser Lösung befüllt werden
            Land land = laenderListe[this.fragenummer + new Random().Next(0, 4)];
            flaggeLoesung.Image = Image.FromFile("Flaggen\\" + land.getLand() + ".png");
            stadtLoesung.Text = land.getHauptstadt();
            landLoesung.Text = land.getLand();

            //Hinzufügen der Antwortmöglichkeiten - diese enthalten Flagge, Hauptstadt, Land und die korrekte Bezeichnung der Antwortmöglichkeit
            moeglichkeitEins = new Antwort(this, 0, new EventHandler(this.antwortButtonCheckedChange));
            add(moeglichkeitEins);
            moeglichkeitZwei = new Antwort(this, 1, new EventHandler(this.antwortButtonCheckedChange));
            add(moeglichkeitZwei);
            moeglichkeitDrei = new Antwort(this, 2, new EventHandler(this.antwortButtonCheckedChange));
            add(moeglichkeitDrei);
            moeglichkeitVier = new Antwort(this, 3, new EventHandler(this.antwortButtonCheckedChange));
            add(moeglichkeitVier);
        }
        //ClickEvent, welches prüft, ob die Antwort richtig ist - wenn ja wird eine entsprechende MessageBox aufgezeigt
        private void antwortButtonCheckedChange(object sender, EventArgs e)
        {
            RadioButton tmpButton = (RadioButton)sender;
            if (!tmpButton.Checked || !(tmpButton.Text == this.landLoesung.Text))
                return;
            MessageBox.Show("Richtig");
            punkte++;
        }
        //ClickEvent für den Button, welcher die nächste Frage laden soll oder das Spiel beenden soll
        private void weiterClickEvent(Object sender, EventArgs e)
        {
            //Wenn noch keine 10 Durchgänge gespielt wurden, wird eine neue Frage geladen
            if (++fragenummer < 10)
                showQuiz();
            //Wenn bereits 10 Durchgänge gespielt wurden, wird das Spiel beendet
            else
            {
                MessageBox.Show("Spiel beendet");
                new Form3().ShowDialog();
            }
                
        }

    }
}
