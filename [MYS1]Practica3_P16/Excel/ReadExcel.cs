﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _MYS1_Practica3_P16.DTO;
using Newtonsoft.Json;

namespace _MYS1_Practica3_P16.Excel
{
    class ReadExcel
    {
        public string readCSV(string pathCSV, bool blnHeader)
        {
            var listPuntos = new List<CoordenadaDTO>();

            using (var reader = new StreamReader(pathCSV))
            {
                if (blnHeader) {
                    reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    listPuntos.Add(new CoordenadaDTO
                    {
                        id = int.Parse(values[0]),
                        ejeX = int.Parse(values[1]),
                        ejeY = int.Parse(values[2]),
                        ejeZ = int.Parse(values[3])
                    }
                    );

                }
            }
            return JsonConvert.SerializeObject(listPuntos);
        }
    }
}