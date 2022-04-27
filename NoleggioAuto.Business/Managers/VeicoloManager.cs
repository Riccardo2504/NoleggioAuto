using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoleggioAuto.Business.Models;

namespace NoleggioAuto.Business.Managers
{
    public class VeicoloManager
    {
        public string ConnectionString { get; set; }
        public VeicoloManager(string connectionString) => this.ConnectionString = connectionString;

        public List<VeicoloModel> GetVeicoloList()
        {
            var veicoloList = new List<VeicoloModel>();
            try
            {
                string query = "SELECT Id, IdMarca, Modello, IdAlimentazione, DataImmatricolazione, Targa, Note FROM VeicoliRR;";
                using (var command = new SqlCommand(query))
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        var DataSet = new DataSet();
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.SelectCommand = command;
                            adapter.SelectCommand.Connection = connection;
                            adapter.Fill(DataSet);

                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                VeicoloModel veicolo = new VeicoloModel();
                                veicolo.Id = reader.GetInt32(0);
                                veicolo.IdMarca = reader.GetInt32(1);
                                veicolo.Modello = reader[2].ToString();
                                veicolo.IdAlimentazione = reader.GetInt32(3);
                                string data = reader[4].ToString();
                                if (data != "")
                                    veicolo.DataImmatricolazione = DateTime.Parse(data);
                                else
                                    veicolo.DataImmatricolazione = null;
                                veicolo.Targa = reader[5].ToString();
                                veicolo.Note = reader[6].ToString();
                                veicoloList.Add(veicolo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return veicoloList;
        }

        public bool InsertVeicolo(VeicoloModel veicoloModel)
        {
            bool inserito = false;
            try
            {
                string query = @"INSERT INTO VeicoliRR (IdMarca, Modello, IdAlimentazione, DataImmatricolazione, Targa, Note) VALUES (@IdMarca,@Modello,@IdAlimentazione,@DataImmatricolazione,@Targa,@Note)";
                var connection = new SqlConnection(ConnectionString);
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    command.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    command.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdAlimentazione);
                    command.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    command.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    command.Parameters.AddWithValue("@Note", veicoloModel.Note);

                    int value = command.ExecuteNonQuery();
                    if (value >= 1)
                        inserito = true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return inserito;
        }

        public List<VeicoloModel> RicercaVeicolo1(RicercaVeicolo ricercaVeicolo)
        {
            var veicoloList = new List<VeicoloModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t [Id]");
            sb.AppendLine("\t,[IdMarca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[IdAlimentazione]");
            sb.AppendLine("\t,[DataImmatricolazione]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Note]");
            sb.AppendLine("\t,[DataInserimento]");
            sb.AppendLine("\t,[DataModifica]");
            sb.AppendLine("FROM [dbo].[VeicoliRR]");
            sb.AppendLine("WHERE 1=1");
            try
            {
                if (ricercaVeicolo.IdMarca != 0)
                {
                    sb.AppendLine("AND IdMarca=@IdMarca");
                }
                if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
                {
                    sb.AppendLine("AND Modello=@Modello");
                }
                if (ricercaVeicolo.IdAlimentazione != 0)
                {
                    sb.AppendLine("AND IdAlimentazione=@IdAlimentazione");
                }
                if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
                {
                    sb.AppendLine("AND Targa=@Targa");
                }
                if (!string.IsNullOrEmpty(ricercaVeicolo.Note))
                {
                    sb.AppendLine("AND Note=@Note");
                }

                using (var cmd = new SqlCommand(sb.ToString()))
                {
                    if (ricercaVeicolo.IdMarca != 0)
                    {
                        cmd.Parameters.AddWithValue("@IdMarca", ricercaVeicolo.IdMarca);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
                    {
                        cmd.Parameters.AddWithValue("@Modello", ricercaVeicolo.Modello);
                    }
                    if (ricercaVeicolo.IdAlimentazione != 0)
                    {
                        cmd.Parameters.AddWithValue("@IdAlimentazione", ricercaVeicolo.IdAlimentazione);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
                    {
                        cmd.Parameters.AddWithValue("@Targa", ricercaVeicolo.Targa);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicolo.Note))
                    {
                        cmd.Parameters.AddWithValue("@Note", ricercaVeicolo.Note);
                    }
                    var dt = new DataTable();
                    using (var conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        using (var adp = new SqlDataAdapter(cmd))
                        {
                            adp.SelectCommand = cmd;
                            adp.SelectCommand.Connection = conn;
                            adp.Fill(dt);

                            if (dt == null || dt.Rows.Count <= 0) return null;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                var row = dt.Rows[i];
                                VeicoloModel veicolo = new VeicoloModel()
                                {
                                    Id = row.Field<int>("Id"),
                                    IdMarca = row.Field<int>("IdMarca"),
                                    Modello = row.Field<string>("Modello"),
                                    IdAlimentazione = row.Field<int>("IdAlimentazione"),
                                    DataImmatricolazione = row.Field<DateTime?>("DataImmatricolazione"),
                                    Targa = row.Field<string>("Targa"),
                                    Note = row.Field<string>("Note"),
                                    DataInserimento = row.Field<DateTime?>("DataInserimento"),
                                    DataModifica = row.Field<DateTime?>("DataModifica")
                                };
                                veicoloList.Add(veicolo);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return veicoloList;
        }

        public VeicoloModel CercaVeicoloById(int Id)
        {

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t [Id]");
            sb.AppendLine("\t,[IdMarca]");
            sb.AppendLine("\t,[Modello]");
            sb.AppendLine("\t,[IdAlimentazione]");
            sb.AppendLine("\t,[DataImmatricolazione]");
            sb.AppendLine("\t,[Targa]");
            sb.AppendLine("\t,[Note]");
            sb.AppendLine("\t,[DataInserimento]");
            sb.AppendLine("\t,[DataModifica]");
            sb.AppendLine("FROM [dbo].[VeicoliRR]");
            sb.AppendLine("WHERE 1=1");

            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                sb.AppendLine("AND Id=@Id");
            }

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                if (!string.IsNullOrEmpty(Id.ToString()))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                }

                var dt = new DataTable();
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var adp = new SqlDataAdapter(cmd))
                    {
                        adp.SelectCommand = cmd;
                        adp.SelectCommand.Connection = conn;
                        adp.Fill(dt);
                    }
                    if (dt == null || dt.Rows.Count <= 0) return null;
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    var row = dt.Rows[0];
                    VeicoloModel veicolo = new VeicoloModel()
                    {
                        Id = row.Field<int>("Id"),
                        IdMarca = row.Field<int>("IdMarca"),
                        Modello = row.Field<string>("Modello"),
                        IdAlimentazione = row.Field<int>("IdAlimentazione"),
                        DataImmatricolazione = row.Field<DateTime?>("DataImmatricolazione"),
                        Targa = row.Field<string>("Targa"),
                        Note = row.Field<string>("Note"),
                        DataInserimento = row.Field<DateTime?>("DataInserimento"),
                        DataModifica = row.Field<DateTime?>("DataModifica")
                    };

                    return veicolo;
                }
            }
        }

        public bool EliminaVeicolo(int ID)
        {
            bool eliminata = false;
            try
            {
                string query = @"DELETE FROM [dbo].[VeicoliRR] WHERE Id=@ID";
                var connection = new SqlConnection(ConnectionString);
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    int value = command.ExecuteNonQuery();
                    if (value >= 1)
                        eliminata = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return eliminata;
        }

        public bool UpdateVeicolo(VeicoloModel veicoloModel)
        {
            bool modifica = false;
            try
            {
                string query = @"UPDATE [dbo].[VeicoliRR] SET [IdMarca] = @IdMarca,[Modello] = @Modello,[IdAlimentazione] = @IdAlimentazione,[DataImmatricolazione] = @DataImmatricolazione,[Targa] = @Targa,[Note] = @Note,[DataModifica] = @DataModifica WHERE id = @id";
                var connection = new SqlConnection(ConnectionString);
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", veicoloModel.Id);
                    command.Parameters.AddWithValue("@Nome", veicoloModel.IdMarca);
                    command.Parameters.AddWithValue("@Cognome", veicoloModel.IdAlimentazione);
                    if (string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        command.Parameters.AddWithValue(@"Modello", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.DataImmatricolazione.ToString()))
                    {
                        command.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        command.Parameters.AddWithValue(@"Targa", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }
                    if (string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        command.Parameters.AddWithValue(@"Note", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }
                    command.Parameters.AddWithValue("@DataModifica", DateTime.Now);
                    int value = command.ExecuteNonQuery();
                    if (value >= 1)
                        modifica = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return modifica;
        }

        public List<MarcaModel> PopolaMarche()
        {
            List<MarcaModel> veicolo1 = new List<MarcaModel>();
            try
            {
                string Popola = "SELECT [descrizione],[Id] FROM[dbo].[MarcaRR]";
                using (var command = new SqlCommand(Popola))
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        command.Connection = connection;

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            MarcaModel veicolo = new MarcaModel();
                            veicolo.Descrizione = reader[0].ToString();
                            veicolo.Id = reader.GetInt32(1);
                            veicolo1.Add(veicolo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return veicolo1;
        }

        public List<AlimentazioneModel> PopolaAlimentazione()
        {
            List<AlimentazioneModel> veicolo1 = new List<AlimentazioneModel>();
            try
            {
                string Popola = "SELECT [descrizione],[Id] FROM[dbo].[AlimentazioneRR]";
                using (var command = new SqlCommand(Popola))
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        command.Connection = connection;

                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            AlimentazioneModel veicolo = new AlimentazioneModel();
                            veicolo.Descrizione = reader[0].ToString();
                            veicolo.Id = reader.GetInt32(1);
                            veicolo1.Add(veicolo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return veicolo1;
        }

        public class RicercaVeicolo
        {
            public int Id { get; set; }
            public int IdMarca { get; set; }
            public string Modello { get; set; }
            public int IdAlimentazione { get; set; }
            public DateTime? DataImmatricolazione { get; set; }
            public string Targa { get; set; }
            public string Note { get; set; }
            public DateTime? DataInserimento { get; set; }
            public DateTime? DataModifica { get; set; }
        }
    }
}

