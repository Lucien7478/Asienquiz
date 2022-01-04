using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Asienquiz
{
    public class Antwort
    {
        // hinzufügen der Klassenvariablen - sortiert nach Grafisch relevanten Klassenvariablen und Variablen zur Datenverwaltung innerhalb des Programmes
        //Datenverwaltung
        private int auswahl;

        //grafische Steuerelemente
        private PictureBox flagge;
        private Label antwortMoeglichkeit;
        private Label bezeichnung;
        private RadioButton auswahlButton;

        public Antwort(Form2 form2, int auswahl, EventHandler e)
        {
            this.auswahl = auswahl;
            initializeComponent(form2.getLaenderListe()[form2.getFrageNummer() + auswahl], e);
            setPosition(form2.getFrageArt());
            enableBoxes();
        }

        //gibt die aktuelle Flagge zurück
        public PictureBox getFlagge()
        {
            return flagge;
        }

        //gibt die Antwort zurück
        public Label getAntwortMoeglichkeit()
        {
            return antwortMoeglichkeit;
        }

        //gibt die Bezeichnung zurück
        public Label getBezeichnung()
        {
            return bezeichnung;
        }

        //gibt den RadioButton zurück
        public RadioButton getAuswahlButton()
        {
            return auswahlButton;
        }

        //prüft ob der RadioButton ausgewählt ist
        public Boolean isChecked()
        {
            return auswahlButton.Checked;
        }

        //ruft die Methode zur visuellen Aktualisierung auf
        public void changeAuswahl(int auswahl)
        {
            if(this.auswahl != auswahl)
                enableBoxes();
        }

        //initialisiert die Komponenten und lädt diese
        private void initializeComponent(Land land, EventHandler e)
        {
            //Flagge erstellen, anpassen, Initialisierung beginnen und hinzufügen
            flagge = new PictureBox();
            flagge.Image = Image.FromFile("Flaggen\\" + land.getLand() + ".png");
            flagge.Size = new Size(80, 47);
            flagge.SizeMode = PictureBoxSizeMode.Zoom;
            ((ISupportInitialize)flagge).BeginInit();

            //Hauptstadt erstellen, anpassen und hinzufügen
            antwortMoeglichkeit = new Label();
            antwortMoeglichkeit.Text = land.getHauptstadt();

            //Nummer der Antwortmöglichkeit erstellen, anpassen und hinzufügen
            bezeichnung = new Label();
            bezeichnung.Text = "Antwort ";
            bezeichnung.Size = new Size(52, 13);

            //Den Button zum auswählen der Antwort erstellen, anpassen und hinzufügen
            auswahlButton = new RadioButton();
            auswahlButton.Text = land.getLand();
            auswahlButton.Size = new Size(14, 13);
            auswahlButton.UseVisualStyleBackColor = true;
            auswahlButton.CheckedChanged += e;

            //Initialisierung der Flagge abschließen
            ((ISupportInitialize)flagge).EndInit();
        }

        //setzt die Position für die möglichen Antworten in Verbindung zu der Nummer
        private void setPosition(int nummer)
        {
            switch(nummer)
            {
                case 0:
                    {
                        //Antwortmöglichkeit 1
                        flagge.Location = new Point(120, 260);
                        bezeichnung.Text += "1";
                        bezeichnung.Location = new Point(40, 230);
                        auswahlButton.Location = new Point(120, 230);
                        break;
                    }
                case 1:
                    {
                        //Antwortmöglichkeit 2
                        flagge.Location = new Point(120, 380);
                        bezeichnung.Text += "2";
                        bezeichnung.Location = new Point(40, 350);
                        auswahlButton.Location = new Point(120, 350);
                        break;
                    }
                case 2:
                    {
                        //Antwortmöglichkeit 3
                        flagge.Location = new Point(470, 260);
                        bezeichnung.Text += "3";
                        bezeichnung.Location = new Point(380, 230);
                        auswahlButton.Location = new Point(470, 230);
                        break;
                    }
                case 3:
                    {
                        //Antwortmöglichkeit 4
                        flagge.Location = new Point(470, 380);
                        bezeichnung.Text += "4";
                        bezeichnung.Location = new Point(380, 350);
                        auswahlButton.Location = new Point(470, 350);
                        break;
                    }
            }
        }

        //setzt die für den ausgewählten Spielmodus benötigten Komponenten sichtbar
        private void enableBoxes()
        {
            switch(auswahl)
            {
                case 0:
                    {
                        //Hauptstadt zu Land
                        flagge.Visible = false;
                        antwortMoeglichkeit.Visible = true;
                        break;
                    }
                case 1:
                    {
                        //Land zu Hauptstadt
                        flagge.Visible = false;
                        antwortMoeglichkeit.Visible = false;
                        break;
                    }
                case 2:
                    {
                        //Flagge zu Land
                        flagge.Visible = true;
                        antwortMoeglichkeit.Visible = false;
                        break;
                    }
                case 3:
                    {
                        //Land zu Flagge
                        flagge.Visible = false;
                        antwortMoeglichkeit.Visible = false;
                        break;
                    }
                case 4:
                    {
                        //Hauptstadt zu Flagge
                        flagge.Visible = true;
                        antwortMoeglichkeit.Visible = false;
                        break;
                    }
                case 5:
                    {
                        //Flagge zu Hauptstadt
                        flagge.Visible = false;
                        antwortMoeglichkeit.Visible = true;
                        break;
                    }
            }
        }
    }
}
