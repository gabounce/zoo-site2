using System;
using MySql.Data.MySqlClient;

namespace TutoMySQL
{
    public class Bdd
    {
        private MySqlConnection connection;

        public Bdd()
        {
            this.InitConnexion();
        }

        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "SERVER=192.168.1.24; DATABASE=elevage; UID=gabriel; PASSWORD=test";
            this.connection = new MySqlConnection(connectionString);
        }

        public void AddAnimal(Animal animal)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO animal (espece, sexe, nom) VALUES (@espece, @sexe, @nom)";

                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@espece", animal.Espece);
                cmd.Parameters.AddWithValue("@sexe", animal.Sexe);
                cmd.Parameters.AddWithValue("@nom", animal.Nom);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
