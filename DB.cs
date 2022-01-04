using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Asienquiz
{
  public class DB
  {
    private MySqlConnection conn = new MySqlConnection("SERVER=localhost;UID=root;Password=root;");

    public void saveSpieler(Spieler s)
    {
      MySqlCommand command = this.conn.CreateCommand();
      command.CommandText = "INSERT INTO asienquiz.spieler VALUES( \"" + s.getName().ToString() + "\", " + s.getHighscore().ToString() + ", NULL );";
            this.conn.Open();
      command.ExecuteNonQuery();
      this.conn.Close();
    }

    public List<Spieler> getSpieler()
    {
      List<Spieler> spielerList = new List<Spieler>();
      MySqlCommand command = this.conn.CreateCommand();
      command.CommandText = "SELECT * FROM asienquiz.spieler;";
      this.conn.Open();
      MySqlDataReader mySqlDataReader = command.ExecuteReader();
      while (mySqlDataReader.Read())
        spielerList.Add(new Spieler(mySqlDataReader.GetInt32(0), mySqlDataReader.GetInt32(1), mySqlDataReader.GetString(2)));
      mySqlDataReader.Close();
      this.conn.Close();
      return spielerList;
    }

    public List<Land> getLand()
    {
      List<Land> landList = new List<Land>();
      MySqlCommand command = this.conn.CreateCommand();
      command.CommandText = "SELECT * FROM asienquiz.land ORDER BY RAND();";
      this.conn.Open();
      MySqlDataReader mySqlDataReader = command.ExecuteReader();
      while (mySqlDataReader.Read())
        landList.Add(new Land(mySqlDataReader.GetInt32(0), mySqlDataReader.GetString(1), mySqlDataReader.GetString(2)));
      mySqlDataReader.Close();
      this.conn.Close();
      return landList;
    }

    public void sichereScore(Spieler s)
    {
      MySqlCommand command = this.conn.CreateCommand();
      command.CommandText = "UPDATE asienquiz.spieler SET score = " + s.getHighscore().ToString() + " WHERE id " + (object) s.getSpielerID() + ";";
      this.conn.Open();
      command.ExecuteNonQuery();
      this.conn.Close();
    }
  }
}
