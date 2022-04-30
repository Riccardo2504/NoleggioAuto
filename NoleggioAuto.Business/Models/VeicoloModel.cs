using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioAuto.Business.Models
{
    public class VeicoloModel
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
        public string Descrizione { get; set; }
        public string DescrizioneAlimentazione { get; set; }
    }
}


